using System.Collections;
using System.Collections.Generic;

namespace CoreGameEngine
{
    public abstract class ConsoleSprite : Component
    {
        public abstract IDictionary<Vector2, ConsolePixel> Pixels { get; }

    }
}
