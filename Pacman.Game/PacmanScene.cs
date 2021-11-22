using System;
using GameFramework.Collider;
using GameFramework.Collider.QuadTree;
using GameFramework.GameObject;
using GameFramework.Scene;
using GameFramework.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pacman.Game.GameObject;

namespace Pacman.Game {
	public class PacmanScene: BaseScene {
		private IColliderMonitor ColliderMonitor { get; set; }
		public override void Initialize(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager,
				GameServiceContainer container) {
			base.Initialize(graphicsDevice, graphicsDeviceManager, container);
			ColliderMonitor = CreateColliderMonitor();
		}
		public override void ConfigureServices(IServiceCollection serviceCollection) {
			base.ConfigureServices(serviceCollection);
			serviceCollection.AddTransient<MainPerson>();
			serviceCollection.AddTransient<Wall>();
			serviceCollection.AddSingleton(ColliderMonitor);
		}
		
		public override void Configure(string contentDirectory) {
			base.Configure(contentDirectory);
			AddGameObject(CreateMainPerson());
			for (int i = 0; i < 1; i++) {
				AddGameObject(CreateWall());
			}
			ReloadColliderMonitor();
		}
		public override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);
			SpriteBatch.Begin();
			base.Draw(gameTime);
			SpriteBatch.End();
		}
		protected virtual IColliderMonitor CreateColliderMonitor() {
			return new QuadTreeMonitor(GetScreenSize());
		}
		protected virtual IGameObject CreateMainPerson() {
			var person = ServiceProvider.GetService<MainPerson>();
			person.Size = new Vector2(256, 256);
			return person;
		}
		protected virtual IGameObject CreateWall() {
			var wall = ServiceProvider.GetService<Wall>();
			wall.Position = new Vector2(GameUtilities.RandomNumber(300, 300), GameUtilities.RandomNumber(300, 300));
			wall.Size = new Vector2(50, 50);
			return wall;
		}
		protected virtual void ReloadColliderMonitor() {
			ColliderMonitor.Clear();
			foreach (var gameObject in GameObjects) {
				if (!gameObject.Enabled) {
					continue;
				}
				ColliderMonitor.Add(gameObject);
			}
		}
		protected override void GameObjectOnVisibleChanged(IGameObject gameObject, EventArgs arg) {
			base.GameObjectOnVisibleChanged(gameObject, arg);
			ReloadColliderMonitor();
		}
		protected override void GameObjectOnEnabledChanged(IGameObject gameObject, EventArgs arg) {
			base.GameObjectOnEnabledChanged(gameObject, arg);
			ReloadColliderMonitor();
		}
		protected override void GameObjectOnPositionChanged(IGameObject gameObject, EventArgs arg) {
			base.GameObjectOnPositionChanged(gameObject, arg);
			ReloadColliderMonitor();
		}
		protected override void GameObjectOnSizeChanged(IGameObject gameObject, EventArgs arg) {
			base.GameObjectOnSizeChanged(gameObject, arg);
			ReloadColliderMonitor();
		}
	}
}
