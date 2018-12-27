/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CoreGameEngine
{
    public class ConsoleRenderer
    {
        private bool cursorVisibleBefore = true;

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
        private ConsolePixel bgPix;

        public ConsoleRenderer(int xdim, int ydim, ConsolePixel bgPix)
        {
            this.xdim = xdim;
            this.ydim = ydim;
            this.bgPix = bgPix;
        }

        public void Start()
        {
            // Clean console
            Console.Clear();

            // Hide cursor
            Console.CursorVisible = false;

            // Resize window if we're in Windows (not supported on Linux/Mac)
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                cursorVisibleBefore = Console.CursorVisible;
                Console.SetWindowSize(xdim, ydim + 1);
            }

        }

        public void Finish()
        {
            Console.CursorVisible = cursorVisibleBefore;
        }

        public void Render(IEnumerable<GameObject> gameObjects)
        {
            // Background and foreground colors of each pixel
            ConsoleColor fgColor, bgColor;

            // The new frame to render
            ConsolePixel[,] frame = new ConsolePixel[xdim, ydim];

            // Filter game objects with sprite and position, get renderable
            // information and order ascending by Z
            IEnumerable<Renderable> stuffToRender = gameObjects
                .Where(gObj => gObj.IsRenderable)
                .Select(gObj => new Renderable(
                    gObj.GetComponent<Position>().Pos,
                    gObj.GetComponent<ConsoleSprite>()))
                .OrderBy(rend => rend.Pos.Z);

            // Render from lower layers to upper layers
            foreach (Renderable rend in stuffToRender)
            {
                // Cycle through all pixels in sprite
                foreach (KeyValuePair<Vector2, ConsolePixel> pixel
                    in rend.Sprite.Pixels)
                {
                    // Get absolute position of current pixel
                    Vector2 absPos = new Vector2(
                        rend.Pos.X + pixel.Key.X,
                        rend.Pos.Y + pixel.Key.Y
                    );

                    // Put pixel in frame
                    frame[(int)absPos.X, (int)absPos.Y] = pixel.Value;
                }
            }

            // Show frame in screen
            Console.SetCursorPosition(0, 0);
            fgColor = Console.ForegroundColor;
            bgColor = Console.BackgroundColor;
            for (int y = 0; y < ydim; y++)
            {
                for (int x = 0; x < xdim; x++)
                {
                    // Get current pixel
                    ConsolePixel pix = frame[x, y];

                    // If current pixel is not renderable, use background pixel
                    if (!pix.IsRenderable)
                    {
                        pix = bgPix;
                    }

                    // Do we have to change the background and foreground
                    // colors for this pixel?
                    if (!pix.backgroundColor.Equals(bgColor))
                    {
                        bgColor = pix.backgroundColor;
                        Console.BackgroundColor = bgColor;
                    }
                    if (!pix.foregroundColor.Equals(fgColor))
                    {
                        fgColor = pix.foregroundColor;
                        Console.ForegroundColor = fgColor;
                    }

                    // Render pixel
                    Console.Write(pix.shape);
                }

                // New line
                Console.WriteLine();
            }
        }
    }
}
