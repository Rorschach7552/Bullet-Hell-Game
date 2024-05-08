using BulletHell.Controllers;
using BulletHell.Entity.Movement;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Entity.AttackPattern
{
    public class TripodAttackPattern : AbstractAttackPattern
    {
        private bool active;

        public TripodAttackPattern(int attackInterval, BulletRenderer renderer) : base(attackInterval, renderer)
        {
            active = true;
        }

        public override void Execute(GameTime gameTime, Vector2 position)
        {
            Vector2 playerPosition = PlayerController.Instance.Player.Pos;

            if (Counter == attackInterval)
            {
                active = true;
                NotifySubscribers();
                ResetCounter();
            }

            if (active)
            {
                Vector2 direction1 = new Vector2(0, 1);
                Vector2 direction2 = new Vector2(-0.866f, -0.5f);
                Vector2 direction3 = new Vector2(0.866f, -0.5f);

                PositionDirectedMovement movement1 = new PositionDirectedMovement(position, 7.0f, 0.0f, 7.0f, playerPosition + direction1 * 100f);
                PositionDirectedMovement movement2 = new PositionDirectedMovement(position, 7.0f, 0.0f, 7.0f, position + direction2 * 100f);
                PositionDirectedMovement movement3 = new PositionDirectedMovement(position, 7.0f, 0.0f, 7.0f, position + direction3 * 100f);

                BulletController.Instance.AddBullet(position, movement1, renderer);
                BulletController.Instance.AddBullet(position, movement2, renderer);
                BulletController.Instance.AddBullet(position, movement3, renderer);

                if (Counter == attackInterval / 2)
                {
                    active = false;
                    ResetCounter();
                }
            }

            base.Execute(gameTime, position);
        }
    }
}
