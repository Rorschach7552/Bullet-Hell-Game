using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.Movement
{
    public class VShapedMovement : AbstractMovement
    {
        private bool movingDown;
        private bool standingStill;
        private bool left;
        private float stopTime;
        private float velocity;
        private float initialY;
        private float stopY;

        public float InitalY { get => initialY; set => initialY = value; }
        public float StopY { get => stopY; set => stopY = value; }
        public float Velocity { get => velocity; set => velocity = value; }
        public float StopTime { get => stopTime; set => stopTime = value; }
        public bool Left { get => left; set => left = value; }

        [JsonConstructor]
        public VShapedMovement(Vector2 origin, float speed, float stopY, float stopTime, bool direction) : base(origin, speed, 0.0f, 0.0f, 0.0f, Vector2.Zero)
        {
            movingDown = true;
            standingStill = false;
            this.left = direction;
            this.stopTime = stopTime;
            velocity = initialSpeed;
            initialY = origin.Y;
            this.stopY = stopY;
        }

        public override Vector2 Update(GameTime gameTime)
        {
            if (movingDown)
            {
                currentPosition.X += left ? initialSpeed : initialSpeed * -1;
                currentPosition.Y += velocity;
                rotation = (float)Math.Atan2(-stopY, currentPosition.X);
                if (currentPosition.Y >= initialY + stopY)
                {
                    movingDown = false;
                    standingStill = true;
                }
            }
            else if (standingStill)
            {
                rotation = 0;
                stopTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (stopTime <= 0.0f)
                {
                    standingStill = false;
                    velocity = -initialSpeed;
                }
            }
            else
            {
                rotation = (float)Math.Atan2(stopY, currentPosition.X);
                currentPosition.X += left ? initialSpeed : initialSpeed * -1;
                currentPosition.Y += velocity;

            }

            return currentPosition;
        }
    }
}
