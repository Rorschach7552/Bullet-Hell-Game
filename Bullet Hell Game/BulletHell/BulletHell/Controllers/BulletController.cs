using System.Collections.Generic;
using System.Diagnostics;
using BulletHell.Commands;
using BulletHell.Creators;
using BulletHell.Entity;
using BulletHell.Entity.Movement;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Controllers
{
    public class BulletController
    {
        /// <summary>
        /// List of all active bullets.
        /// </summary>
        private readonly List<Bullet> enemyBullets = new();

        private List<Bullet> playerBullets = new();

        private List<Bullet> specialBullets = new();

        private List<ICommand> tasks = new();

        private Rectangle bounds;

        /// <summary>
        /// singletone instance.
        /// </summary>
        private static readonly BulletController instance = new();

        /// <summary>
        /// Gets the singletone instance.
        /// </summary>
        /// <returns>BulletController instance.</returns>
        public static BulletController Instance => instance;

        /// <summary>
        /// Gets the bullets in the game.
        /// </summary>
        public List<Bullet> EnemyBullets { get => enemyBullets; }

        public List<Bullet> PlayerBullets { get => playerBullets;}

        public List<Bullet> SpecialBullets { get => specialBullets; }

        public Rectangle Bounds { get => bounds; set => bounds = value; }

        /// <summary>
        /// Singleton private constructor.
        /// </summary>
        private BulletController() 
        {
            bounds = new Rectangle(0, 0, 1940, 1100);
            tasks.Add(new PlayerCollisionCommand());
            tasks.Add(new BulletCollisionCommand());
            tasks.Add(new RemoveBulletCommand());
            tasks.Add(new RemoveBulletOOB());
        }

        public void AddPlayerBullet(Vector2 initialPosition, AbstractMovement movement)
        {
            BulletBuilder playerBulletBuilder = new BulletBuilder(movement, new BulletRenderer(60, 32, 32, 4, "player_ship_bullet"), initialPosition);
            EntityBuilderDirector builderDirector = new EntityBuilderDirector(playerBulletBuilder);
            builderDirector.Construct();
            playerBullets.Add(playerBulletBuilder.GetResult());
        }

        public void AddBullet(Vector2 initialPosition, AbstractMovement movement, BulletRenderer renderer)
        {
            BulletBuilder bulletBuilder = new BulletBuilder(movement, renderer, initialPosition);
            EntityBuilderDirector builderDirector = new EntityBuilderDirector(bulletBuilder);
            builderDirector.Construct();
            enemyBullets.Add(bulletBuilder.GetResult());
        }

        public void AddSpecialBullet(Vector2 initialPosition, AbstractMovement movement, BulletRenderer renderer)
        {
            BulletBuilder bulletBuilder = new BulletBuilder(movement, renderer, initialPosition);
            EntityBuilderDirector builderDirector = new EntityBuilderDirector(bulletBuilder);
            builderDirector.Construct();
            specialBullets.Add(bulletBuilder.GetResult());
        }

        /// <summary>
        /// Update bullets.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            foreach (ICommand task in tasks)
            {
                task.Execute();
            }

            foreach (Bullet bullet in enemyBullets)
            {
                // move bullets.
                bullet.Pos = bullet.Movement.Update(gameTime);

                // rotate bullets.
                bullet.Rotation = bullet.Movement.Rotation;

                bullet.Renderer.UpdateAnimation(gameTime);
            }

            foreach (Bullet bullet in specialBullets)
            {
                // move bullets.
                bullet.Pos = bullet.Movement.Update(gameTime);

                // rotate bullets.
                bullet.Rotation = bullet.Movement.Rotation;

                bullet.Renderer.UpdateAnimation(gameTime);
            }

            foreach (Bullet bullet in playerBullets)
            {
                // move bullets.
                bullet.Pos = bullet.Movement.Update(gameTime);

                // rotate bullets.
                bullet.Rotation = bullet.Movement.Rotation;

                bullet.Renderer.UpdateAnimation(gameTime);
            }
        }

        public void ClearEnemyBullets()
        {
            enemyBullets.Clear();
        }
    }
}
