using BulletHell.Controllers;
using BulletHell.Entity;

namespace BulletHell.Data
{
    public class WaveNode : IWaveNode
    {
        public int time;
        public Enemy enemy;
        public WaveNode(Enemy enemy, int time)
        {
            this.time = time;
            this.enemy = enemy;
        }

        public int GetTime()
        {
            return time;
        }

        public void Spawn()
        {
            EnemyController.Instance.AddEnemy(enemy);
        }
    }
}
