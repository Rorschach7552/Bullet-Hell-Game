using BulletHell.Entity.Boss;

namespace BulletHell.Creators
{
    public class BossFactory
    {
        public Boss CreateBoss()
        {
            return new Boss();
        }
    }
}
