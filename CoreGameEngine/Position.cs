namespace CoreGameEngine
{
    public class Position : Component
    {
        public Vector3 Pos { get; set; }

        public Position()
        {
            Pos = new Vector3(0f, 0f, 0f);
        }

        public Position(float x, float y, float z)
        {
            Pos = new Vector3(x, y, z);
        }
    }
}
