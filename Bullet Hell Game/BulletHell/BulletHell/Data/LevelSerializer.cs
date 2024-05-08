using System;
using System.IO;
using Newtonsoft.Json;

namespace BulletHell.Data
{
    public class LevelSerializer
    {
        static public void SerializeLevel(Level level)
        {

            string dataDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data";
            string fileName = "\\" + level.Name + ".json";

            string jsonString = JsonConvert.SerializeObject(level, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(dataDirectory + fileName, jsonString);
        }
    }
}
