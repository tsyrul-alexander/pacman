using System;
using GameFramework.GameObject;
using Microsoft.Xna.Framework;

namespace GameFramework.Collider {
    public class RectangleCollider: IColliderItem {
        private readonly IGameObject gameObject;

        public Rectangle Bound { get; set; }

        public RectangleCollider(IGameObject gameObject) {
            this.gameObject = gameObject;
            SubscribeGameObjectEvents();
        }
        protected void SubscribeGameObjectEvents() {
            gameObject.SizeChanged += GameObject_SizeChanged;
            gameObject.PositionChanged += GameObject_PositionChanged;
        }
        protected void UnsubscribeGameObjectEvents() {
            gameObject.SizeChanged += GameObject_SizeChanged;
            gameObject.PositionChanged += GameObject_PositionChanged;
        }
        private void GameObject_PositionChanged(IGameObject arg1, EventArgs arg2) {
            ReCalculateBound();
        }
        private void GameObject_SizeChanged(IGameObject arg1, EventArgs arg2) {
            ReCalculateBound();
        }
        protected virtual void ReCalculateBound() {
            Bound = new Rectangle(gameObject.Position.ToPoint(), gameObject.Size.ToPoint());
        }
    }
}
