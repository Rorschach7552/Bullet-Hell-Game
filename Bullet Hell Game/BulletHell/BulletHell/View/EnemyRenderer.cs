using BulletHell.Controllers;
using BulletHell.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace BulletHell.View
{
    public class EnemyRenderer : AbstractEntityRenderer
    {
        private Rectangle[] engineEffect;
        private Rectangle[] guns;

        private int shootingAnimationLength;

        private byte gunAnimationIndex;
        public Rectangle[] Guns { get => guns; set => guns = value; }
        public Rectangle[] EngineEffect { get => engineEffect; set => engineEffect = value; }
        public int ShootingAnimationLength { get => shootingAnimationLength; set => shootingAnimationLength = value; }
        public byte GunAnimationIndex { get => gunAnimationIndex; set => gunAnimationIndex = value; }

        [JsonConstructor]
        public EnemyRenderer(int threshold, int sizeX, int sizeY, int animationLength, int shootingAnimationLength, string spriteSheet) : base(threshold, sizeX, sizeY, animationLength, spriteSheet)
        {
            Rectangle[] engineEffect = new Rectangle[animationLength]; // 10
            for (int i = 0; i < animationLength; i++)
            {
                engineEffect[i] = new Rectangle(i * sizeX, sizeY * 1, sizeX, sizeY);
            }

            this.engineEffect = engineEffect;

            this.baseSprite = new Rectangle(0, 0, sizeX, sizeY);

            Rectangle[] guns = new Rectangle[shootingAnimationLength]; // 6
            for (int i = 0; i < shootingAnimationLength; i++)
            {
                guns[i] = new Rectangle(i * sizeX, sizeY * 2, sizeX, sizeY);
            }
            this.guns = guns;

            this.currentAnimationIndex = 1;
            this.gunAnimationIndex = 0;
        }

        public override void UpdateAnimation(GameTime gameTime)
        {
            if (timer > threshold)
            {
                if (isShooting)
                {
                    gunAnimationIndex++;

                    if (gunAnimationIndex >= shootingAnimationLength)
                    {
                        gunAnimationIndex = 0;
                        isShooting = false;
                    }
                }
                else
                {
                    gunAnimationIndex = 0;
                }

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
            // sprite center point.
            Vector2 origin = new Vector2(sizeX / 2f, sizeY / 2f);

            // render the sprite with the position at the origin of the sprite.
            spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), position, guns[gunAnimationIndex], Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0f);
            spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), position, engineEffect[currentAnimationIndex], Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0f);
            spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), position, baseSprite, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
