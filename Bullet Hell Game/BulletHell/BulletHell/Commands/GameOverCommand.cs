using BulletHell.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Commands
{
    public class GameOverCommand : ICommand
    {
        public void Execute()
        {
            if (!PlayerController.Instance.Player.IsAlive)
            {
                GameState.Instance.GameOver = true;
                EnemyController.Instance.ClearAll();
                BulletController.Instance.ClearEnemyBullets();
            }
        }
    }
}
