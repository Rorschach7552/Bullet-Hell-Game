using System;
using System.IO;
using Newtonsoft.Json;

namespace BulletHell.Data
{
    public class LevelDeserializer
    {
        public static Level DeserializeLevel()
        {
            string dataDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data";
            string fileName = "\\LevelOne.json";

            string jsonString = File.ReadAllText(dataDirectory + fileName);

            Level level = JsonConvert.DeserializeObject<Level>(jsonString, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            return level;
        }
    }
}
