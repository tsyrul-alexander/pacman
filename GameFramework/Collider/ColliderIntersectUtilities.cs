namespace GameFramework.Collider {
    public static class ColliderIntersectUtilities {
        public static bool Intersects(this ICollider collider, ICollider value) {
            if (collider.ColliderItem == null || value.ColliderItem == null) {
                return false;
            }
            var isMainRectangleCollider = IsRectangleColllider(collider, out var mainRectangleCollider);
            var isValueRectangleCollider = IsRectangleColllider(value, out var valueRectangleCollider);
            if (isMainRectangleCollider && isValueRectangleCollider) {
                return RectangleIntersects(mainRectangleCollider, valueRectangleCollider);
            }
            var isMainCircleCollider = IsCircleColllider(collider, out var mainCircleCollider);
            if () {

            }
            collider.ColliderItem.Bound.Intersects()
        }
        internal static bool IsRectangleColllider(ICollider collider, out RectangleCollider value) {
            if (collider is RectangleCollider rectangleCollider) {
                value = rectangleCollider;
                return true;
            }
            value = null;
            return false;
        }
        internal static bool IsCircleColllider(ICollider collider, out CircleCollider value) {
            if (collider is CircleCollider circleCollider) {
                value = circleCollider;
                return true;
            }
            value = null;
            return false;
        }
        internal static bool RectangleIntersects(RectangleCollider collider, RectangleCollider value) {
            return collider.Bound.Intersects(value.Bound);
        }
    }
}
