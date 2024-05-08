using BulletHell.Entity;
using BulletHell.Entity.AttackPattern;
using BulletHell.Entity.Movement;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Creators
{
    public class EnemyBuilder : AbstractEntityBuilder
    {
        private int score;
        private Enemy enemy;
        public EnemyBuilder(int health, int score, AbstractMovement movement, AbstractAttackPattern attackPattern, AbstractEntityRenderer renderer, Vector2 origin)
        {
            this.movement = movement;
            this.attackPattern = attackPattern;
            this.renderer = renderer;
            this.origin = origin;
            this.score = score;
            this.health = health;
            enemy = new Enemy();
        }

        public override void BuildHealth()
        {
            enemy.Health = health;
        }

        public override void BuildRenderer()
        {
            enemy.Renderer = renderer;
        }

        public override void BuildMovement()
        {
            enemy.Movement = (AbstractMovement)movement.Clone();
        }

        public override void BuildAttackPattern()
        {
            enemy.AttackPattern = (AbstractAttackPattern)attackPattern.Clone();
        }

        public override void BuildScore()
        {
            enemy.Score = score;
        }

        public override void BuildOrigin()
        {
            enemy.Pos = origin;
            
        }

        public Enemy GetResult()
        {
            Enemy result = enemy;
            enemy = new Enemy();
            return result;
        }
    }
}
