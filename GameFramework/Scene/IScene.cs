using GameFramework.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Scene {
	public interface IScene {
		void Initialize(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager, GameServiceContainer container);
		void Configure(string contentDirectory);
		void AddGameObject(IGameObject gameObject);
		void Update(GameTime gameTime);
		void Draw(GameTime gameTime);
	}
}
