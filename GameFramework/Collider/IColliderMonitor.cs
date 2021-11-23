using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameFramework.Collider
{
	public interface IColliderMonitor {
		void Add(ICollider collider);
		void Clear();
		IList<ICollider> Search(Rectangle rectangle);
		IList<ICollider> Search(ICollider collider);
	}
}
