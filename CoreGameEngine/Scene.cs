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
    public class Scene
    {
        public readonly int xdim;
        public readonly int ydim;

        public readonly InputHandler inputHandler;

        private Dictionary<string, GameObject> gameObjects;

        private bool terminate = false;

        private GameObject renderer = null;

        //public readonly DoubleBuffer2D<char> frameBuffer;

        public Scene(int xdim, int ydim, InputHandler inputHandler) //, Renderer renderer
        {
            this.xdim = xdim;
            this.ydim = ydim;
            terminate = false;
            this.inputHandler = inputHandler;
            //frameBuffer = new DoubleBuffer2D<char>(xdim, ydim);
            gameObjects = new Dictionary<string, GameObject>();
        }

        public void SetRenderer(GameObject renderer)
        {
            this.renderer = renderer;
        }

        public void AddGameObject(string name, GameObject gameObject)
        {
            gameObject.ParentScene = this;
            gameObjects.Add(name, gameObject);
        }

        public GameObject FindGameObjectByName(string name)
        {
            return gameObjects[name];
        }

        public void Terminate()
        {
            terminate = true;
        }

        public void GameLoop(int msFramesPerSecond)
        {
            foreach (GameObject gameObject in gameObjects.Values)
            {
                gameObject.Start();
            }
            renderer?.Start();

            inputHandler.StartReadingInput();

            while (!terminate)
            {
                // Get real time in ticks (10000 ticks = 1 milisecond)
                long start = DateTime.Now.Ticks;

                // Update game objects
                foreach (GameObject gameObject in gameObjects.Values)
                {
                    gameObject.Update();
                }

                // Swap framebuffer
                //frameBuffer.Swap();
                renderer?.Update();
                //frameBuffer.Clear(' ');

                // Wait until next frame
                Thread.Sleep((int)
                    (start / 10000 + msFramesPerSecond
                    - DateTime.Now.Ticks / 10000));

            }

            inputHandler.StopReadingInput();

            foreach (GameObject gameObject in gameObjects.Values)
            {
                gameObject.Finish();
            }
            renderer?.Finish();
        }

    }
}
