using BulletHell.Entity.Boss;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace BulletHell.Entity.Movement
{
    public class SpirlingClockwiseMovement : AbstractMovement
    {
        private Vector2 center;
        private float radius;
        private float angle = 0f;
        public Vector2 Center { get => center; set => center = value; }
        public float Radius { get => radius; set => radius = value; }
        public float Angle { get => angle; set => angle = value; }
        public SpirlingClockwiseMovement(Vector2 initialPosition, Vector2 origin, float speed, float radius) : base(initialPosition, speed, 0.0f, 0.0f, 0.0f, Vector2.Zero)
        {
            this.center = origin;
            this.radius = radius;
        }

        public override Vector2 Update(GameTime gameTime)
        {
            angle += 0.05f * initialSpeed;

            float x = center.X + radius * (float)Math.Cos(angle);
            float y = center.Y + radius * (float)Math.Sin(angle);

            currentPosition = new Vector2(x, y);

            rotation = (float)Math.Atan2(currentPosition.Y, currentPosition.X);

            radius++;

            if (radius == 100)
            {
                radius = 10f;
            }

            return currentPosition;
        }

        public override void Update(AbstractObservable subject)
        {
            if (subject is BossPhase e)
            {
                center = e.Pos;
            }
        }
    }
}
