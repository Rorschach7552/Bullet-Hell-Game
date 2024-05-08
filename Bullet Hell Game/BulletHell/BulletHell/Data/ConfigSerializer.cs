using BulletHell.Entity.Movement;
using BulletHell.Entity;
using Newtonsoft.Json;
using System;
using System.IO;
using Microsoft.Xna.Framework.Input;

namespace BulletHell.Data
{
    public class ConfigSerializer
    {
        static public void Serialize()
        {
            var playerConfig = new PlayerConfig
            {
                Lives = 5,
                Bombs = 3,
                AttackInterval = 60,
                Speed = 1.8f,
                Up = Keys.W,
                Down = Keys.S,
                Left = Keys.L,
                Right = Keys.R,
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
    }
}
