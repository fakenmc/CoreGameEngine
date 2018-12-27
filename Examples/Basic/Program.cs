/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;
using System.Linq;
using System.Collections.Generic;
using CoreGameEngine;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape };
            Scene scene = new Scene(40, 20, new InputHandler(10, quitKeys),
                new ConsoleRenderer(40, 20, new ConsolePixel(' ')));

            // Create quitter object
            GameObject quitter = new GameObject();
            KeyObserver quitSceneKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.Escape });
            quitter.AddComponent(quitSceneKeyListener);
            quitter.AddComponent(new Quitter());
            scene.AddGameObject("quitter", quitter);

            // Create player object
            char[,] playerSprite =
            {
                { '-', '|', '-'},
                { '-', '0', '-'},
                { '-', '|', '-'}
            };
            GameObject player = new GameObject();
            KeyObserver playerKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.DownArrow, ConsoleKey.UpArrow, ConsoleKey.RightArrow, ConsoleKey.LeftArrow });
            player.AddComponent(playerKeyListener);
            player.AddComponent(new Position(10f, 10f, 0f));
            player.AddComponent(new Player());
            player.AddComponent(new ConsoleSprite(playerSprite));
            scene.AddGameObject("player", player);

            scene.GameLoop(100);
        }
    }

}
