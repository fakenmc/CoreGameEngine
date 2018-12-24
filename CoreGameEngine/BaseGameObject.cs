namespace CoreGameEngine
{
    public abstract class BaseGameObject : IGameObject
    {
        public virtual void Start() { }

        public virtual void Update() { }

        public virtual void Finish() { }
    }
}
