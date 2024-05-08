using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.Boss
{
    public abstract class ComponentEntity : AbstractEntity
    {
        public override void Die()
        {
            
        }

        public override void TakeDamage(int damage)
        {
            
        }

        public abstract void Add(ComponentEntity entity);
        public abstract void Remove(int index);
    }
}
