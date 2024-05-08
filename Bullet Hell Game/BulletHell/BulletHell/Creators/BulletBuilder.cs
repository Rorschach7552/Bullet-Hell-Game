using BulletHell.Entity.AttackPattern;
using BulletHell.Entity.Movement;
using BulletHell.Entity;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using BulletHell.View;
using BulletHell.Controllers;

namespace BulletHell.Creators
{
    public class BulletBuilder : AbstractEntityBuilder
    {
        private Bullet bullet;

        public BulletBuilder(AbstractMovement movement, AbstractEntityRenderer renderer, Vector2 origin)
        {
            this.movement = movement;
            this.origin = origin;
            this.renderer = renderer;

            bullet = new Bullet();
        }
        public override void BuildHealth()
        {
            // not needed for bullet.
        }

        public override void BuildRenderer()
        {
            bullet.Renderer = renderer;
        }

        public override void BuildMovement()
        {
            bullet.Movement = (AbstractMovement)movement.Clone();
        }

        public override void BuildAttackPattern()
        {
            // not needed for bullet
        }

        public override void BuildScore()
        {
            // not needed for bullet
        }

        public override void BuildOrigin()
        {
            bullet.Pos = origin;

        }

        public Bullet GetResult()
        {
            return bullet;
        }
    }
}
