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
		public void Add(IRectangleCollider collider) {
			_rootTreeNode.Add(collider);
		}
		public void Clear() {
			_rootTreeNode.Clear();
		}
		public IList<IRectangleCollider> Search(Rectangle rectangle) {
			return _rootTreeNode.Search(rectangle);
		}
		public IList<IRectangleCollider> Search(IRectangleCollider collider) {
			return Search(collider.Bound).Where(coll => coll != collider).ToList();
		}
	}
}
