using BulletHell.Controllers;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace BulletHell.Entity.Movement
{
    public class PositionDirectedMovement : AbstractMovement
    {
        public PositionDirectedMovement(Vector2 initialPosition, float speed, float acceleration, float speedCap, Vector2 targetPosition) : base(initialPosition, speed, acceleration, speedCap, 0.0f, targetPosition)
        {
            Vector2 direction = this.targetPosition - currentPosition;
            rotation = (float)Math.Atan2(direction.Y, direction.X);
        }

        public override Vector2 Update(GameTime gameTime)
        {

            Vector2 direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            direction.Normalize();
            rotation = (float)Math.Atan2(direction.Y, direction.X);
            currentPosition += direction * initialSpeed;

            if (!decelerating && initialSpeed < targetSpeed)
            {
                initialSpeed += acceleration;
            }
            else if (decelerating && initialSpeed > targetSpeed)
            {
                initialSpeed += acceleration;
            }

            return currentPosition;
        }
    }
}