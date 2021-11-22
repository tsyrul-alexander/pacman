using System.Collections.Generic;
using GameFramework.Collider;
using GameFramework.GameObject;
using GameFramework.Manager.Texture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pacman.Game.GameObject
{
	public class MainPerson: Base2DGameObject {
		public IColliderMonitor ColliderMonitor { get; }
		protected readonly float Speed = 100;
		public MainPerson(ITextureManager textureManager, IColliderMonitor colliderMonitor): base(textureManager) {
			ColliderMonitor = colliderMonitor;
		}
		protected override string TextureKey() {
			return "CartoonBall\\black\\smile";
		}
		public override void Update(GameTime gameTime) {
			base.Update(gameTime);
			var keyStatus = Keyboard.GetState();
			if (keyStatus.IsKeyDown(Keys.D)) {
				MoveRight(gameTime);
			} 
			if (keyStatus.IsKeyDown(Keys.A)) {
				MoveLeft(gameTime);
			} 
			if (keyStatus.IsKeyDown(Keys.W)) {
				MoveUp(gameTime);
			} 
			if (keyStatus.IsKeyDown(Keys.S)) {
				MoveDown(gameTime);
			}
			var colliders = ColliderMonitor.Search(this);
			if (colliders.Count > 0) {
				OnCollide(colliders);
			}
		}
		protected virtual void OnCollide(IList<IRectangleCollider> colliders) {
			foreach (var collider in colliders) {
				if (collider is Wall wall) {
					wall.Visible = false;
					wall.Enabled = false;
				}
			}
		}
		protected virtual float GetSpeed(GameTime gameTime) {
			return Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;
		}
		protected virtual void MoveRight(GameTime gameTime) {
			Position = Vector2.Add(Position, new Vector2(GetSpeed(gameTime), 0));
		}
		protected virtual void MoveLeft(GameTime gameTime) {
			Position = Vector2.Subtract(Position, new Vector2(GetSpeed(gameTime), 0));
		}
		protected virtual void MoveUp(GameTime gameTime) {
			Position = Vector2.Subtract(Position, new Vector2(0, GetSpeed(gameTime)));
		}
		protected virtual void MoveDown(GameTime gameTime) {
			Position = Vector2.Add(Position, new Vector2(0, GetSpeed(gameTime)));
		}
	}
}
