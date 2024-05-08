using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BulletHell.Entity.Movement
{
    public abstract class AbstractMovement : IObserver, ICloneable
    {
        protected Vector2 currentPosition;
        protected Vector2 targetPosition;
        protected float rotation;

        protected float initialSpeed;
        protected float acceleration;
        protected float targetSpeed;
        protected bool decelerating = false;

        public float InitialSpeed { get => initialSpeed; set => initialSpeed = value; }
        public float Acceleration { get => acceleration; set => acceleration = value; }
        public float TargetSpeed { get => targetSpeed; set => targetSpeed = value; }

        [JsonIgnore]
        public bool Decelerating { get => decelerating; set => decelerating = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public Vector2 TargetPosition { get => targetPosition; set => targetPosition = value; }
        public Vector2 CurrentPosition { get => currentPosition; set => currentPosition = value; }

        public AbstractMovement(Vector2 initialPosition, float speed, float acceleration, float targetSpeed, float rotation, Vector2 targetPosition)
        {
            this.currentPosition = initialPosition;
            this.targetPosition = targetPosition;
            this.initialSpeed = speed;
            this.acceleration = acceleration;
            this.targetSpeed = targetSpeed;

            if (targetSpeed < speed && acceleration < 0)
            {
                this.decelerating = true;
            }

            this.rotation = rotation;
        }

        public abstract Vector2 Update(GameTime gameTime);

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public virtual void Update(AbstractObservable subject)
        {

        }
    }
}
