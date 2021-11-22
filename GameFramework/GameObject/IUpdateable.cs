using System;
using Microsoft.Xna.Framework;

namespace GameFramework.GameObject {
	public interface IUpdateable {
		event Action<IGameObject, EventArgs> EnabledChanged;
		bool Enabled { get; set; }
		void Update(GameTime gameTime);
	}
}
