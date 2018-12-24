
// Interface que representa mundos 2D genéricos
public interface IBuffer2D<T>
{
    int XDim { get; }
    int YDim { get; }
    T this[int x, int y] { get; }
}
