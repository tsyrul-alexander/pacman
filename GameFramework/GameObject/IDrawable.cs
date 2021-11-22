using System;
using Microsoft.Xna.Framework;

namespace GameFramework.GameObject {
	public interface IDrawable: IPosition {
		event Action<IGameObject, EventArgs> VisibleChanged;
		event Action<IGameObject, EventArgs> PositionChanged;
		event Action<IGameObject, EventArgs> SizeChanged;
		Vector2 Size { get; set; }
		bool Visible { get; set; }
		void Draw(GameTime gameTime);
	}
}