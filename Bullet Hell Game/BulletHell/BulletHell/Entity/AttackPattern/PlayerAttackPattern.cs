using BulletHell.Controllers;
using BulletHell.Entity.Movement;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.AttackPattern
{
    public class PlayerAttackPattern : AbstractAttackPattern
    {
        public PlayerAttackPattern(int attackInterval, BulletRenderer renderer) : base(attackInterval, renderer)
        {

        }
        public override void Execute(GameTime gameTime, Vector2 position)
        {
            if (Counter == attackInterval)
            {
                SoundEffectInstance shootingInstance = GameResources.ShootingSound.CreateInstance();
                shootingInstance.Volume = 0.3f;
                shootingInstance.IsLooped = false;
                shootingInstance.Play();
                
                Vector2 leftBulletPos = position;
                leftBulletPos.X += 20f;
                Vector2 rightBulletPos = position;
                rightBulletPos.X -= 20f;

                AbstractMovement movementL = new AxialMovement(leftBulletPos, 1.0f, new Vector2(0, -1), 0.3f, 6.0f);
                BulletController.Instance.AddPlayerBullet(position, movementL);

                AbstractMovement movementR = new AxialMovement(rightBulletPos, 1.0f, new Vector2(0, -1), 0.3f, 6.0f);
                BulletController.Instance.AddPlayerBullet(position, movementR);
                ResetCounter();
            }
        }
    }
}
