using Program.Interfaces;

namespace Program.Iterators;

public class NewtonMethodIteration : IIteration
{
    public float Compute(float x)
    {
        return x - (float)(2 * Math.Sin(x) - x + 0.4)
            / (float)(2 * Math.Cos(x) - 1);
    }
}