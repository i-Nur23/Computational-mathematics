using Program.Interfaces;

namespace Program;

public class NonLinearSystemEquationSolver
{
    private readonly IIteration _iteration;
    private readonly float _eps;

    public NonLinearSystemEquationSolver(IIteration iteration, float eps)
    {
        _iteration = iteration;
        _eps = eps;
    }

    private bool isStop(float currentX, float nextX, float currentY, float nextY)
    {
        return Math.Abs(currentX - nextX) < _eps && Math.Abs(currentY - nextY) < _eps;
    }

    public void start()
    {
        float nextX;
        float nextY;
        float currentX = 3f;
        float currentY = 1f;
        float oldCurrentX;
        float oldCurrentY;
        int n = 0;
        Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}","n","Xn","Xn+1","|Xn+1 - Xn|","Yn","Yn+1","|Yn+1 - Yn|");
        do
        {
            oldCurrentX = currentX;
            oldCurrentY = currentY;
            (nextX, nextY) = _iteration.Compute(currentX, currentY);
            Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}",n, currentX, nextX, Math.Abs(currentX - nextX), currentY, nextY, Math.Abs(currentY - nextY));
            currentX = nextX;
            currentY = nextY;
            n++;
        } while (!isStop(oldCurrentX, currentX, oldCurrentY, currentY));
    }
}