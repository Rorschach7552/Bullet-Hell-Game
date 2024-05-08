using BulletHell.Controllers;
using BulletHell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Commands
{
    public class RemoveEnemyOOB : ICommand
    {
        public void Execute()
        {
            List<Enemy> enemies = EnemyController.Instance.Enemies;

            foreach (Enemy enemy in enemies)
            {
                // enemy leaves screen bounds
                if (!enemy.GetHitbox().Intersects(EnemyController.Instance.Bounds))
                {
                    enemy.TakeDamage(100);
                }
            }
        }
    }
}
