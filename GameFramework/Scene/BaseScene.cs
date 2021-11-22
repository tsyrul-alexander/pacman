using System;
using System.Collections.Generic;
using GameFramework.GameObject;
using GameFramework.Manager.Texture;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Scene {
	public abstract class BaseScene: IScene {
		protected List<IGameObject> GameObjects { get; set; } = new List<IGameObject>();
		protected GraphicsDevice GraphicsDevice { get; set; }
		protected GameServiceContainer GameServiceContainer { get; set; }
		protected ContentManager ContentManager { get; set; }
		protected ServiceProvider ServiceProvider { get; set; }
		protected SpriteBatch SpriteBatch { get; set; }
		protected GraphicsDeviceManager GraphicsDeviceManager { get; set; }

		public virtual void Initialize(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager, GameServiceContainer container) {
			GameServiceContainer = container;
			GraphicsDevice = graphicsDevice;
			GraphicsDeviceManager = graphicsDeviceManager;
			ContentManager = new ContentManager(GameServiceContainer);
			SpriteBatch = new SpriteBatch(GraphicsDevice);
		}
		protected virtual void ConfigureServiceProvider() {
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			ServiceProvider = serviceCollection.BuildServiceProvider();
		}
		public virtual void ConfigureServices(IServiceCollection serviceCollection) {
			serviceCollection.AddSingleton<ITextureManager>(provider => new TextureManager(ContentManager, string.Empty));
		}
		public virtual void Configure(string contentDirectory) {
			ConfigureServiceProvider();
			ContentManager.RootDirectory = contentDirectory;
		}
		public virtual void AddGameObject(IGameObject gameObject) {
			gameObject.Configure(SpriteBatch);
			gameObject.EnabledChanged += GameObjectOnEnabledChanged;
			gameObject.VisibleChanged += GameObjectOnVisibleChanged;
			gameObject.PositionChanged += GameObjectOnPositionChanged;
			gameObject.SizeChanged += GameObjectOnSizeChanged;
			GameObjects.Add(gameObject);
		}
		public virtual void Update(GameTime gameTime) {
			GameObjects.ForEach(o => {
				if (o.Enabled) {
					o.Update(gameTime);
				}
			});
		}
		public virtual void Draw(GameTime gameTime) {
			GameObjects.ForEach(o => {
				if (o.Visible) {
					o.Draw(gameTime);
				}
			});
		}
		protected virtual void GameObjectOnSizeChanged(IGameObject gameObject, EventArgs arg) { }
		protected virtual void GameObjectOnPositionChanged(IGameObject gameObject, EventArgs arg) { }
		protected virtual void GameObjectOnVisibleChanged(IGameObject gameObject, EventArgs arg) { }
		protected virtual void GameObjectOnEnabledChanged(IGameObject gameObject, EventArgs arg) { }
		protected virtual Rectangle GetScreenSize() {
			return new Rectangle(Point.Zero, new Point(GraphicsDeviceManager.PreferredBackBufferHeight,
					GraphicsDeviceManager.PreferredBackBufferWidth));
		}
	}
}
