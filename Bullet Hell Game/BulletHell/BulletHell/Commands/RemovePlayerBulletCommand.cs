using BulletHell.Controllers;
using BulletHell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Commands
{
    public class RemovePlayerBulletCommand : ICommand
    {
        public void Execute()
        {
            List<Bullet> bullets = BulletController.Instance.PlayerBullets.ToList();

            foreach (Bullet bullet in bullets)
            {
                if (bullet.IsAlive == false)
                {
                    BulletController.Instance.PlayerBullets.Remove(bullet);
                }
            }
        }
    }
}
