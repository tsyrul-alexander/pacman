using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace GameFramework.Collider.QuadTree
{
	public class QuadTreeMonitor: IColliderMonitor {
		private readonly QuadTreeNode _rootTreeNode;
		public QuadTreeMonitor(Rectangle bound) {
			_rootTreeNode = new QuadTreeNode(bound, 0);
		}
		public void Add(ICollider collider) {
			_rootTreeNode.Add(collider);
		}
		public void Clear() {
			_rootTreeNode.Clear();
		}
		public IList<ICollider> Search(Rectangle rectangle) {
			return _rootTreeNode.Search(rectangle);
		}
		public IList<ICollider> Search(ICollider collider) {
			return Search(collider.ColliderItem.Bound).Where(coll => coll != collider).ToList();
		}
	}
}
