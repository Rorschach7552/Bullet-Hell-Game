using BulletHell.Creators;
using BulletHell.Entity;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Controllers
{
    public class BackgroundController
    {
        private List<Background> backgrounds = new();
        public List<Background> Backgrounds => backgrounds;

        private BackgroundFactory factory = new BackgroundFactory();

        private static readonly BackgroundController instance = new();
        public static BackgroundController Instance => instance;
        private BackgroundController() { }

        public void AddBackground(Texture2D texture, Vector2 speed)
        {
            backgrounds.Add(factory.CreateBackground(texture, speed));
        }

        public void Update(GameTime gameTime, Viewport viewport)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 direction = new Vector2(0, 1);

            foreach (Background bg in backgrounds) 
            {
                bg.Viewport = viewport;
                Vector2 distance = direction * bg.Speed * elapsed;
                bg.Offset += distance;
            }
        }
    }
}
