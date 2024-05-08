using BulletHell.Controllers;
using BulletHell.Entity;
using BulletHell.Entity.AttackPattern;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Linq;

namespace BulletHell.Commands
{
    public class RemoveBulletOOB : ICommand
    {
        
        public void Execute()
        {
            List<Bullet> playerBullets = BulletController.Instance.PlayerBullets;
            List<Bullet> enemyBullets = BulletController.Instance.EnemyBullets.ToList();
            List<Bullet> specialBullets = BulletController.Instance.SpecialBullets;

            foreach (Bullet b in playerBullets)
            {
                // bullet leaves screen bounds
                if (!b.GetHitbox().Intersects(BulletController.Instance.Bounds))
                {
                    b.Die();
                }
            }

            foreach (Bullet b in enemyBullets)
            {
                // bullet leaves screen bounds
                if (!b.GetHitbox().Intersects(BulletController.Instance.Bounds))
                {
                    b.Die();
                }
            }

            foreach (Bullet b in specialBullets)
            {
                // bullet leaves screen bounds
                if (!b.GetHitbox().Intersects(BulletController.Instance.Bounds))
                {
                    RandomExplosionAttackPattern attack = new RandomExplosionAttackPattern(0, 2, new BulletRenderer(30, 47, 39, 1, "asteroid_bullet"));
                    Vector2 position = b.Pos;

                    if (position.X > 1920)
                    {
                        position.X = 1900;
                    }
                    if (position.X < 0)
                    {
                        position.X = 20;
                    }
                    if (position.Y > 1080)
                    {
                        position.Y = 1060;
                    }
                    if (position.Y < 0)
                    {
                        position.Y = 20;
                    }

                    
                    attack.Execute(null, position);

                    SoundEffectInstance explosionInstance = GameResources.PlanetExplosion.CreateInstance();
                    explosionInstance.IsLooped = false;
                    explosionInstance.Play();

                    b.Die();
                }
            }
        }
    }
}
