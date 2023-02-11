using Program.Interfaces;

namespace Program.Iterators;

public class SimpleIterationsIteration : IIteration
{
    private const float C = 0.5f;
    
    public float Compute(float x)
    {
        return x + C * (float)(2 * Math.Sin(x) - x + 0.4);
    }
}