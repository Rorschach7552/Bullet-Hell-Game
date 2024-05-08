using BulletHell.Entity;
using BulletHell.Entity.AttackPattern;
using BulletHell.Entity.Boss;
using BulletHell.Entity.Movement;
using BulletHell.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BulletHell.Creators
{
    public class BossPhaseBuilder : AbstractEntityBuilder
    {
        private int score;
        private List<Spawner> bulletSpawner = new();
        private BossPhase bossPhase;

        public BossPhaseBuilder(int health, int score, AbstractMovement movement, AbstractAttackPattern attackPattern, List<Spawner> bulletSpawner, AbstractEntityRenderer renderer, Vector2 origin)
        {
            this.movement = movement;
            this.attackPattern = attackPattern;
            this.origin = origin;
            this.score = score;
            this.renderer = renderer;
            this.health = health;
            this.bulletSpawner = bulletSpawner;
            bossPhase = new();
        }

        public override void BuildHealth()
        {
            bossPhase.Health = health;
        }

        public override void BuildRenderer()
        {
            bossPhase.Renderer = renderer;
        }

        public override void BuildMovement()
        {
            bossPhase.Movement = (AbstractMovement)movement.Clone();
        }

        public override void BuildAttackPattern()
        {
            bossPhase.BulletSpawners = bulletSpawner;
            bossPhase.AttackPattern = (AbstractAttackPattern)attackPattern.Clone();
        }

        public override void BuildScore()
        {
            bossPhase.Score = score;
        }

        public override void BuildOrigin()
        {
            bossPhase.Pos = origin;

        }

        public BossPhase GetResult()
        {   
            BossPhase result = bossPhase;
            bossPhase = new BossPhase();
            return result;
        }
    }
}
