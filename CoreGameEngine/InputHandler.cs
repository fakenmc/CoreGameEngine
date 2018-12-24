/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace CoreGameEngine
{
    public class InputHandler : IObservable<ConsoleKey>
    {
        private Dictionary<ConsoleKey, ICollection<IObserver<ConsoleKey>>> observers;
        private int maxKeysPerFrame;

        private Thread inputThread;

        private IEnumerable<ConsoleKey> quitKeys;

        public InputHandler(int maxKeysPerFrame, IEnumerable<ConsoleKey> quitKeys)
        {
            this.quitKeys = quitKeys;
            this.maxKeysPerFrame = maxKeysPerFrame;
            observers = new Dictionary<ConsoleKey, ICollection<IObserver<ConsoleKey>>>();
            inputThread = new Thread(ReadInput);
        }

        private void ReadInput()
        {
            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
                if (observers.ContainsKey(key))
                {
                    foreach (IObserver<ConsoleKey> observer in observers[key])
                    {
                        observer.Notify(key);
                    }
                }
            } while (!quitKeys.Contains(key));
        }

        public void StartReadingInput()
        {
            inputThread.Start();
        }


        public void StopReadingInput()
        {
            inputThread.Join();
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
