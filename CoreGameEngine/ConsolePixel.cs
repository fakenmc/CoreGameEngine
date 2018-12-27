using System;

namespace CoreGameEngine
{
    public struct ConsolePixel
    {
        public readonly char shape;
        public readonly ConsoleColor foregroundColor;
        public readonly ConsoleColor backgroundColor;

        public bool IsRenderable
        {
            get
            {
                return !shape.Equals(default(char))
                    && !foregroundColor.Equals(default(ConsoleColor))
                    && !backgroundColor.Equals(default(ConsoleColor));
            }
        }

        public ConsolePixel(char shape,
            ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            this.shape = shape;
            this.foregroundColor = foregroundColor;
            this.backgroundColor = backgroundColor;
        }

        public ConsolePixel(char shape, ConsoleColor foregroundColor)
        {
            this.shape = shape;
            this.foregroundColor = foregroundColor;
            backgroundColor = Console.BackgroundColor;
        }

        public ConsolePixel(char shape)
        {
            this.shape = shape;
            foregroundColor = Console.ForegroundColor;
            backgroundColor = Console.BackgroundColor;
        }

    }

}
