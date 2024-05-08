using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.Movement
{
    public class TriangleMovement : AbstractMovement
    {
        private Vector2 point1;
        private Vector2 point2;
        private Vector2 point3;
        private int currentPoint = 1;
        private float speed = 5.0f;
        private float timeSinceLastPointChange = 0.0f;

        public TriangleMovement(Vector2 startPosition, float speed) : base(startPosition, speed, 0.0f, 0.0f, 0.0f, Vector2.Zero)
        {
            point1 = new Vector2(900, 50);
            point2 = new Vector2(560, 540);
            point3 = new Vector2(1360, 540);
        }

        public override Vector2 Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            timeSinceLastPointChange += time;

            if (timeSinceLastPointChange >= 5.0)
            {
                timeSinceLastPointChange = 0.0f;

                currentPoint++;

                if (currentPoint > 3)
                {
                    currentPoint = 1;
                }
            }

            Vector2 newPosition;
            switch (currentPoint)
            {
                case 1:
                    newPosition = Vector2.Lerp(point1, point2, 0.3f);
                    break;
                case 2:
                    newPosition = Vector2.Lerp(point2, point3, 0.3f);
                    break;
                default:
                    newPosition = Vector2.Lerp(point3, point1, 0.3f);
                    break;
            }

            Vector2 velocity = (newPosition - currentPosition) * speed;
            currentPosition += velocity * time;
            return currentPosition;
        }
    }





}
