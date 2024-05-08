 using BulletHell.Entity.AttackPattern;
using BulletHell.Entity.Collision;
using BulletHell.Entity.Movement;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace BulletHell.Entity
{
    /// <summary>
    /// Abstract entity class for shared properities and actions amongst game entities.
    /// </summary>
    public abstract class AbstractEntity : AbstractObservable, ICollidable
    {
        /// <summary>
        /// health of the entity.
        /// </summary>
        protected int health;

        protected AbstractEntityRenderer renderer;

        /// <summary>
        /// position of the entity.
        /// </summary>
        protected Vector2 position;

        /// <summary>
        /// the rotation of the entity.
        /// </summary>
        private float rotation;

        private bool isAlive;

        protected AbstractMovement movement;

        protected AbstractAttackPattern attackPattern;

        protected List<Spawner> bulletSpawners;
        public List<Spawner> BulletSpawners { get => bulletSpawners; set => bulletSpawners = value; }

        public AbstractEntity()
        {
            this.isAlive = true;
        }

        /// <summary>
        /// health of the entity.
        /// </summary>
        public int Health
        {
            get => health;
            set
            {
                if (value <= 0)
                {
                    Die();
                }

                health = value;
            }
        }
        public AbstractEntityRenderer Renderer
        {
            get => renderer;
            set => renderer = value;
        }
        /// <summary>
        /// position of the entity.
        /// </summary>
        public Vector2 Pos
        {
            get { 
                return position;
            }
            set {
                if (position == value)
                {
                    return;
                }
                else
                {
                    position = value;
                    this.OnPositionChanged();
                }
            }
        }
        /// <summary>
        /// the rotation of the entity.
        /// </summary>
        public float Rotation { get => rotation; set => rotation = value; }
        public AbstractMovement Movement { get => movement; set => movement = value; }
        public AbstractAttackPattern AttackPattern { get => attackPattern; set => attackPattern = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }

        public abstract void TakeDamage(int damage); // reduce health by damage amount.
        public abstract void Die(); // remove the entity

        public abstract void OnPositionChanged(); // called when position changes

        /// <summary>
        /// gets the rectangular hitbox for the entity.
        /// </summary>
        /// <returns> rectangle hitbox </returns>
        public Rectangle GetHitbox()
        {
            return new Rectangle((int)position.X, (int)position.Y, Renderer.SizeX, Renderer.SizeY);
        }
    }
}

