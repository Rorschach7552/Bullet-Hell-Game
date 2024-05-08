using Microsoft.Xna.Framework;

namespace BulletHell.Entity
{
    public class Player : AbstractEntity
    {

        private int bombs;
        public int Bombs { get => bombs;
            set
            {
                bombs = value;
                NotifySubscribers();
            }
        }

        private bool invulnerable;
        public bool Invulnerable { get => invulnerable; set => invulnerable = value; }

        private bool isShooting;
        public bool IsShooting {
            get => isShooting; 
            set
            {
                if (value == isShooting)
                {
                    return;
                }
                else
                {
                    isShooting = value;
                    NotifySubscribers();
                }
            }
        }

        public Player() : base()
        {
            this.invulnerable = false;
            this.isShooting = false;
        }
        public override void Die()
        {
            IsAlive = false;
            NotifySubscribers();
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
            this.Invulnerable = true;
            NotifySubscribers();
        }
        public new Rectangle GetHitbox()
        {
            int size = 96 / 6;
            return new Rectangle((int)position.X + size + 24, (int)position.Y + size + 33, size, size);
        }

        public override void OnPositionChanged()
        {
            
        }
    }
}
