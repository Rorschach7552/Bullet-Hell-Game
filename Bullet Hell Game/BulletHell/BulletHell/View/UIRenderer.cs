using BulletHell.Controllers;
using BulletHell.Data;
using BulletHell.Entity;
using BulletHell.Entity.Boss;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.View
{
    public class UIRenderer : IObserver
    {
        private int lives;

        private int bombs;

        private int score;

        private bool levelComplete;

        private Texture2D ui;

        private SpriteFont font;

        private SpriteFont spaceFont;

        private static readonly UIRenderer instance = new();
        public int Lives { get => lives; set => lives = value; }
        public int Bombs { get => bombs; set => bombs = value; }
        public int Score { get => score; set => score = value; }
        public static UIRenderer Instance => instance;
        public SpriteFont Font { get => font; set => font = value; }
        public SpriteFont SpaceFont { get => spaceFont; set => spaceFont = value; }
        public Texture2D UI
        {
            get
            {
                return ui;
            }
            set
            {
                ui = value;
                ui.SetData(new Color[] { Color.DarkCyan });
            }
        }

        public UIRenderer()
        {
            PlayerConfig config = PlayerController.Instance.Config;
            this.lives = config.Lives;
            this.score = 0;
            this.bombs = config.Bombs;
            this.levelComplete = false;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            
            spriteBatch.DrawString(font, "Score: " + Score, new Vector2(1600, 1010), Color.Black);
            spriteBatch.DrawString(font, "Lives: " + Lives, new Vector2(102, 1010), Color.Black);
            spriteBatch.DrawString(font, "Bombs: " + Bombs, new Vector2(302, 1010), Color.Black);
            spriteBatch.DrawString(font, "Score: " + Score, new Vector2(1598,1010), Color.Orange);
            spriteBatch.DrawString(font, "Lives: " + Lives, new Vector2(100, 1010), Color.Orange);
            spriteBatch.DrawString(font, "Bombs: " + Bombs, new Vector2(300, 1010), Color.Orange);

            // game over.
            if (lives <= 0)
            {
                spriteBatch.DrawString(font, "Game Over ", new Vector2(900, 400), Color.Black);
                spriteBatch.DrawString(font, "Score: " + Score, new Vector2(900, 420), Color.Black);
                spriteBatch.DrawString(font, "Game Over ", new Vector2(900, 400), Color.Red);
                spriteBatch.DrawString(font, "Score: " + Score, new Vector2(900, 420), Color.Red);
            }
            
            // level complete.
            if (levelComplete)
            {
                spriteBatch.DrawString(font, "Level Complete!", new Vector2(900, 400), Color.Green);
                spriteBatch.DrawString(font, "Score: " + Score, new Vector2(900, 420), Color.Black);
                spriteBatch.DrawString(font, "Score: " + Score, new Vector2(900, 420), Color.Red);
            }
        }

        public void Update(AbstractObservable subject)
        {
            if (subject is Player player)
            {
                Lives = player.Health;
                Bombs = player.Bombs;
            }

            if (subject is Enemy enemy)
            {
                Score += enemy.Score;
            }

            if (subject is Boss boss && boss.FinalBoss)
            {
                levelComplete = true;
            }
        }
    }
}
