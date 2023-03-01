using Program.Interfaces;

namespace Program.Iterators;

public class SimpleIterationsIteration : IIteration
{
    public Tuple<float, float> Compute(float x, float y)
    {
        var nextX = x - 0.25f * (float)(Math.Pow(x, 2) + Math.Pow(y, 2) - x * y - 7) + 0.25f * (x - y - 1);
        
        var nextY = y - 0.25f * (float)(Math.Pow(x, 2) + Math.Pow(y, 2) - x * y - 7) + 1.25f * (x - y - 1);
        
        return Tuple.Create(nextX, nextY);
    }
}