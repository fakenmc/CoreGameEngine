/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
namespace ConsoleGameEngine
{
    public interface IObservable<T>
    {
         void AddObserver(T whatToObserve, IObserver<T> observer);
         void RemoveObserver(T whatToObserve, IObserver<T> observer);
         void RemoveObserver(IObserver<T> observer);
    }
}