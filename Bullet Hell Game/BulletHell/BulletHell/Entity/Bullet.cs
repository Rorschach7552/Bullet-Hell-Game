using Microsoft.Xna.Framework;
using System;

namespace BulletHell.Entity
{
    public class Bullet : AbstractEntity
    {
        public override void Die()
        {
            IsAlive = false;
        }

        public override void OnPositionChanged()
        {
            
        }

        public override void TakeDamage(int damage)
        {
            
        }
    }
}
