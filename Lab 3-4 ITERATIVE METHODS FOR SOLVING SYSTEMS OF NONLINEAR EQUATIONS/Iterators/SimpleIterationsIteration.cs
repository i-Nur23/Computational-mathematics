using Program.Interfaces;

namespace Program.Iterators;

public class SimpleIterationsIteration : IIteration
{
    public Tuple<float, float> Compute(float x, float y)
    {
        return Tuple.Create(x, y);
    }
}