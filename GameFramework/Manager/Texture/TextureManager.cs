using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Manager.Texture
{
	public class TextureManager: ITextureManager {
		public ContentManager ContentManager { get; }
		public string Path { get; }
		public TextureManager(ContentManager contentManager, string path) {
			ContentManager = contentManager;
			Path = path;
		}
		public virtual Texture2D Load(string key) {
			return ContentManager.Load<Texture2D>(GetTexturePath(key));
		}
		protected virtual string GetTexturePath(string key) {
			return System.IO.Path.Combine(Path, key);
		}
	}
}
