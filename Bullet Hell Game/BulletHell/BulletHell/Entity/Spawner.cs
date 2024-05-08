using BulletHell.Entity.AttackPattern;
using BulletHell.Entity.Movement;
using Microsoft.Xna.Framework;

namespace BulletHell.Entity
{
    public class Spawner
    {
        private AbstractMovement movement;

        private AbstractAttackPattern attackPattern;

        private Vector2 position;

        private float rotation;

        private bool isAlive;
        public AbstractMovement Movement { get => movement; set => movement = value; }
        public AbstractAttackPattern AttackPattern { get => attackPattern; set => attackPattern = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public Vector2 Position { get => position; set => position = value; }
    }
}
