using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.Movement
{
    public class StaticMovement : AbstractMovement
    {
        public StaticMovement(Vector2 initialPosition) : base(initialPosition, 0, 0, 0, 0, initialPosition)
        {

        }

        public override Vector2 Update(GameTime gameTime)
        {
            return currentPosition;
        }
    }
}
