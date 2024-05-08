using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BulletHell.Data
{
    public class Level
    {
        private string name;
        public List<Wave> Waves { get; set; }
        public string Name { get => name; set => name = value; }
        public void UpdateLevel(GameTime gameTime)
        {
            // iterate through each wave, spawning all of it's enemies, ect
            foreach (Wave wav in Waves)
            {
                wav.Itterate(gameTime);
            }
        }
    }
}
