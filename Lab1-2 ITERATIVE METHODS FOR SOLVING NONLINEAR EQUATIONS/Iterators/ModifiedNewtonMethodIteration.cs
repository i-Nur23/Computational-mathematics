using Program.Interfaces;

namespace Program.Iterators;

public class ModifiedNewtonMethodIteration : IIteration
{
    private const float X0 = 2.5f;
    
    public float Compute(float x)
    {
        return x - (float)(2 * Math.Sin(x) - x + 0.4)
            / (float)(2 * Math.Cos(X0) - 1);
    }
}