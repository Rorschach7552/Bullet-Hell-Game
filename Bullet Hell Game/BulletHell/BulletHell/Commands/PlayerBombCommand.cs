using Microsoft.Xna.Framework.Input;
using BulletHell.Controllers;
using BulletHell.Entity;
using BulletHell.Entity.Boss;
using System.Diagnostics;
using BulletHell.Sprites;
using Microsoft.Xna.Framework.Audio;
using BulletHell.View;

namespace BulletHell.Commands
{
    public class PlayerBombCommand : ICommand
    {
        private int count = 0;
        Player player;
        public void Execute()
        {
            player = PlayerController.Instance.Player;

            if (Keyboard.GetState().IsKeyDown(Keys.Q) && count == 100 && player.Bombs > 0)
            {
                SoundEffectInstance bombInstance = GameResources.BombSound.CreateInstance();
                bombInstance.Volume = 0.8f;
                bombInstance.IsLooped = false;
                bombInstance.Play();


                GameRenderer gameRenderer = GameRenderer.Instance;
                gameRenderer.AddEffect(new ScreenFlashEffect("flash"));

                BulletController.Instance.ClearEnemyBullets();

                foreach (Enemy e in EnemyController.Instance.Enemies)
                {
                    e.TakeDamage(50);
                }

                foreach (Boss boss in EnemyController.Instance.Bosses)
                {
                    boss.TakeDamage(50);
                }

                player.Bombs--;
                count = 0;
            }

            if (count < 100)
            {
                count++;
            }
        }
    }
}
