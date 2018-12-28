/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;
using CoreGameEngine;

namespace Basic
{
    // Simple component which listens for the escape key and terminates the
    // parent scene
    public class Quitter : Component
    {
        private KeyObserver keyObserver;
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
        }
        public override void Update()
        {
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                if (key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Bye :(");
                    ParentScene.Terminate();
                }
            }
        }
    }
}
