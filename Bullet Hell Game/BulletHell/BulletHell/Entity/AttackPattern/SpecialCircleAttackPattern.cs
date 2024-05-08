using BulletHell.Controllers;
using BulletHell.Entity.Movement;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Audio;

namespace BulletHell.Entity.AttackPattern
{
    public class SpecialCircleAttackPattern : AbstractAttackPattern
    {
        private Random random;

        public SpecialCircleAttackPattern(int attackInterval, BulletRenderer renderer) : base(attackInterval, renderer)
        {
            this.random = new Random();
        }

        public override void Execute(GameTime gameTime, Vector2 position)
        {

            if (Counter == attackInterval)
            {
                NotifySubscribers();
            }

            SpawnBulletRing(0, position, renderer);
            SpawnBulletRing(20, position, renderer);
            SpawnBulletRing(40, position, renderer);
            SpawnBulletRing(60, position, renderer);
            SpawnBulletRing(80, position, renderer);
            SpawnBulletRing(100, position, renderer);
            SpawnBulletRing(120, position, renderer);

            if (Counter == attackInterval + 460)
            {
                for (int i = 0; i < 5; i++)
                {
                    float angle = MathHelper.ToRadians(i * 72);
                    int xd = random.Next(-1, 1);
                    int yd = random.Next(-1, 1);
                    Vector2 direction = Vector2.Transform(new Vector2(xd, yd), Matrix.CreateRotationZ(angle));

                    AbstractMovement movement = new PositionDirectedMovement(position, 3.0f, 0.1f, 7.0f, position + direction * 100f);
                    BulletController.Instance.AddSpecialBullet(position, movement, new BulletRenderer(60, 256, 256, 11, "planet_bullet"));
                    SoundEffectInstance tiktokinstance = GameResources.Tiktok.CreateInstance();
                    tiktokinstance.Play();
                }

                ResetCounter();
            }

            base.Execute(gameTime, position);
        }

        private void SpawnBulletRing(int offset, Vector2 position, BulletRenderer renderer)
        {
            if (Counter == attackInterval + offset)
            {
                for (int i = 0; i < 360; i++)
                {
                    float angle = MathHelper.ToRadians(i * 1);
                    Vector2 direction = Vector2.Transform(new Vector2(0, -1), Matrix.CreateRotationZ(angle));
                    AbstractMovement movement = new PositionDirectedMovement(position, 4.0f, -0.1f, 1.0f, position + direction * 100f);
                    BulletController.Instance.AddBullet(position, movement, renderer);

                }
            }
        }
    }
}
