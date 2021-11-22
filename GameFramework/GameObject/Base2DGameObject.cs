using GameFramework.Manager.Texture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.GameObject
{
	public abstract class Base2DGameObject: BaseGameObject {
		public ITextureManager TextureManager { get; }
		protected Texture2D Texture2D { get; set; }
		public Base2DGameObject(ITextureManager textureManager) {
			TextureManager = textureManager;
		}
		public override void Configure(SpriteBatch spriteBatch) {
			base.Configure(spriteBatch);
			LoadTexture();
		}
		public override void Draw(GameTime gameTime) {
			base.Draw(gameTime);
			SpriteBatch.Draw(Texture2D, Position, Color.White);
		}
		protected virtual void LoadTexture() {
			Texture2D = TextureManager.Load(TextureKey());
		}
		protected abstract string TextureKey();
	}
}
