using BulletHell.View;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;

namespace BulletHell.Entity.AttackPattern
{
    public abstract class AbstractAttackPattern : AbstractObservable, ICloneable
    {
        protected int attackInterval;
        protected BulletRenderer renderer;
        private int counter;
        public int Counter {
            get => counter; 
            set
            {
                if (counter + value > attackInterval)
                {
                    counter = attackInterval;
                }
                else
                {
                    counter = value;
                }
            }
        }
        public int AttackInterval { get => attackInterval; set => attackInterval = value; }
        public BulletRenderer Sprite { get => renderer; set => renderer = value; }
        public AbstractAttackPattern(int attackInterval, BulletRenderer sprite)
        {
            this.attackInterval = attackInterval;
            this.renderer = sprite;
            counter = 0;
        }

        public virtual void Execute(GameTime gameTime, Vector2 position)
        {
            counter++;
        }

        protected void ResetCounter()
        {
            counter = 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
