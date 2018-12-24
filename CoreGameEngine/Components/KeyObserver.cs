using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreGameEngine.Components
{
    public class KeyObserver : Component, IObserver<ConsoleKey>, IEnumerable<ConsoleKey>
    {

        private IEnumerable<ConsoleKey> keysToObserve;
        private Queue<ConsoleKey> observedKeys;

        public KeyObserver(IEnumerable<ConsoleKey> keysToObserve)
        {
            this.keysToObserve = keysToObserve;
            observedKeys = new Queue<ConsoleKey>();
        }

        public override void Start()
        {
            ParentScene.inputHandler.RegisterObserver(keysToObserve, this);
        }

        public void Notify(ConsoleKey notification)
        {
            observedKeys.Enqueue(notification);
        }

        // Go through all components in this game object
        public IEnumerator<ConsoleKey> GetEnumerator()
        {
            return observedKeys.GetEnumerator();
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
