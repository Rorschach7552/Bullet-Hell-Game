using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.View
{
    public class ScreenFlashEffect : AbstractEffect
    {
        private string sprite;
        private int duration;
        public ScreenFlashEffect(string spriteSheet) : base(0, 0, spriteSheet, Vector2.Zero, 0)
        {
            this.sprite = spriteSheet;
            this.duration = 0;
        }

        public override void Animate(SpriteBatch spriteBatch)
        {
            if (!finished)
            {
                spriteBatch.Draw(gameSprites.GetSprite(sprite), Vector2.Zero, Color.White);
            }
        }

        public override void UpdateAnimation(GameTime gameTime)
        {
            if (!finished)
            {
                if (duration > 4)
                {
                    finished = true;
                }
                duration++;
            }
        }
    }
}
