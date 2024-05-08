using BulletHell.Controllers;
using BulletHell.Entity.Movement;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.AttackPattern
{
    public class RandomExplosionAttackPattern : AbstractAttackPattern
    {
        private Random random;
        private int numBullets;

        public int NumBullets { get => numBullets; set => numBullets = value; }

        public RandomExplosionAttackPattern(int attackInterval, int numBullets, BulletRenderer renderer) : base(attackInterval, renderer)
        {
            random = new Random();
            this.numBullets = numBullets;
        }

        public override void Execute(GameTime gameTime, Vector2 position)
        {

            if (Counter == attackInterval)
            {
                float maxRadius = 200f;

                for (int i = 0; i < numBullets; i++)
                {
                    float angle = MathHelper.ToRadians(360f * ((float)i / numBullets) + RandomFloat(-15f, 15f));
                    float radius = RandomFloat(0f, maxRadius);
                    Vector2 direction = Vector2.Transform(new Vector2(0, -1), Matrix.CreateRotationZ(angle));
                    AbstractMovement movement = new PositionDirectedMovement(position, RandomFloat(5f, 10f), -0.1f, RandomFloat(1f, 5f), position + direction * radius);
                    BulletController.Instance.AddBullet(position, movement, renderer);
                }
                ResetCounter();
                NotifySubscribers();
            }

            base.Execute(gameTime, position);
        }

        private float RandomFloat(float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }
    }
}
