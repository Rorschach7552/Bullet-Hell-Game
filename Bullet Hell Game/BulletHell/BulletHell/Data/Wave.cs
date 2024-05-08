using BulletHell.Commands;
using BulletHell.Controllers;
using BulletHell.Entity;
using BulletHell.Entity.AttackPattern;
using BulletHell.Entity.Boss;
using BulletHell.Entity.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Data
{
    public class Wave
    {
        public Wave()
        {

        }

        public List<IWaveNode> enemies = new List<IWaveNode>();

        public void AddEnemy(Enemy enemy, int time)
        {
            enemies.Add(new WaveNode(enemy, time));
        }

        public void AddBoss(Boss boss, int time)
        {
            enemies.Add(new BossWaveNode(boss, time));
        }

        public void Itterate(GameTime gameTime)
        {
            foreach (IWaveNode node in enemies)
            {
                if (WaveTime(node.GetTime(), gameTime))
                {
                    node.Spawn();
                }
            }
        }

        private static bool WaveTime(double time, GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalSeconds > time && gameTime.TotalGameTime.TotalSeconds < time + .2 && gameTime.TotalGameTime.Milliseconds == 100)
            {
                return true;
            }
            return false;
        }
    }
}
