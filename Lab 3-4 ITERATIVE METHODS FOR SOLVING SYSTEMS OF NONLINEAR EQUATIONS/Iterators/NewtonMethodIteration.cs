using Program.Interfaces;

namespace Program.Iterators;

public class NewtonMethodIteration : IIteration
{
    public Tuple<float, float> Compute(float x, float y)
    {
        var denominator = x + y; 
        
        var nextX = (float)(2*Math.Pow(x,3) + Math.Pow(x,2) - 13*x - 3*Math.Pow(x,2)*y + 3*x*Math.Pow(y,2) + x*y - Math.Pow(y,3) + 6 * y - 1) / denominator;
        
        var nextY = (float)(2*Math.Pow(y,3) + Math.Pow(y,2) - 13*y - 3*Math.Pow(y,2)*x + 3*y*Math.Pow(x,2) + x*y - Math.Pow(x,3) + 6 * x + 1) / denominator;
        
        return Tuple.Create(nextX, nextY);
    }
}