using System.Collections;
using System.Collections.Generic;

namespace CoreGameEngine
{
    public class ConsoleSprite : Component
    {
        public IDictionary<Vector2, ConsolePixel> Pixels { get; }

        public ConsoleSprite(IDictionary<Vector2, ConsolePixel> pixels)
        {
            Pixels = new Dictionary<Vector2, ConsolePixel>(pixels);
        }

        public ConsoleSprite(ConsolePixel[,] pixels)
        {
            Pixels = new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < pixels.GetLength(0); x++)
            {
                for (int y = 0; y < pixels.GetLength(1); y++)
                {
                    ConsolePixel cpixel = pixels[x, y];
                    if (cpixel.IsRenderable)
                    {
                        Pixels[new Vector2(x, y)] = cpixel;
                    }
                }
            }
        }

        public ConsoleSprite(char[,] pixels)
        {
            Pixels = new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < pixels.GetLength(0); x++)
            {
                for (int y = 0; y < pixels.GetLength(1); y++)
                {
                    char shape = pixels[x, y];
                    if (!shape.Equals(default(char)))
                    {
                        Pixels[new Vector2(x, y)] = new ConsolePixel(shape);
                    }
                }
            }
        }

    }
}
