using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.Movement
{
    public class AxialMovement : AbstractMovement
    {
        [JsonConstructor]
        public AxialMovement(Vector2 initialPosition, float speed, Vector2 targetPosition) : this(initialPosition, speed, targetPosition, 0.0f, speed)
        {
            
        }
        public AxialMovement(Vector2 initialPosition, float speed, Vector2 targetPosition, float acceleration, float targetSpeed) : base(initialPosition, speed, acceleration, targetSpeed, 0.0f, targetPosition)
        {
            rotation = (float)Math.Atan2(targetPosition.Y, targetPosition.X);
        }

        public override Vector2 Update(GameTime gameTime)
        {
            currentPosition += targetPosition * initialSpeed;
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
