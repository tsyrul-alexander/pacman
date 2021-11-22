using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace GameFramework.Collider.QuadTree
{
	internal class QuadTreeNode {
		private const byte Size = 4;
		private const byte MaxObjects = 10;
		private const byte MaxLevels = 10;

		private Rectangle _bound;
		private readonly int _level;
		private readonly IList<IRectangleCollider> _colliders;

		internal QuadTreeNode[] Nodes;
		public QuadTreeNode(Rectangle bound, int level) {
			_bound = bound;
			_level = level;
			_colliders = new List<IRectangleCollider>();
		}
		public void Add(IRectangleCollider collider) {
			var rectangle = collider.Bound;
			if (Nodes != null) {
				var index = GetIndex(rectangle);
				if (index != -1) {
					Nodes[index].Add(collider);
					return;
				}
			}
			_colliders.Add(collider);
			if (_colliders.Count > MaxObjects && _level < MaxLevels) {
				if (Nodes == null) {
					Nodes = new QuadTreeNode[Size];
					Split();
				}
				var i = 0;
				while (i < _colliders.Count) {
					var index = GetIndex(_colliders[i].Bound);
					if (index != -1) {
						Nodes[index].Add(_colliders[i]);
						_colliders.RemoveAt(i);
					} else {
						i++;
					}
				}
			}
		}
		public void Clear() {
			_colliders.Clear();
			if (Nodes == null) {
				return;
			}
			foreach (var quadTreeNode in Nodes) {
				quadTreeNode?.Clear();
			}
			Nodes = null;
		}
		public IList<IRectangleCollider> Search(Rectangle rectangle) {
			var list = new List<IRectangleCollider>();
			Search(rectangle, list);
			return list;
		}
		protected virtual void Search(Rectangle rectangle, List<IRectangleCollider> list) {
			var index = GetIndex(rectangle);
			var intersectColliders = _colliders.Where(collider => collider.Bound.Intersects(rectangle));
			if (intersectColliders.Count() > 1) {

			}
			list.AddRange(intersectColliders);
			if (Nodes == null) {
				return;
			}
			if (index != -1) {
				Nodes[index].Search(rectangle, list);
			} else {
				foreach (var node in Nodes) {
					node.Search(rectangle, list);
				}
			}
		}
		private void Split() {
			var subWidth = _bound.Width / 2;
			var subHeight = _bound.Height / 2;
			var x = _bound.X;
			var y = _bound.Y;
			var newLevel = _level + 1;
			Nodes[0] = new QuadTreeNode(new Rectangle(x + subWidth, y, subWidth, subHeight), newLevel);
			Nodes[1] = new QuadTreeNode(new Rectangle(x, y, subWidth, subHeight), newLevel);
			Nodes[2] = new QuadTreeNode(new Rectangle(x, y + subHeight, subWidth, subHeight), newLevel);
			Nodes[3] = new QuadTreeNode(new Rectangle(x + subWidth, y + subHeight, subWidth, subHeight), newLevel);
		}
		private int GetIndex(Rectangle rectangle) {
			var index = -1;
			double verticalMidpoint = _bound.X + (_bound.Width / 2);
			double horizontalMidpoint = _bound.Y + (_bound.Height / 2);
			var topQuadrant = (rectangle.Y < horizontalMidpoint && rectangle.Y + rectangle.Height < horizontalMidpoint);
			var bottomQuadrant = (rectangle.Y > horizontalMidpoint);
			if (rectangle.X < verticalMidpoint && _bound.X + rectangle.Width < verticalMidpoint) {
				if (topQuadrant) {
					index = 1;
				} else if (bottomQuadrant) {
					index = 2;
				}
			}
			else if (rectangle.X > verticalMidpoint) {
				if (topQuadrant) {
					index = 0;
				} else if (bottomQuadrant) {
					index = 3;
				}
			}
			return index;
		}
	}
}
