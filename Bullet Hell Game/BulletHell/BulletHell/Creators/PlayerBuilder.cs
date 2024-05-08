using BulletHell.Entity;
using BulletHell.Entity.AttackPattern;
using BulletHell.Entity.Movement;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static System.Formats.Asn1.AsnWriter;

namespace BulletHell.Creators
{
    public class PlayerBuilder : AbstractEntityBuilder
    {

        private Player player;
        private int bombs;

        public PlayerBuilder(int health, int bombs, AbstractMovement movement, AbstractAttackPattern attackPattern, AbstractEntityRenderer renderer, Vector2 origin)
        {
            this.movement = movement;
            this.attackPattern = attackPattern;
            this.origin = origin;
            this.renderer = renderer;
            this.health = health;
            this.bombs = bombs;

            player = new Player();
        }
        public override void BuildHealth()
        {
            player.Health = health;
            player.Bombs = bombs;
        }

        public override void BuildRenderer()
        {
            player.Renderer = renderer;
        }

        public override void BuildMovement()
        {
            player.Movement = (AbstractMovement)movement.Clone();
        }

        public override void BuildAttackPattern()
        {
            player.AttackPattern = (AbstractAttackPattern)attackPattern.Clone();
        }

        public override void BuildScore()
        {
            // not needed for player
        }

        public override void BuildOrigin()
        {
            player.Pos = origin;

        }

        public Player GetResult()
        {
            return player;
        }
    }
}
