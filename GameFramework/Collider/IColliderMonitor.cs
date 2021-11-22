using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameFramework.Collider
{
	public interface IColliderMonitor {
		void Add(IRectangleCollider collider);
		void Clear();
		IList<IRectangleCollider> Search(Rectangle rectangle);
		IList<IRectangleCollider> Search(IRectangleCollider collider);
	}
}
