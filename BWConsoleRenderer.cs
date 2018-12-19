/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Collections.Generic;

namespace ConsoleGameEngine
{
    public class BWConsoleRenderer<T>
    {
        private struct Renderable
        {
            public Vector3 Pos { get; }
            public T ToRender { get; }

            public Renderable(Vector3 pos, T toRender)
            {
                Pos = pos;
                ToRender = toRender;
            }
        }

        private int xdim;
        private int ydim;

        private char[,] frame;

        private List<Renderable> stuffToRender;
        public BWConsoleRenderer(int xdim, int ydim)
        {
            this.xdim = xdim;
            this.ydim = ydim;
            frame = new char[xdim, ydim];
            stuffToRender = new List<Renderable>();
        }

        public void AddToRender(Vector3 pos, T thingToRender)
        {
            stuffToRender.Add(new Renderable(pos, thingToRender));
        }

        public void Render()
        {
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