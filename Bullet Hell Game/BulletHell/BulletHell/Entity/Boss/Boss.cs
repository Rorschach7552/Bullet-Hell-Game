using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.Boss
{
    public class Boss : ComponentEntity
    {
        private List<ComponentEntity> phases = new();

        public List<ComponentEntity> Phases => phases;

        private bool finalBoss;
        public bool FinalBoss { get => finalBoss; set => finalBoss = value; }

        public Boss()
        {
            this.finalBoss = false;
            this.IsAlive = true;
        }

        public override void Add(ComponentEntity entity)
        {
            phases.Add(entity);
        }

        public override void Remove(int index)
        {
            phases.RemoveAt(index);
        }

        public override void TakeDamage(int damage)
        {
            if (phases.Count > 0)
            {
                if (phases.First().IsAlive)
                {
                    phases.First().TakeDamage(damage);
                }

                if (!phases.First().IsAlive)
                {
                    phases.RemoveAt(0);
                    if (phases.Count < 1)
                    {
                        Die();
                    }
                }
            }
        }
        public override void Die()
        {
            IsAlive = false;
            NotifySubscribers();
        }

        public bool HasPhases()
        {
            return phases.Count() > 0;
        }

        public override void OnPositionChanged()
        {
            
        }
    }
}
