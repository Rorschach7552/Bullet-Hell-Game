using BulletHell.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Commands
{
    internal abstract class AbstractSpawn
    {
        public abstract void spawn(EnemyController enemyController);

    }
}
