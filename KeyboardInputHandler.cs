/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Threading;
using System.Collections.Generic;

namespace ConsoleGameEngine
{
    public class KeyboardInputHandler : IDisposable, IObservable<ConsoleKey>
    {
        private Thread reader;
        private ICollection<ConsoleKey> stopKeys;
        private Dictionary<ConsoleKey, ICollection<IObserver<ConsoleKey>>> observers;

        public void StartReadingKeys(IEnumerable<ConsoleKey> stopKeys)
        {
            this.stopKeys = new HashSet<ConsoleKey>(stopKeys);
            reader = new Thread(ReadKeys);
            reader.Start();
        }

        public void Dispose()
        {
            reader.Join();
        }

        private void ReadKeys()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (observers.ContainsKey(keyInfo.Key))
                {
                    foreach (IObserver<ConsoleKey> observer
                        in observers[keyInfo.Key])
                    {
                        observer.Notify(keyInfo.Key);
                    }

                }
            } while (!stopKeys.Contains(keyInfo.Key));

        }

        public void AddObserver(
            ConsoleKey whatToObserve, IObserver<ConsoleKey> observer)
        {
            if (!observers.ContainsKey(whatToObserve))
            {
                observers[whatToObserve] = new List<IObserver<ConsoleKey>>();
            }
            observers[whatToObserve].Add(observer);
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