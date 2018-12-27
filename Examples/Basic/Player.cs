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
    public class Player : Component
    {
        private KeyObserver keyObserver;
        private Position position;
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            position = ParentGameObject.GetComponent<Position>();
        }

        public override void Update()
        {
            float x = position.Pos.X;
            float y = position.Pos.Y;

            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                switch (key) {
                    case ConsoleKey.UpArrow:
                        y -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        y += 1;
                        break;
                    case ConsoleKey.RightArrow:
                        x += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        x -= 1;
                        break;
                }
            }

            position.Pos = new Vector3(
                position.Pos.X - 1, position.Pos.Y, position.Pos.Z);

        }

    }
}
