using Program.Interfaces;

namespace Program;

public class NonLinearEquationSolver
{
    private readonly IIteration _iteration;
    private readonly float _eps;
    private readonly float _delta;

    public NonLinearEquationSolver(IIteration iteration, float eps, float delta)
    {
        _iteration = iteration;
        _eps = eps;
        _delta = delta;
    }

    private float findResult(float x)
    {
        return 2 * (float)Math.Sin(x) - x + 0.4f;
    }

    private bool isStop(float currentX, float nextX)
    {
        return Math.Abs(currentX - nextX) < _eps && Math.Abs(findResult(nextX)) < _delta;
    }

    public void start()
    {
        float nextX;
        float currentX = -2.5f;
        float oldCurrentX;
        int n = 0;
        Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}{4,-20}","n","Xn","Xn+1","|Xn+1 - Xn|","|f(Xn+1)|");
        do
        {
            oldCurrentX = currentX;
            nextX = _iteration.Compute(currentX);
            Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}{4,-20}",n, currentX, nextX, Math.Abs(currentX - nextX), Math.Abs(findResult(nextX)));
            currentX = nextX;
            n++;
        } while (!isStop(oldCurrentX, currentX));
    }
}