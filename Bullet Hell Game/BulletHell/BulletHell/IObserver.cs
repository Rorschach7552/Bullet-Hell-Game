using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public interface IObserver
    {
        public void Update(AbstractObservable subject);
    }
}
