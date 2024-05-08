using BulletHell.Entity.AttackPattern;
using BulletHell.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace BulletHell.View
{
    public abstract class AbstractEntityRenderer : IObserver
    {
        protected SpriteFlyweightFactory gameSprites = SpriteFlyweightFactory.Instance;
        protected float timer;
        protected int threshold;
        protected int sizeX;
        protected int sizeY;
        protected int animationLength;
        protected bool isShooting;

        protected string spriteSheet;
        protected Rectangle baseSprite;

        protected byte currentAnimationIndex;
        public Rectangle BaseSprite => baseSprite;
        public string SpriteSheet => spriteSheet;
        public int SizeX => sizeX;
        public int SizeY => sizeY;
        public byte CurrentAnimationIndex { get => currentAnimationIndex; set => currentAnimationIndex = value; }
        public int AnimationLength { get => animationLength; set => animationLength = value; }
        public int Threshold { get => threshold; set => threshold = value; }
        public float Timer { get => timer; set => timer = value; }
        public AbstractEntityRenderer(int threshold, int sizeX, int sizeY, int animationLength, string spriteSheet)
        {
            timer = 0;
            this.threshold = threshold;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.animationLength = animationLength;
            this.spriteSheet = spriteSheet;
            this.isShooting = false;
        }

        public abstract void UpdateAnimation(GameTime gameTime);

        public abstract void Animate(SpriteBatch spriteBatch, Vector2 position, float rotation);

        public void Update(AbstractObservable subject)
        {
            if (subject is AbstractAttackPattern)
            {
                this.isShooting = true;
            }
        }
    }
}
