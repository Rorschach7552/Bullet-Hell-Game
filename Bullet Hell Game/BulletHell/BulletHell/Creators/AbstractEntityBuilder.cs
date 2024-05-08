using BulletHell.Entity;
using BulletHell.Entity.AttackPattern;
using BulletHell.Entity.Movement;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Creators
{
    public abstract class AbstractEntityBuilder
    {
        // configuration
        public AbstractMovement movement;
        public AbstractAttackPattern attackPattern;
        public Vector2 origin;
        public int health;
        public AbstractEntityRenderer renderer;

        // health
        public abstract void BuildHealth();

        // renderer
        public abstract void BuildRenderer();
        
        //movement .
        public abstract void BuildMovement();

        //attackpattern .
        public abstract void BuildAttackPattern();

        //score .
        public abstract void BuildScore();

        //origin .
        public abstract void BuildOrigin();

    }
}
