using Program.Interfaces;

namespace Program.Iterators;

public class NewtonMethodIteration : IIteration
{
    public Tuple<float, float> Compute(float x, float y)
    {
        var denominator = x + y; 
        
        var nextX = (float)(x*x + y*y - x*y - x + 2*y + 7) / denominator;
        
        var nextY = (float)(x*x + y*y - x*y - 2*x + y + 7) / denominator;
        
        return Tuple.Create(nextX, nextY);
    }
}