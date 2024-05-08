using BulletHell.Commands;
using BulletHell.Controllers;
using BulletHell.Data;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Linq;

namespace BulletHell
{
    public class BulletHell : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private readonly PlayerController playerController;
        private readonly EnemyController enemyController;
        private readonly BulletController bulletController;
        private readonly BackgroundController backgroundController;
        private readonly GameState gameState;
        private readonly UIRenderer uiRenderer;

        private List<Level> levels;

        public BulletHell()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            playerController = PlayerController.Instance;
            enemyController = EnemyController.Instance;
            bulletController = BulletController.Instance;
            backgroundController = BackgroundController.Instance;
            gameState = GameState.Instance;
            uiRenderer = UIRenderer.Instance;
            SpriteFlyweightFactory.Instance.SetContent(this.Content);
            levels = new();
        }

        protected override void Initialize()
        {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();

            gameState.GameRunning = true; // start game

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // init UI Renderer
            uiRenderer.UI = new Texture2D(GraphicsDevice, 1, 1);
            uiRenderer.Font = Content.Load<SpriteFont>("GameFont");
            GameResources.ColdNebula = Content.Load<Texture2D>("background/background_stars_1");
            GameResources.Stars = Content.Load<Texture2D>("background/background_stars_2");
            GameResources.BigStars = Content.Load<Texture2D>("background/background_stars_3");
            GameResources.ShootingSound = Content.Load<SoundEffect>("PlayerShoot");
            GameResources.PlanetExplosion = Content.Load<SoundEffect>("PlanetExplosion");
            GameResources.Tiktok = Content.Load<SoundEffect>("TikTok");
            GameResources.BombSound = Content.Load<SoundEffect>("Bomb");

            // add backgrounds.
            backgroundController.AddBackground(GameResources.ColdNebula, new Vector2(0, 100));
            backgroundController.AddBackground(GameResources.Stars, new Vector2(0, 50));
            backgroundController.AddBackground(GameResources.BigStars, new Vector2(0, 20));

            // init player at middle of screen.
            playerController.InitPlayer(graphics);

            playerController.Player.Subscribe(uiRenderer);

            SoundEffect bgMusic = Content.Load<SoundEffect>("spaceship-ambience-with-effects-21420");
            SoundEffectInstance song1Instance = bgMusic.CreateInstance();
            song1Instance.Volume = 0.8f;
            song1Instance.IsLooped = true;
            song1Instance.Play();

            // create level
            Level levelOne = LevelInitializer.CreateLevelOne();
            LevelSerializer.SerializeLevel(levelOne); // serialize level to create initial json
            //Level levelOne = LevelDeserializer.DeserializeLevel(); // create the level object from json

            levels.Add(levelOne);

        }
        protected override void Update(GameTime gameTime)
        {
            // esc to exit game.
            if (ExitCommand.IsExit()) {
                Exit();
            }

            var kstate = Keyboard.GetState();

            if (gameState.GameRunning)
            {
                // Update background.
                backgroundController.Update(gameTime, GraphicsDevice.Viewport);

                // Update enemies.
                enemyController.Update(gameTime);

                // Update bullets.
                bulletController.Update(gameTime);

                // Enemy spawning
                levels.First().UpdateLevel(gameTime);
            }

            // Update the player.
            playerController.UpdatePlayer(kstate, gameTime);

            // Update animations
            GameRenderer.Instance.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            GameRenderer.Instance.RenderGame(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}