using Program.Interfaces;

namespace Program.Iterators;

public class NewtonMethodIteration : IIteration
{
    public Tuple<float, float> Compute(float x, float y)
    {
        return Tuple.Create(x, y);
    }
}