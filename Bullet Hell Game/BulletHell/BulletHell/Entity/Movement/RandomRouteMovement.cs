using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.Movement
{
    public class RandomRouteMovement : AbstractMovement
    {

        private float angle;
        private float minDeviation;
        private float maxDeviation;
        private float deviation;
        private float directionChangeInterval;
        private float timeSinceLastDirectionChange;

        public float Angle { get => angle; set => angle = value; }
        public float MinDeviation { get => minDeviation; set => minDeviation = value; }
        public float MaxDeviation { get => maxDeviation; set => maxDeviation = value; }
        public float Deviation { get => deviation; set => deviation = value; }
        public float DirectionChangeInterval { get => directionChangeInterval; set => directionChangeInterval = value; }
        public float TimeSinceLastDirectionChange { get => timeSinceLastDirectionChange; set => timeSinceLastDirectionChange = value; }

        private Random random;

        public RandomRouteMovement(Vector2 startPosition, float speed, float minDeviation, float maxDeviation, float directionChangeInterval) : base(startPosition, speed, 0.0f, 0.0f, 0.0f, Vector2.Zero)
        {
            this.minDeviation = minDeviation;
            this.maxDeviation = maxDeviation;
            this.directionChangeInterval = directionChangeInterval;

            this.random = new Random();
            this.timeSinceLastDirectionChange = 0;
            this.deviation = 0;
            this.angle = MathHelper.ToRadians(90);
        }

        public override Vector2 Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update time since last direction change
            timeSinceLastDirectionChange += deltaTime;

            // Check if it's time to change direction
            if (timeSinceLastDirectionChange > directionChangeInterval)
            {
                // Reset time since last direction change
                timeSinceLastDirectionChange = 0;

                // Generate a new deviation angle
                deviation = MathHelper.ToRadians(random.Next((int)minDeviation, (int)maxDeviation));

                // Randomly determine whether to move left or right
                int direction = random.Next(0, 2) == 0 ? -1 : 1;

                // Update angle based on deviation and direction
                angle = MathHelper.ToRadians(90) + deviation * direction;
            }

            // Calculate the velocity based on the angle and speed
            Vector2 velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * initialSpeed;

            // Update the position based on the velocity
            currentPosition += velocity * deltaTime;

            // Return the updated position
            //currentPosition = position;
            return currentPosition;
        }
    }
}
