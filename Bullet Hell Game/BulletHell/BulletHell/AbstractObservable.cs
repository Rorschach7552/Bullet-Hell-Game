using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public abstract class AbstractObservable
    {
        private readonly List<IObserver> observers = new();

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void UnSubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void UnsubscribeAll()
        {
            observers.Clear();
        }

        public void NotifySubscribers()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }
    }
}
