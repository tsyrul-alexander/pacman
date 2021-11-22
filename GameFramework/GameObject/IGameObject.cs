using GameFramework.Collider;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.GameObject
{
	public interface IGameObject: IUpdateable, IDrawable, IRectangleCollider {
		void Configure(SpriteBatch spriteBatch);
	}
}
