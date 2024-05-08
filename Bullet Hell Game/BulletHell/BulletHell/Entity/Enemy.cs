using System.Diagnostics;

namespace BulletHell.Entity
{
    public class Enemy : AbstractEntity
    {
        protected int score;
        public int Score { get => score; set => score = value; }
        public override void Die()
        {
            IsAlive = false;
            // send the enemy score to the UI to increment the score.
            NotifySubscribers();
        }

        public override void OnPositionChanged()
        {
            
        }

        public override void TakeDamage(int damage)
        {
            this.Health -= damage;
        }
    }
}


