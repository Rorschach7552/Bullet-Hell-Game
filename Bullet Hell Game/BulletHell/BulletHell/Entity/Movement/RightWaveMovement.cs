using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.Movement
{
    public class RightWaveMovement : AbstractMovement
    {
        float centerY;
        float radius = 20.0f;
        float angle = 0.0f;
        public float CenterY { get => centerY; set => centerY = value; }
        public float Radius { get => radius; set => radius = value; }
        public float Angle { get => angle; set => angle = value; }
        public RightWaveMovement(Vector2 origin, float speed) : base(origin, speed, 0.0f, 0.0f, 0.0f, Vector2.Zero)
        {
            centerY = origin.Y;
        }
        public override Vector2 Update(GameTime gameTime)
        {
            float offset = (float)Math.Sin(angle * initialSpeed) * radius;
            angle += 0.1f * (float)initialSpeed;
            currentPosition.Y = centerY + offset;
            currentPosition.X += initialSpeed;

            return currentPosition;
        }
    }
}
