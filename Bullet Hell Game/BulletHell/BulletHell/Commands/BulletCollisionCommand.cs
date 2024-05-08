using BulletHell.Controllers;
using BulletHell.Entity;
using Microsoft.Xna.Framework;
using System.Linq;

namespace BulletHell.Commands
{
    public class BulletCollisionCommand : ICommand
    {
        public void Execute()
        {
            foreach (Bullet specialBullet in BulletController.Instance.SpecialBullets)
            {
                foreach (Bullet bullet in BulletController.Instance.EnemyBullets)
                {
                    Rectangle hitbox = specialBullet.GetHitbox();

                    if (hitbox.Intersects(bullet.GetHitbox()))
                    {
                        bullet.Die();
                    }
                }
            }
        }
    }
}
