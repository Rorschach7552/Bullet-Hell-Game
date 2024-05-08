using BulletHell.Controllers;
using BulletHell.Entity;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Commands
{
    public class PlayerCollisionCommand : ICommand
    {
        public void Execute()
        {
            if (PlayerController.Instance.Player.Invulnerable == false)
            {
                foreach (Bullet bullet in BulletController.Instance.EnemyBullets)
                {
                    if (bullet.GetHitbox().Intersects(PlayerController.Instance.Player.GetHitbox()))
                    {
                        PlayerController.Instance.Player.TakeDamage(1);
                        BulletController.Instance.ClearEnemyBullets();
                        return;
                    }
                }
            }
        }
    }
}
