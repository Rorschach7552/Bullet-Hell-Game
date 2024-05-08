using BulletHell.Creators;
using BulletHell.Entity;
using BulletHell.Entity.Boss;
using BulletHell.Entity.Movement;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using BulletHell.Entity.AttackPattern;
using BulletHell.View;
using System;

namespace BulletHell.Data
{
    public class LevelInitializer
    {

        public static Level CreateLevelOne()
        {
            Level level = new Level();
            level.Name = "LevelOne";
            List<Wave> waves = new List<Wave>();
            List<IWaveNode> waveNodes = new List<IWaveNode>();

            EnemyBuilder builder;
            EntityBuilderDirector builderDirector;

            // first 8 seconds
            for (int i = 0; i < 8; i++)
            {
                int offset = i * 50;
                builder = new EnemyBuilder(1, 1, new VShapedMovement(new Vector2(offset, 30), 6.0f, 200 + offset, 7, true), new SingleAttackPattern(70, new BulletRenderer(60, 48, 16, 3, "torpedo_bullet")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_1_sheet"), new Vector2(offset, 30));
                builderDirector = new EntityBuilderDirector(builder);
                builderDirector.Construct();
                waveNodes.Add(AddEnemy(builder.GetResult(), i + 1));
            }


            for (int i = 0; i < 8; i++)
            {
                int xOffset = 1910 - (i * 50);
                int offset = i * 50;
                builder = new EnemyBuilder(1, 1, new VShapedMovement(new Vector2(xOffset, 30), 6.0f, 200 + offset, 7, false), new SingleAttackPattern(70, new BulletRenderer(60, 48, 16, 3, "torpedo_bullet")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_1_sheet"), new Vector2(xOffset, 30));
                builderDirector = new EntityBuilderDirector(builder);
                builderDirector.Construct();
                waveNodes.Add(AddEnemy(builder.GetResult(), i + 1));
            }
            //16 to 32 seconds
            for(int i= 16; i < 32;i++)
            {   
                builder = new EnemyBuilder(1, 1, new RandomRouteMovement(new Vector2(860, 40), 200, 20, 100, 1), new TriangleAttackPattern(190, new BulletRenderer(60, 32, 16, 4, "enemy_bullet_1")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_2_sheet"), new Vector2(860, 40));
                builderDirector = new EntityBuilderDirector(builder);
                builderDirector.Construct();
                waveNodes.Add(AddEnemy(builder.GetResult(), i));
            }


            //32 to 45
            for (int i = 32; i < 45; i++)
            {
                Random random = new Random();
                builder = new EnemyBuilder(1, 1, new PositionDirectedMovement(new Vector2(860, 30), 2.0f, 0.1f, 8, new Vector2(random.Next(640,1280),920)), new RandomExplosionAttackPattern(100, 5, new BulletRenderer(60, 16, 14, 10, "enemy_bullet_3")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_4_sheet"), new Vector2(860, 30));
                builderDirector = new EntityBuilderDirector(builder);
                builderDirector.Construct();
                waveNodes.Add(AddEnemy(builder.GetResult(), i));
            }

            for (int i = 32; i < 45; i++)
            {
                Random random = new Random();
                builder = new EnemyBuilder(1, 1, new PositionDirectedMovement(new Vector2(30, 30), 2.0f, 0.1f, 8, new Vector2(random.Next(640, 1280), 920)), new RandomExplosionAttackPattern(100, 5, new BulletRenderer(60, 16, 14, 10, "enemy_bullet_3")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_4_sheet"), new Vector2(30, 30));
                builderDirector = new EntityBuilderDirector(builder);
                builderDirector.Construct();
                waveNodes.Add(AddEnemy(builder.GetResult(), i));
            }

            for (int i = 32; i < 45; i++)
            {
                Random random = new Random();
                builder = new EnemyBuilder(1, 1, new PositionDirectedMovement(new Vector2(1890, 30), 2.0f, 0.1f, 8, new Vector2(random.Next(640, 1280), 920)), new RandomExplosionAttackPattern(100, 5, new BulletRenderer(60, 16, 14, 10, "enemy_bullet_3")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_4_sheet"), new Vector2(1890, 30));
                builderDirector = new EntityBuilderDirector(builder);
                builderDirector.Construct();
                waveNodes.Add(AddEnemy(builder.GetResult(), i));
            }

            builder = new EnemyBuilder(1, 1, new CircularMovement(new Vector2(20, 150), 1.5f, true), new RandomExplosionAttackPattern(200, 20, new BulletRenderer(32, 32, 16, 4, "enemy_bullet_2")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_2_sheet"), new Vector2(20, 150));
            builderDirector = new EntityBuilderDirector(builder);
            builderDirector.Construct();
            waveNodes.Add(AddEnemy(builder.GetResult(), 40));

            builder = new EnemyBuilder(1, 1, new CircularMovement(new Vector2(30, 160), 1.5f, true), new RandomExplosionAttackPattern(200, 20,new BulletRenderer(32, 32, 16, 4, "enemy_bullet_2")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_2_sheet"), new Vector2(30, 160));
            builderDirector = new EntityBuilderDirector(builder);
            builderDirector.Construct();
            waveNodes.Add(AddEnemy(builder.GetResult(), 45));

            builder = new EnemyBuilder(1, 1, new CircularMovement(new Vector2(40, 170), 1.5f, true), new RandomExplosionAttackPattern(200, 20, new BulletRenderer(32, 32, 16, 4, "enemy_bullet_2")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_2_sheet"), new Vector2(40, 170));
            builderDirector = new EntityBuilderDirector(builder);
            builderDirector.Construct();
            waveNodes.Add(AddEnemy(builder.GetResult(), 50));


            waveNodes.Add(AddBoss(CreateMidBoss(), 60));

            for (int i = 105; i < 120; i++)
            {
                builder = new EnemyBuilder(1, 1, new RandomRouteMovement(new Vector2(860, 40), 200, 20, 100, 1), new SemiCircleAttackPattern(160, new BulletRenderer(60, 16, 16, 16, "enemy_bullet_6")), new EnemyRenderer(30, 64, 64, 10, 6, "enemy_3_sheet"), new Vector2(860, 40));
                builderDirector = new EntityBuilderDirector(builder);
                builderDirector.Construct();
                waveNodes.Add(AddEnemy(builder.GetResult(), i));
            }

            waveNodes.Add(AddBoss(CreateFinalBoss(), 0));

            waves.Add(AddWave(waveNodes));

            level.Waves = waves;

            return level;
        }

        private static Wave AddWave(List<IWaveNode> waveNodes)
        {
            Wave wave = new();
            wave.enemies = waveNodes;
            return wave;
        }

        private static Boss CreateMidBoss()
        {
            BossFactory bossFactory = new();
            Boss boss = bossFactory.CreateBoss();
            Vector2 origin = new Vector2(900, 50);

            List<Spawner> bulletSpawners = new();
            Spawner bulletSpawner = new();
            bulletSpawner.AttackPattern = new SemiCircleAttackPattern(100, new BulletRenderer(60, 16, 14, 10, "enemy_bullet_4"));
            bulletSpawner.Movement = new SpirlingClockwiseMovement(origin, origin, 3.0f, 10f);
            bulletSpawners.Add(bulletSpawner);

            BossPhaseBuilder builder = new BossPhaseBuilder(30, 100, new TriangleMovement(origin, 100f), new SingleAttackPattern(200, new BulletRenderer(100, 32, 68, 6, "enemy_bullet_5")), bulletSpawners, new EnemyRenderer(60, 128, 128, 12, 30, "boss_1_sheet"), origin);

            EntityBuilderDirector director = new EntityBuilderDirector(builder);

            director.Construct();

            BossPhase phase1 = builder.GetResult();

            boss.Add(phase1);

            return boss;
        }

        private static Boss CreateFinalBoss()
        {
            BossFactory bossFactory = new();
            Boss boss = bossFactory.CreateBoss();
            boss.FinalBoss = true;
            Vector2 origin = new Vector2(900, 50);

            List<Spawner> bulletSpawners = new();
            Spawner bulletSpawner = new();
            bulletSpawner.AttackPattern = new TripodAttackPattern(300, new BulletRenderer(60, 32, 16, 4, "enemy_bullet_2"));
            bulletSpawner.Movement = new SpirlingClockwiseMovement(origin, origin, 3.0f, 10f);
            bulletSpawners.Add(bulletSpawner);

            BossPhaseBuilder builder = new BossPhaseBuilder(30, 100, new TriangleMovement(origin, 100f), new CircleAttackPattern(200, new BulletRenderer(100, 32, 68, 6, "wave_bullet")), bulletSpawners, new EnemyRenderer(60, 128, 128, 12, 30, "boss_2_sheet"), origin);

            EntityBuilderDirector director = new EntityBuilderDirector(builder);

            director.Construct();

            BossPhase phase1 = builder.GetResult();

            boss.Add(phase1);

            builder = new BossPhaseBuilder(50, 100, new StaticMovement(origin), new SpecialCircleAttackPattern(100, new BulletRenderer(60, 32, 16, 4, "enemy_bullet_1")), null, new EnemyRenderer(60, 128, 128, 12, 30, "boss_2_sheet"), origin);

            director = new EntityBuilderDirector(builder);

            director.Construct();

            boss.Add(builder.GetResult());

            bulletSpawners = new();

            bulletSpawner = new();
            bulletSpawner.AttackPattern = new TripodAttackPattern(300, new BulletRenderer(60, 32, 16, 4, "enemy_bullet_2"));
            bulletSpawner.Movement = new SpirlingClockwiseMovement(origin, origin, 2.0f, 10f);
            bulletSpawners.Add(bulletSpawner);

            bulletSpawner = new();
            bulletSpawner.AttackPattern = new TripodAttackPattern(300, new BulletRenderer(60, 32, 16, 4, "enemy_bullet_2"));
            bulletSpawner.Movement = new SpirlingCounterClockwiseMovement(origin, origin, 2.0f, 10f);
            bulletSpawners.Add(bulletSpawner);

            builder = new BossPhaseBuilder(40, 100, new TriangleMovement(origin, 100f), new CircleAttackPattern(200, new BulletRenderer(100, 32, 68, 6, "wave_bullet")), bulletSpawners, new EnemyRenderer(60, 128, 128, 12, 30, "boss_2_sheet"), origin);

            director = new EntityBuilderDirector(builder);

            director.Construct();

            boss.Add(builder.GetResult());

            return boss;
        }
        private static WaveNode AddEnemy(Enemy enemy, int time)
        {
            return new WaveNode(enemy, time);
        }

        private static BossWaveNode AddBoss(Boss boss, int time)
        {
            return new BossWaveNode(boss, time);
        }
    }
}
