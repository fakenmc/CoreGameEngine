/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Threading;
using System.Collections.Concurrent;

namespace ConsoleGameEngine
{
    public class Player : GameObject
    {
        private float x;
        private float y;

        private float stepPerFrame;

        private readonly char[,] playerSprite = new char[,] { { '=', '=' }, { '=', '=' } };

        private ConcurrentQueue<ConsoleKeyInfo> keyQueue;

        private Thread keyReader;

        public Player(Scene scene, float x, float y, float stepPerFrame)
            : base(scene)
        {
            this.x = x;
            this.y = y;
            this.stepPerFrame = stepPerFrame;
            keyQueue = new ConcurrentQueue<ConsoleKeyInfo>();
        }

        public override void Start()
        {
            keyReader = new Thread(KeyReader);
            keyReader.Start();
        }

        public override void Update()
        {
            ConsoleKeyInfo keyInfo;
            if (keyQueue.TryDequeue(out keyInfo))
            {
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    x += stepPerFrame;
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    x -= stepPerFrame;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    y -= stepPerFrame;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    y += stepPerFrame;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    CurrentScene.Terminate();
                }
                x = Math.Clamp(x, 0, CurrentScene.xdim - 1);
                y = Math.Clamp(y, 0, CurrentScene.ydim - 1);
            }

            for (int i = 0; i < playerSprite.GetLength(0); i++)
                for (int j = 0; j < playerSprite.GetLength(1); j++)
                    CurrentScene.frameBuffer[(int)x, (int)y] =
                        playerSprite[i, j];

            string playerPos = $"({x}, {y})";
            for (int i = 0; i < playerPos.Length; i++)
                CurrentScene.frameBuffer[2 + i, 2] = playerPos[i];
        }

        public override void Finish()
        {
            keyReader.Join();
        }

        private void KeyReader()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyQueue.Count < 5)
                    keyQueue.Enqueue(keyInfo);
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}