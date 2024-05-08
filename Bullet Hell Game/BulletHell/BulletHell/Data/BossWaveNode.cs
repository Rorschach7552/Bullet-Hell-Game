using BulletHell.Controllers;
using BulletHell.Entity.Boss;

namespace BulletHell.Data
{
    public class BossWaveNode : IWaveNode
    {
        public int time;
        public Boss boss;
        public BossWaveNode(Boss boss, int time)
        {
            this.time = time;
            this.boss = boss;
        }
        public int GetTime()
        {
            return time;
        }

        public void Spawn()
        {
            EnemyController.Instance.AddBoss(boss);
        }
    }
}
