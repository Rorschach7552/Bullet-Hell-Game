using BulletHell.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.View
{
    public class BulletRenderer : AbstractEntityRenderer
    {
        private Rectangle[] bullet;
        public BulletRenderer(int threshold, int sizeX, int sizeY, int animationLength, string spriteSheet) : base(threshold, sizeX, sizeY, animationLength, spriteSheet)
        {
            Rectangle[] bullet = new Rectangle[animationLength];

            for (int i = 0; i < animationLength; i++)
            {
                bullet[i] = new Rectangle(sizeX * i, 0, sizeX, sizeY);
            }

            this.bullet = bullet;

            this.baseSprite = bullet[0];

            this.currentAnimationIndex = 0;
        }

        public override void UpdateAnimation(GameTime gameTime)
        {
            if (timer > threshold)
            {

                currentAnimationIndex++;
                if (currentAnimationIndex >= animationLength)
                {
                    currentAnimationIndex = 0;
                }

                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        public override void Animate(SpriteBatch spriteBatch, Vector2 position, float rotation)
        {
            Rectangle currentSprite = bullet[currentAnimationIndex];
            Vector2 origin = new Vector2(sizeX / 2f, sizeY / 2f);
            spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), position, currentSprite, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
