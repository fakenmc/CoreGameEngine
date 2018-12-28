/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;
using System.Collections.Generic;
using CoreGameEngine;

namespace Basic
{
    class Game
    {
        // World dimensions
        int xdim = 100, ydim = 50;

        // Frame duration in miliseconds
        int frameLength = 100;

        // The (only) game scene
        private Scene gameScene;

        // Program starts here
        public static void Main(string[] args)
        {
            // Create a new small game and run it
            Game smallGame = new Game();
            smallGame.Run();
        }

        private Game()
        {

            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape };
            gameScene = new Scene(xdim, ydim,
                new InputHandler(quitKeys),
                new ConsoleRenderer(xdim, ydim, new ConsolePixel('.')),
                new CollisionHandler(xdim, ydim));

            // Create quitter object
            GameObject quitter = new GameObject("Quitter");
            KeyObserver quitSceneKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.Escape });
            quitter.AddComponent(quitSceneKeyListener);
            quitter.AddComponent(new Quitter());
            gameScene.AddGameObject(quitter);

            // Create player object
            char[,] playerSprite =
            {
                { '-', '|', '-'},
                { '-', '0', '-'},
                { '-', '|', '-'}
            };
            GameObject player = new GameObject("Player");
            KeyObserver playerKeyListener = new KeyObserver(new ConsoleKey[] {
                ConsoleKey.DownArrow,
                ConsoleKey.UpArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.LeftArrow});
            player.AddComponent(playerKeyListener);
            Position playerPos = new Position(10f, 10f, 0f);
            player.AddComponent(playerPos);
            player.AddComponent(new Player());
            player.AddComponent(new ConsoleSprite(
                playerSprite, ConsoleColor.Red, ConsoleColor.DarkGreen));
            gameScene.AddGameObject(player);

            // Create walls
            GameObject walls = new GameObject("Walls");
            ConsolePixel wallPixel = new ConsolePixel(
                '#', ConsoleColor.Blue, ConsoleColor.White);
            Dictionary<Vector2, ConsolePixel> wallPixels =
                new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < xdim; x++)
                wallPixels[new Vector2(x, 0)] = wallPixel;
            for (int x = 0; x < xdim; x++)
                wallPixels[new Vector2(x, ydim - 1)] = wallPixel;
            for (int y = 0; y < ydim; y++)
                wallPixels[new Vector2(0, y)] = wallPixel;
            for (int y = 0; y < ydim; y++)
                wallPixels[new Vector2(xdim - 1, y)] = wallPixel;
            walls.AddComponent(new ConsoleSprite(wallPixels));
            walls.AddComponent(new Position(0, 0, 1));
            gameScene.AddGameObject(walls);

            // Create game object for showing date and time
            GameObject dtGameObj = new GameObject("Time");
            dtGameObj.AddComponent(new Position(xdim / 2 + 1, 0, 10));
            RenderableStringComponent rscDT = new RenderableStringComponent(
                () => DateTime.Now.ToString("F"),
                i => new Vector2(i, 0),
                ConsoleColor.DarkMagenta, ConsoleColor.White);
            dtGameObj.AddComponent(rscDT);
            gameScene.AddGameObject(dtGameObj);

            // Create game object for showing position
            GameObject pos = new GameObject("Position");
            pos.AddComponent(new Position(1, 0, 10));
            RenderableStringComponent rscPos = new RenderableStringComponent(
                () => $"({playerPos.Pos.X}, {playerPos.Pos.Y})",
                i => new Vector2(i, 0),
                ConsoleColor.DarkMagenta, ConsoleColor.White);
            pos.AddComponent(rscPos);
            gameScene.AddGameObject(pos);

        }

        private void Run()
        {
            // Start game loop
            gameScene.GameLoop(frameLength);
        }
    }

}
