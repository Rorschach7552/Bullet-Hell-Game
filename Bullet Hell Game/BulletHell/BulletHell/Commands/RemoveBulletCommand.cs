using BulletHell.Controllers;
using BulletHell.Entity;
using System.Collections.Generic;
using System.Linq;

namespace BulletHell.Commands
{
    internal class RemoveBulletCommand : ICommand
    {
        public void Execute()
        {
            for (int i = 0; i < BulletController.Instance.EnemyBullets.Count(); i++)
            {
                if (BulletController.Instance.EnemyBullets.ElementAt(i).IsAlive == false)
                {
                    BulletController.Instance.EnemyBullets.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < BulletController.Instance.SpecialBullets.Count(); i++)
            {
                if (BulletController.Instance.SpecialBullets.ElementAt(i).IsAlive == false)
                {
                    BulletController.Instance.SpecialBullets.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
