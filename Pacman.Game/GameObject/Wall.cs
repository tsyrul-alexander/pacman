using GameFramework.GameObject;
using GameFramework.Manager.Texture;

namespace Pacman.Game.GameObject
{
	public class Wall: Base2DGameObject
	{
		public Wall(ITextureManager textureManager): base(textureManager) { }
		protected override string TextureKey() {
			return "GreyBlock\\grey_brick_state_1_center_repeating";
		}
	}
}
