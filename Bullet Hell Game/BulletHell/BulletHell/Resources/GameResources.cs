using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Sprites
{
    /// <summary>
    /// Global reference for entity sprites.
    /// </summary>
    public static class GameResources
    {
        private static Texture2D coldNebula;
        private static Texture2D stars;
        private static Texture2D bigStars;

        private static Texture2D healthBarBackground;
        private static Texture2D healthBarForeground;
        private static SoundEffect shootingSound;
        private static SoundEffect bombSound;
        private static SoundEffect planetExplosion;
        private static SoundEffect tiktok;
        private static SoundEffectInstance shootingInstance;
        public static Texture2D ColdNebula { get => coldNebula; set => coldNebula = value; }
        public static Texture2D Stars { get => stars; set => stars = value; }
        public static Texture2D BigStars { get => bigStars; set => bigStars = value; }
        public static SoundEffect ShootingSound { get => shootingSound; set => shootingSound = value; }
        public static SoundEffectInstance ShootingInstance { get => shootingInstance; set => shootingInstance = value; }
        public static SoundEffect BombSound { get => bombSound; set => bombSound = value; }
        public static SoundEffect Tiktok { get => tiktok; set => tiktok = value; }
        public static SoundEffect PlanetExplosion { get => planetExplosion; set => planetExplosion = value; }
    }
}
