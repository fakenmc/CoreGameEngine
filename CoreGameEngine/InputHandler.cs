/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Threading;
using System.Collections.Generic;

namespace CoreGameEngine
{
    public class InputHandler : IObservable<ConsoleKey>
    {
        private Dictionary<ConsoleKey, ICollection<IObserver<ConsoleKey>>> observers;
        private int maxKeysPerFrame;

        public InputHandler(int maxKeysPerFrame)
        {
            this.maxKeysPerFrame = maxKeysPerFrame;
            observers = new Dictionary<ConsoleKey, ICollection<IObserver<ConsoleKey>>>();
        }
        public void HandleInput()
        {
            ConsoleKeyInfo keyInfo;
            int keysRead = 0;
            while (Console.KeyAvailable && keysRead < maxKeysPerFrame)
            {
                keyInfo = Console.ReadKey(true);
                Console.WriteLine($"Read {keyInfo.Key.ToString()}");
                if (observers.ContainsKey(keyInfo.Key))
                {
                    foreach (IObserver<ConsoleKey> observer
                        in observers[keyInfo.Key])
                    {
                        Console.WriteLine("Notify observer " + observer.GetType().Name + " of key " + keyInfo.Key.ToString());
                        observer.Notify(keyInfo.Key);
                    }

                }
                keysRead++;
            }

        }

        public void RegisterObserver(
            IEnumerable<ConsoleKey> whatToObserve, IObserver<ConsoleKey> observer)
        {
            foreach (ConsoleKey key in whatToObserve)
            {
                if (!observers.ContainsKey(key))
                {
                    observers[key] = new List<IObserver<ConsoleKey>>();
                }
                Console.WriteLine($"Register observer {observer.GetType().Name} to key {key.ToString()}");
                observers[key].Add(observer);
            }
        }
        public void RemoveObserver(
            ConsoleKey whatToObserve, IObserver<ConsoleKey> observer)
        {
            if (observers.ContainsKey(whatToObserve))
            {
                observers[whatToObserve].Remove(observer);
            }
        }

        public void RemoveObserver(IObserver<ConsoleKey> observer)
        {
            foreach (ICollection<IObserver<ConsoleKey>> theseObservers
                        in observers.Values)
            {
                theseObservers.Remove(observer);
            }
        }
    }
}
