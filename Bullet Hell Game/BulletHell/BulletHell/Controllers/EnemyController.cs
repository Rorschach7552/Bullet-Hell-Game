
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using BulletHell.Entity;
using BulletHell.Commands;
using BulletHell.Entity.Boss;
using System.Linq;
using BulletHell.View;

namespace BulletHell.Controllers
{
    public class EnemyController
    {
        private Rectangle bounds;

        private List<ICommand> tasks = new();

        /// <summary>
        /// List of all active enemies.
        /// </summary>
        private readonly List<Enemy> currentEnemies = new();

        private readonly List<Boss> currentBosses = new();

        /// <summary>
        /// singleton instance
        /// </summary>
        private static readonly EnemyController instance = new();

        /// <summary>
        /// Gets the current game entities.
        /// </summary>
        public List<Enemy> Enemies => currentEnemies;

        public List<Boss> Bosses => currentBosses;

        /// <summary>
        /// Gets the singleton's instance
        /// </summary>
        /// <returns>EnemyController instance</returns>
        public static EnemyController Instance => instance;

        public Rectangle Bounds { get => bounds; set => bounds = value; }

        /// <summary>
        /// private singleton constructor
        /// </summary>
        private EnemyController()
        {
            bounds = new Rectangle(0, 0, 1940, 1100);
            tasks.Add(new RemoveEnemyOOB());
            tasks.Add(new EnemyCollisionCommand());
            tasks.Add(new RemoveEnemyCommand());
        }

        public void AddEnemy(Enemy enemy)
        {
            enemy.Subscribe(UIRenderer.Instance);
            enemy.Subscribe(GameRenderer.Instance);
            enemy.AttackPattern.Subscribe(enemy.Renderer);
            currentEnemies.Add(enemy);
        }

        public void AddBoss(Boss boss)
        {
            for (int i = 0; i < boss.Phases.Count; i++)
            {
                BossPhase bossPhase = (BossPhase)boss.Phases[i];
                bossPhase.Subscribe(UIRenderer.Instance);
                bossPhase.Subscribe(GameRenderer.Instance);
                bossPhase.AttackPattern.Subscribe(bossPhase.Renderer);

                if (bossPhase.BulletSpawners != null)
                {
                    foreach (Spawner bulletSpawner in bossPhase.BulletSpawners)
                    {
                        bossPhase.Subscribe(bulletSpawner.Movement);
                    }
                }
            }

            boss.Subscribe(UIRenderer.Instance);
            currentBosses.Add(boss);
        }

        /// <summary>
        /// Moves all the active enemies.
        /// </summary>
        public void Update(GameTime gameTime)
        {

            foreach (ICommand task in tasks)
            {
                task.Execute();
            }

            foreach (Enemy enemy in currentEnemies)
            {
                // move
                enemy.Pos = enemy.Movement.Update(gameTime);
                enemy.Rotation = enemy.Movement.Rotation;
                // shoot
                enemy.AttackPattern.Execute(gameTime, enemy.Pos);
                enemy.Renderer?.UpdateAnimation(gameTime);
            }

            foreach (Boss boss in currentBosses) {
                ComponentEntity phase = boss.Phases.FirstOrDefault();
                if (phase != null)
                {
                    phase.Pos = phase.Movement.Update(gameTime);
                    phase.Rotation = phase.Movement.Rotation;
                    // shoot
                    phase.AttackPattern.Execute(gameTime, phase.Pos);

                    if (phase.BulletSpawners != null)
                    {
                        foreach (Spawner bulletSpawner in phase.BulletSpawners)
                        {
                            bulletSpawner.AttackPattern.Execute(gameTime, bulletSpawner.Position);
                            bulletSpawner.Position = bulletSpawner.Movement.Update(gameTime);
                            bulletSpawner.Rotation = bulletSpawner.Movement.Rotation;
                        }
                    }
                    phase.Renderer?.UpdateAnimation(gameTime);
                }
            }
        }

        /// <summary>
        /// Removes all enemies.
        /// </summary>
        public void ClearAll()
        {
            currentEnemies.Clear();
            currentBosses.Clear();
        }
        public bool DoesBossExist()
        {
            return false;
        }
    }
}
