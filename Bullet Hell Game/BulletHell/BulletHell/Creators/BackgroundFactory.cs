using BulletHell.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Creators
{
    public class BackgroundFactory
    {
        public Background CreateBackground(Texture2D texture, Vector2 speed)
        {
            return new Background(texture, speed);
        }
    }
}
