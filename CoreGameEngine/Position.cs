namespace CoreGameEngine
{
    public class Position : Component
    {
        public Vector2 Pos { get; set; }

        public Position()
        {
            Pos = new Vector2(0f, 0f);
        }

        public Position(float x, float y)
        {
            Pos = new Vector2(x, y);
        }
    }
}
