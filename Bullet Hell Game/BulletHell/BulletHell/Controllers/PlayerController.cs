using BulletHell.Commands;
using BulletHell.Creators;
using BulletHell.Data;
using BulletHell.Entity;
using BulletHell.Entity.AttackPattern;
using BulletHell.Entity.Movement;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BulletHell.Controllers
{
    /// <summary>
    /// Class for handling player operations.
    /// </summary>
    public class PlayerController
    {
        /// <summary>
        /// The active game player.
        /// </summary>
        private Player player;

        private PlayerConfig config;

        private List<ICommand> tasks = new();

        public Rectangle bounds;

        /// <summary>
        /// Singleton instance instantiation.
        /// </summary>
        private static readonly PlayerController instance = new();

        public Player Player => player;
        public static PlayerController Instance => instance;

        public PlayerConfig Config => config;

        /// <summary>
        /// Singleton private constructor.
        /// </summary>
        private PlayerController()
        {
            bounds = new Rectangle(10, 400, 1920-20, 1080-500);
            config = PlayerConfig.Deserialize();
            tasks.Add(new PauseCommand());
            tasks.Add(new GameOverCommand());
            tasks.Add(new UpdatePlayerInvulnerable());
            tasks.Add(new RemovePlayerBulletCommand());
            tasks.Add(new PlayerBombCommand());
        }

        /// <summary>
        /// Initializes a new player.
        /// </summary>
        public void InitPlayer(GraphicsDeviceManager graphics)
        {
            Vector2 origin = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            PlayerBuilder builder = new PlayerBuilder(config.Lives, config.Bombs, new AxialMovement(origin, config.Speed, Vector2.Zero), new PlayerAttackPattern(config.AttackInterval, new BulletRenderer(60, 32, 32, 4, "player_ship_bullet")), new PlayerRenderer(30, 96, 96, "player_ship_sheet"), origin);

            EntityBuilderDirector director = new EntityBuilderDirector(builder);
            director.Construct();

            this.player = builder.GetResult();
        }

        /// <summary>
        /// Update the player according to the keyboard state.
        /// </summary>
        /// <param name="kstate">keyboard state.</param>
        /// <param name="elaspedSeconds">total elasped gametime.</param>
        /// <param name="graphicsManager">graphics manager.</param>
        public void UpdatePlayer(KeyboardState kstate, GameTime gameTime)
        {
            foreach (ICommand task in tasks)
            {
                task.Execute();
            }

            if (!GameState.Instance.PauseState)
            {
                float speed = player.Movement.InitialSpeed;
                Vector2 direction = new Vector2(0, 0);
                Vector2 playerPos = player.Pos;

                // if slowdown key is pressed, reduce speed.
                if (kstate.IsKeyDown(config.SlowDown))
                {
                    speed /= 2;
                }

                if (kstate.IsKeyDown(config.Up))
                {
                    if (bounds.Contains(bounds.X + 1, playerPos.Y - speed))
                    {
                        direction.Y -= speed;
                    }
                }

                if (kstate.IsKeyDown(config.Down))
                {
                    if (bounds.Contains(bounds.X + 1, playerPos.Y + speed))
                    {
                        direction.Y += speed;
                    }
                }

                if (kstate.IsKeyDown(config.Left))
                {
                    if (bounds.Contains(playerPos.X - speed, bounds.Y + 1))
                    {
                        direction.X -= speed;
                    }
                }

                if (kstate.IsKeyDown(config.Right))
                {
                    if (bounds.Contains(playerPos.X + speed, bounds.Y + 1))
                    {
                        direction.X += speed;
                    }
                }

                if (player.Movement is AxialMovement playerMovement)
                {
                    playerMovement.TargetPosition = direction;
                    player.Pos = player.Movement.Update(gameTime);
                }

                player.AttackPattern.Counter++;

                // check for shooting

                if (kstate.IsKeyDown(config.Shoot))
                {

                    player.AttackPattern.Execute(gameTime, player.Pos);
                    player.IsShooting = true;
                }
                else
                {
                    player.IsShooting = false;
                }

                player.Renderer.UpdateAnimation(gameTime);
            }
        }
    }
}
