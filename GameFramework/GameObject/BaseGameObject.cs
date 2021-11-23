using System;
using GameFramework.Collider;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.GameObject
{
	public abstract class BaseGameObject: IGameObject {
		private bool _enabled = true;
		private bool _visible = true;
		private Vector2 _position;
		private Vector2 _size;
		public event Action<IGameObject, EventArgs> EnabledChanged;
		public event Action<IGameObject, EventArgs> VisibleChanged;
		public event Action<IGameObject, EventArgs> PositionChanged;
		public event Action<IGameObject, EventArgs> SizeChanged;
		public virtual bool Enabled {
			get => _enabled;
			set {
				if (_enabled == value) {
					return;
				}
				_enabled = value;
				OnEnabledChanged();
			}
		}
		public virtual bool Visible {
			get => _visible;
			set {
				if (_visible == value) {
					return;
				}
				_visible = value;
				OnVisibleChanged();
			}
		}
		public virtual Vector2 Position {
			get => _position;
			set {
				if (_position == value) {
					return;
				}
				_position = value;
				OnPositionChanged();
			}
		}
		public virtual Vector2 Size {
			get => _size;
			set {
				if (_size == value) {
					return;
				}
				_size = value;
				OnSizeChanged();
			}
		}
		protected SpriteBatch SpriteBatch { get; set; }
        public IColliderItem ColliderItem { get; set; }

        public virtual void Update(GameTime gameTime) { }
		public virtual void Draw(GameTime gameTime) { }
		public virtual void Configure(SpriteBatch spriteBatch) {
			SpriteBatch = spriteBatch;
		}
	
		protected virtual void OnEnabledChanged() {
			EnabledChanged?.Invoke(this, EventArgs.Empty);
		}
		protected virtual void OnVisibleChanged() {
			VisibleChanged?.Invoke(this, EventArgs.Empty);
		}
		protected virtual void OnPositionChanged() {
			PositionChanged?.Invoke(this, EventArgs.Empty);
		}
		protected virtual void OnSizeChanged() {
			SizeChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
