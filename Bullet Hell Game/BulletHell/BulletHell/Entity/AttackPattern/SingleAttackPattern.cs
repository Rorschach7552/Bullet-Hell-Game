using BulletHell.Controllers;
using BulletHell.Entity.Movement;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework;

namespace BulletHell.Entity.AttackPattern
{
    public class SingleAttackPattern : AbstractAttackPattern
    {
        public SingleAttackPattern(int attackInterval, BulletRenderer renderer) : base(attackInterval, renderer)
        {

        }

        public override void Execute(GameTime gameTime, Vector2 position)
        {
            if (Counter == attackInterval)
            {
                Vector2 playerPosition = PlayerController.Instance.Player.Pos;
                AbstractMovement movement = new PositionDirectedMovement(position, 1.0f, 0.1f, 4.0f, playerPosition);
                //AbstractMovement movement = new RandomRouteMovement(position, 100.0f, 20, 200, 3);
                BulletController.Instance.AddBullet(position, movement, renderer);
                NotifySubscribers();
                ResetCounter();
            }

            base.Execute(gameTime, position);
        }
    }
}
