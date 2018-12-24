/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Collections.Generic;

namespace CoreGameEngine
{
    public class ConsoleRenderer<T>
    {
        private struct Renderable
        {
            public Vector3 Pos { get; }
            public ConsoleSprite Sprite { get; }

            public Renderable(Vector3 pos, ConsoleSprite sprite)
            {
                Pos = pos;
                Sprite = sprite;
            }
        }

        private int xdim;
        private int ydim;

        private char[,] frame;

        public ConsoleRenderer(int xdim, int ydim)
        {
            this.xdim = xdim;
            this.ydim = ydim;
            frame = new char[xdim, ydim];
        }

        public void Render(IEnumerable<GameObject> gameObjects)
        {
            List<Renderable> stuffToRender = new List<Renderable>();

            // Filter game objects with sprite and position
            // Turn sprite and position into renderable, add to list

            // Clear frame
            for (int x = 0; x < xdim; x++)
            {
                for (int y = 0; y < ydim; y++)
                {
                    frame[x, y] = ' ';
                }
            }

            // Sort by z
            stuffToRender.Sort(
                (Renderable tr1, Renderable tr2) =>
                    (int)(tr1.Pos.Z - tr2.Pos.Z));

            // Render from lower layers to upper layers
            foreach (Renderable r in stuffToRender)
            {

            }

            // Clear buffer
            stuffToRender.Clear();
        }

    }
}
