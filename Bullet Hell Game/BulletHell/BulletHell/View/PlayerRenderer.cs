using BulletHell.Controllers;
using BulletHell.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.View
{
    public class PlayerRenderer : AbstractEntityRenderer
    {
        private Rectangle[] engineEffect;
        private Rectangle engine;
        private Rectangle[] guns;
        private Rectangle[] shield;

        private byte gunAnimationIndex;
        private byte shieldAnimationIndex;

        public byte GunAnimationIndex { get => gunAnimationIndex; set => gunAnimationIndex = value; }
        public byte ShieldAnimationIndex { get => shieldAnimationIndex; set => shieldAnimationIndex = value; }
        public Rectangle[] Shield { get => shield; set => shield = value; }
        public Rectangle[] Guns { get => guns; set => guns = value; }
        public Rectangle Engine { get => engine; set => engine = value; }
        public Rectangle[] EngineEffect { get => engineEffect; set => engineEffect = value; }

        public PlayerRenderer(int threshold, int sizeX, int sizeY, string spriteSheet) : base(threshold, sizeX, sizeY, 7, spriteSheet)
        {
            Rectangle[] engineEffect = new Rectangle[4];
            engineEffect[0] = new Rectangle(0, 192, sizeX, sizeY);
            engineEffect[1] = new Rectangle(96, 192, sizeX, sizeY);
            engineEffect[2] = new Rectangle(192, 192, sizeX, sizeY);
            engineEffect[3] = new Rectangle(288, 192, sizeX, sizeY);
            this.engineEffect = engineEffect;

            this.baseSprite = new Rectangle(0, 0, sizeX, sizeY);

            Rectangle engine = new Rectangle(0, 288, sizeX, sizeY);
            this.engine = engine;

            Rectangle[] guns = new Rectangle[7];
            guns[0] = new Rectangle(0, 384, sizeX, sizeY);
            guns[1] = new Rectangle(96, 384, sizeX, sizeY);
            guns[2] = new Rectangle(192, 384, sizeX, sizeY);
            guns[3] = new Rectangle(288, 384, sizeX, sizeY);
            guns[4] = new Rectangle(384, 384, sizeX, sizeY);
            guns[5] = new Rectangle(480, 384, sizeX, sizeY);
            guns[6] = new Rectangle(576, 384, sizeX, sizeY);
            this.guns = guns;

            Rectangle[] shield = new Rectangle[10];
            shield[0] = new Rectangle(0, 480, sizeX, sizeY);
            shield[1] = new Rectangle(96, 480, sizeX, sizeY);
            shield[2] = new Rectangle(192, 480, sizeX, sizeY);
            shield[3] = new Rectangle(288, 480, sizeX, sizeY);
            shield[4] = new Rectangle(384, 480, sizeX, sizeY);
            shield[5] = new Rectangle(480, 480, sizeX, sizeY);
            shield[6] = new Rectangle(576, 480, sizeX, sizeY);
            shield[7] = new Rectangle(672, 480, sizeX, sizeY);
            shield[8] = new Rectangle(768, 480, sizeX, sizeY);
            shield[9] = new Rectangle(864, 480, sizeX, sizeY);
            this.shield = shield;

            this.currentAnimationIndex = 1;
            gunAnimationIndex = 0;
            shieldAnimationIndex = 0;
        }

        public override void UpdateAnimation(GameTime gameTime)
        {
            if (timer > threshold)
            {
                if (PlayerController.Instance.Player.IsShooting)
                {
                    gunAnimationIndex++;
                    if (gunAnimationIndex >= 7)
                    {
                        gunAnimationIndex = 0;
                    }
                }
                else
                {
                    gunAnimationIndex = 0;
                }

                if (PlayerController.Instance.Player.Invulnerable)
                {
                    shieldAnimationIndex++;

                    if (shieldAnimationIndex >= 10)
                    {
                        shieldAnimationIndex = 0;
                    }
                }
                else
                {
                    shieldAnimationIndex = 0;
                }

                currentAnimationIndex++;
                if (currentAnimationIndex >= 4)
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
            Player player = PlayerController.Instance.Player;
            if (player != null)
            {
                // sprite center point.
                Vector2 origin = new Vector2(sizeX / 2f, sizeY / 2f);

                // render the sprite with the position at the origin of the sprite.
                spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), player.Pos, guns[gunAnimationIndex], Color.White, player.Rotation, origin, 1.0f, SpriteEffects.None, 0f);
                spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), player.Pos, engine, Color.White, player.Rotation, origin, 1.0f, SpriteEffects.None, 0f);
                spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), player.Pos, engineEffect[currentAnimationIndex], Color.White, player.Rotation, origin, 1.0f, SpriteEffects.None, 0f);
                spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), player.Pos, baseSprite, Color.White, player.Rotation, origin, 1.0f, SpriteEffects.None, 0f);

                if (player.Invulnerable)
                {
                    spriteBatch.Draw(gameSprites.GetSprite(spriteSheet), player.Pos, shield[shieldAnimationIndex], Color.White, player.Rotation, origin, 1.0f, SpriteEffects.None, 0f);
                }

                // hitbox
                Texture2D txt = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                txt.SetData(new Color[] { Color.White });
                Rectangle hitbox = player.GetHitbox();
                spriteBatch.Draw(txt, hitbox.Location.ToVector2(), hitbox, Color.White, player.Rotation, origin, 1.0f, SpriteEffects.None, 0f);
            }
        }
    }
}
