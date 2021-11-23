using GameFramework.Collider;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.GameObject
{
	public interface IGameObject: IUpdateable, IDrawable, ICollider {
		void Configure(SpriteBatch spriteBatch);
	}
}
