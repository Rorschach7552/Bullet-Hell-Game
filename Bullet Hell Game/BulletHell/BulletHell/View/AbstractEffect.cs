using BulletHell.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.View
{
    public abstract class AbstractEffect
    {
        protected SpriteFlyweightFactory gameSprites = SpriteFlyweightFactory.Instance;

        protected bool finished;
        public bool Finished => finished;
        public AbstractEffect(int threshold, int size, string spriteSheet, Vector2 position, float rotation)
        {

        }

        public abstract void Animate(SpriteBatch spriteBatch);
        public abstract void UpdateAnimation(GameTime gameTime);
    }
}
