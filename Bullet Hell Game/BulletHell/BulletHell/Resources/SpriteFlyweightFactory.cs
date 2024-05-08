using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Sprites
{
    public class SpriteFlyweightFactory
    {
        private ContentManager content;

        private Dictionary<string, Texture2D> sprites = new Dictionary<string, Texture2D>();

        private static SpriteFlyweightFactory instance = new();
        public static SpriteFlyweightFactory Instance => instance;
        private SpriteFlyweightFactory() { }
        public Texture2D GetSprite(string path)
        {
            if (sprites.ContainsKey(path))
            {
                return sprites[path];
            }
            else
            {
                sprites[path] = content.Load<Texture2D>(path);
                return sprites[path];
            }
        }
        public void SetContent(ContentManager _content)
        {
            content = _content;
        }
    }
}
