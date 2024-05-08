using Microsoft.Xna.Framework;
using System;

namespace BulletHell.Entity.Movement
{
    public class CircularMovement : AbstractMovement
    {
        private bool direction;
        private Vector2 center;
        private float radius = 100f;
        private float angle = 0f;
        public Vector2 Center { get => center; set => center = value; }
        public float Angle { get => angle; set => angle = value; }
        public float Radius { get => radius; set => radius = value; }
        public bool Direction { get => direction; set => direction = value; }

        public CircularMovement(Vector2 origin, float speed, bool direction) : base(origin, speed, 0.0f, 0.0f, 0.0f, Vector2.Zero)
        {
            this.center = origin;
            this.direction = direction;
        }

        public override Vector2 Update(GameTime gameTime)
        {
            angle += 0.05f * initialSpeed;
            Random random = new Random();

            center.X += direction? 1 : -1;

            float x = center.X + radius * (float)Math.Cos(angle);
            float y = center.Y + radius * (float)Math.Sin(angle);
            currentPosition = new Vector2(x, y);
            

            rotation = (float)Math.Atan2(currentPosition.Y, currentPosition.X);

            return currentPosition;
        }
    }
}