using BulletHell.Commands;
using BulletHell.Controllers;
using BulletHell.Entity;
using BulletHell.Entity.Boss;
using BulletHell.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.View
{
    public class GameRenderer : IObserver
    {
        private static readonly GameRenderer instance = new();
        public static GameRenderer Instance => instance;

        private List<AbstractEffect> effects = new(); // change this to generic "effects" maybe
        private GameRenderer()
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach (AbstractEffect e in effects)
            {
                e.UpdateAnimation(gameTime);
            }
        }
        public void RenderGame(SpriteBatch spriteBatch)
        {
            if (!GameState.Instance.GameOver)
            {
                foreach (Background bg in BackgroundController.Instance.Backgrounds)
                {
                    BackgroundRenderer.Render(spriteBatch, bg);
                }

                foreach (AbstractEffect r in effects)
                {
                    r.Animate(spriteBatch);
                }

                PlayerController playerController = PlayerController.Instance;
                Player player = playerController.Player;

                player.Renderer.Animate(spriteBatch, player.Pos, player.Rotation);

                foreach (Enemy e in EnemyController.Instance.Enemies)
                {
                    e.Renderer.Animate(spriteBatch, e.Pos, e.Rotation);
                }

                foreach (Boss boss in EnemyController.Instance.Bosses)
                {
                    ComponentEntity phase = boss.Phases.FirstOrDefault();
                    if (phase != null)
                    {
                        phase.Renderer.Animate(spriteBatch, phase.Pos, phase.Rotation);
                    }
                }

                BulletController bulletController = BulletController.Instance;

                foreach (Bullet b in bulletController.EnemyBullets)
                {
                    b.Renderer.Animate(spriteBatch, b.Pos, b.Rotation);
                }

                foreach (Bullet b in bulletController.SpecialBullets)
                {
                    b.Renderer.Animate(spriteBatch, b.Pos, b.Rotation);
                }

                foreach (Bullet b in bulletController.PlayerBullets)
                {
                    b.Renderer.Animate(spriteBatch, b.Pos, b.Rotation);
                }
            }

            UIRenderer.Instance.Render(spriteBatch);
        }

        public void AddEffect(AbstractEffect effect)
        {
            effects.Add(effect);
        }

        public void Update(AbstractObservable subject)
        {
            if (subject is AbstractEntity e && e.IsAlive == false)
            {
                AddEffect(new DeathEffect(80, e.Renderer.SizeX, e.Renderer.SpriteSheet, e.Pos, e.Rotation));
            }
        }
    }
}
