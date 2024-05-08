using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.IO;
using System;

namespace BulletHell.Data
{
    public class PlayerConfig
    {
        public int Lives { get; set; }
        public int Bombs { get; set; }
        public int AttackInterval { get; set; }
        public float Speed { get; set; }
        public Keys Up { get; set; }
        public Keys Down { get; set; }
        public Keys Left { get; set; }
        public Keys Right { get; set; }
        public Keys Shoot { get; set; }
        public Keys SlowDown { get; set; }
        public Keys Pause { get; set; }

        public static void Serialize()
        {
            var playerConfig = new PlayerConfig
            {
                Lives = 5,
                Bombs = 3,
                AttackInterval = 60,
                Speed = 1.8f,
                Up = Keys.W,
                Down = Keys.S,
                Left = Keys.A,
                Right = Keys.D,
                Shoot = Keys.Space,
                SlowDown = Keys.LeftShift,
                Pause = Keys.P
            };

            string dataDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data";
            string fileName = "\\config.json";

            string jsonString = JsonConvert.SerializeObject(playerConfig, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(dataDirectory + fileName, jsonString);
        }

        public static PlayerConfig Deserialize()
        {
            string dataDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data";
            string fileName = "\\config.json";

            string jsonString = File.ReadAllText(dataDirectory + fileName);

            PlayerConfig config = JsonConvert.DeserializeObject<PlayerConfig>(jsonString, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            return config;
        }
    }
}
