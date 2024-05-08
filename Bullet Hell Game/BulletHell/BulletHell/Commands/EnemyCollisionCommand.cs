using BulletHell.Controllers;
using BulletHell.Entity;
using BulletHell.Entity.Boss;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Commands
{
    public class EnemyCollisionCommand : ICommand
    {
        public void Execute()
        {
            List<Bullet> playerBullets = BulletController.Instance.PlayerBullets;
            List<Enemy> enemies = EnemyController.Instance.Enemies;


            // check for bullet hits
            foreach (Bullet bullet in playerBullets)
            {
                foreach (Enemy enemy in enemies)
                {
                    // enemy hit by bullet
                    if (enemy.GetHitbox().Intersects(bullet.GetHitbox()))
                    {
                        enemy.TakeDamage(1);
                        bullet.IsAlive = false;
                    }
                }

                foreach (Boss boss in EnemyController.Instance.Bosses)
                {
                    ComponentEntity phase = boss.Phases.FirstOrDefault();

                    if (phase != null && phase.GetHitbox().Intersects(bullet.GetHitbox()))
                    {
                        boss.TakeDamage(1);
                        bullet.IsAlive = false;
                    }
                }
            }
        }
    }
}
