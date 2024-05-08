using BulletHell.Controllers;
using BulletHell.Entity.Movement;
using BulletHell.Sprites;
using BulletHell.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BulletHell.Entity.AttackPattern
{
    public class SemiCircleAttackPattern : AbstractAttackPattern
    {
        public SemiCircleAttackPattern(int attackInterval, BulletRenderer renderer) : base(attackInterval, renderer)
        {
            
        }

        public override void Execute(GameTime gameTime, Vector2 position)
        {
            if (Counter == attackInterval)
            {
                for (int i = 90; i < 95; i++)
                {
                    float angle = MathHelper.ToRadians(i * 45);
                    Vector2 direction = Vector2.Transform(new Vector2(0, -1), Matrix.CreateRotationZ(angle));
                    AbstractMovement movement = new PositionDirectedMovement(position, 4.0f, -0.1f, 2.0f, position + direction * 100f);
                    BulletController.Instance.AddBullet(position, movement, renderer);
                }

                NotifySubscribers();

            }

            else if (Counter == attackInterval + 45)
            {
                for (int i = 90; i < 95; i++)
                {
                    float angle = MathHelper.ToRadians(i * 45);
                    Vector2 direction = Vector2.Transform(new Vector2(0, -1), Matrix.CreateRotationZ(angle));
                    AbstractMovement movement = new PositionDirectedMovement(position, 4.0f, -0.1f, 2.0f, position + direction * 100f);
                    BulletController.Instance.AddBullet(position, movement, renderer);
                }
                ResetCounter();
            }

            base.Execute(gameTime, position);
        }
    }
}
