using BulletHell.Controllers;
using BulletHell.Entity.Movement;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Entity.AttackPattern
{
    public class TriangleAttackPattern : AbstractAttackPattern
    {
        public TriangleAttackPattern(int attackInterval, BulletRenderer renderer) : base(attackInterval, renderer)
        {
            
        }

        public override void Execute(GameTime gameTime, Vector2 position)
        {
            Vector2 playerPosition = PlayerController.Instance.Player.Pos;

            if (Counter == attackInterval)
            {
                AbstractMovement movement = new PositionDirectedMovement(position, 7.0f, -0.1f, 2.0f, playerPosition);
                BulletController.Instance.AddBullet(position, movement, renderer);
                NotifySubscribers();
            }
            else if (Counter == attackInterval + 15)
            {
                AbstractMovement movement1 = new PositionDirectedMovement(position + new Vector2(-20.0f, 0), 7.0f, -0.15f, 2.0f, playerPosition);
                BulletController.Instance.AddBullet(position, movement1, renderer);

                AbstractMovement movement2 = new PositionDirectedMovement(position + new Vector2(20.0f, 0), 7.0f, -0.15f, 2.0f, playerPosition);
                BulletController.Instance.AddBullet(position, movement2, renderer);
            }
            else if (Counter == attackInterval + 30)
            {
                AbstractMovement movement1 = new PositionDirectedMovement(position + new Vector2(-25.0f, 0), 7.0f, -0.3f, 2.0f, playerPosition);
                BulletController.Instance.AddBullet(position, movement1, renderer);

                AbstractMovement movement2 = new PositionDirectedMovement(position, 7.0f, -0.3f, 2.0f, playerPosition);
                BulletController.Instance.AddBullet(position, movement2, renderer);

                AbstractMovement movement3 = new PositionDirectedMovement(position + new Vector2(25.0f, 0),7.0f, -0.3f, 2.0f, playerPosition);
                BulletController.Instance.AddBullet(position, movement3, renderer);

                ResetCounter();
            }

            base.Execute(gameTime, position);
        }
    }
}
