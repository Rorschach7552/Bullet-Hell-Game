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
    public class DeathEffect : AbstractEffect
    {
        private Rectangle[] deathEffect;
        private Vector2 position;
        private float rotation;
        protected string spriteSheet;
        protected Rectangle baseSprite;
        protected int threshold;
        protected float timer;

        private byte deathAnimationIndex;

        private int animationLength;
        public DeathEffect(int threshold, int size, string spriteSheet, Vector2 position, float rotation) : base(threshold, size, spriteSheet, position, rotation)
        {
            this.position = position;
            this.rotation = rotation;
            this.spriteSheet = spriteSheet;
            this.threshold = threshold;
            this.animationLength = 10;
            this.timer = 0;

            Rectangle[] death = null;

            if (size <= 64)
            {
                death = new Rectangle[animationLength];
                for (int i = 0; i < 5; i++)
                {
                    death[i] = new Rectangle(i * size * 2, size * 3, size, size);
                }
                for (int i = 0; i < 4; i++)
                {
                    death[i + 5] = new Rectangle(608 + (i * 128), size * 3, 128, 80);
                }
            }
            else
            {
                animationLength = 14;
                death = new Rectangle[animationLength];
                for (int i = 0; i < animationLength; i++)
                {
                    death[i] = new Rectangle(i * size * 2, size * 3, size, size);
                }
            }

            this.deathEffect = death;
            this.baseSprite = deathEffect[0];
            this.deathAnimationIndex = 0;
        }

        public override void Animate(SpriteBatch spriteBatch)
        {
            if (!finished)
            {
                // sprite center point.
                Vector2 origin = new Vector2(baseSprite.Width / 2f, baseSprite.Height / 2f);

                // render the sprite with the position at the origin of the sprite.
                spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), position, deathEffect[deathAnimationIndex], Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0f);
            }
        }

        public override void UpdateAnimation(GameTime gameTime)
        {
            if (timer > threshold)
            {
                deathAnimationIndex++;

                if (deathAnimationIndex >= animationLength)
                {
                    deathAnimationIndex = 0;
                    this.finished = true;
                }
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
    }
}
