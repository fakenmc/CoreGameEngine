/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace CoreGameEngine
{
    // Console renderer
    public class ConsoleRenderer2D : GameObject
    {
        private bool cursorVisibleBefore = true;

        // Construtor
        public ConsoleRenderer2D(Scene scene) : base(scene) { }

        // Initial renderer setup
        public override void Start()
        {
            // Clean console
            Console.Clear();

            // Hide cursor
            Console.CursorVisible = false;

            // Resize window if we're in Windows (not supported on Linux/Mac)
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                cursorVisibleBefore = Console.CursorVisible;
                Console.SetWindowSize(CurrentScene.xdim, CurrentScene.ydim + 1);
            }
        }

        // Render current frame
        public override void Update()
        {
            // Use a StringBuilder instance to efficiently create string
            // Specifying the string size helps
            StringBuilder sb = new StringBuilder(
                CurrentScene.xdim * CurrentScene.ydim
                + Environment.NewLine.Length * CurrentScene.ydim);

            // Build string containing frame
            for (int y = 0; y < CurrentScene.ydim; y++)
            {
                for (int x = 0; x < CurrentScene.xdim; x++)
                {
                    sb.Append(CurrentScene.frameBuffer[x, y]);
                }
                sb.Append(Environment.NewLine);
            }

            // Position cursor
            Console.SetCursorPosition(0, 0);

            // Show frame
            Console.WriteLine(sb.ToString());
        }

        public override void Finish() {
            // Set cursor to what it was before
            Console.CursorVisible = cursorVisibleBefore;
        }
    }
}
