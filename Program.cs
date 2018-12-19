/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;

namespace ConsoleGameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Scene game = new Scene(50, 30);
            game.AddGameObject("player", new Player(game, 25, 15, 2.5f));
            GameObject renderer = new ConsoleRenderer2D(game);
            game.SetRenderer(renderer);
            game.GameLoop(100);
        }
    }
}
