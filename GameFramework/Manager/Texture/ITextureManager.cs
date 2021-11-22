using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Manager.Texture
{
	public interface ITextureManager {
		Texture2D Load(string key);
	}
}
