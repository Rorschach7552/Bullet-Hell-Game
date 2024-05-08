using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Data
{
    public interface IWaveNode
    {
        public abstract int GetTime();
        public abstract void Spawn();
    }
}
