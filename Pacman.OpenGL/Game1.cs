using GameFramework.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pacman.Game;

namespace Pacman.OpenGL {
	public class Game1: Microsoft.Xna.Framework.Game {
		private readonly IScene _mainScene;
		private GraphicsDeviceManager _graphicsDeviceManager;
		public Game1() {
			_graphicsDeviceManager = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			_mainScene = new PacmanScene();
		}

		protected override void Initialize() {
			_mainScene.Initialize(GraphicsDevice, _graphicsDeviceManager, Services);
			base.Initialize();
		}

		protected override void LoadContent() {
			_mainScene.Configure("Content");
			base.LoadContent();
		}
		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
					Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			base.Update(gameTime);
			_mainScene.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			base.Draw(gameTime);
			_mainScene.Draw(gameTime);
		}
	}
}