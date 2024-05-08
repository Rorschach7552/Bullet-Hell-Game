using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.Boss
{
    public class BossPhase : ComponentEntity
    {
        protected int score;
        public int Score { get => score; set => score = value; }
        public override void Add(ComponentEntity entity)
        {
            
        }

        public override void Remove(int index)
        {
            
        }

        public override void Die()
        {
            IsAlive = false;
            // send the enemy score to the UI to increment the score.
            NotifySubscribers();
        }

        public override void TakeDamage(int damage)
        {
            this.Health -= damage;
        }

        public override void OnPositionChanged()
        {
            NotifySubscribers();
        }
    }
}
