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
    public class RemoveEnemyCommand : ICommand
    {
        public void Execute()
        {
            EnemyController controller = EnemyController.Instance;

            for (int i = 0; i < controller.Enemies.Count(); i++)
            {
                if (controller.Enemies.ElementAt(i).IsAlive == false)
                {
                    controller.Enemies.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < controller.Bosses.Count(); i++)
            {
                if (controller.Bosses.ElementAt(i).IsAlive == false)
                {
                    if (controller.Bosses.ElementAt(i).FinalBoss)
                    {
                        GameState.Instance.GameRunning = false;
                    }

                    controller.Bosses.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
