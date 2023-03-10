namespace Program;

public class NonLinearSystemEquationSolver
{
    private readonly Methods _iterationMethod;
    private readonly float _eps;
    private readonly Tuple<float, float, float> _initApprox;

    public NonLinearSystemEquationSolver(Methods iterationMethod, float eps, Tuple<float, float, float> initApprox)
    {
        _iterationMethod = iterationMethod;
        _eps = eps;
        _initApprox = initApprox;
    }

    private float findX(float y, float z)
    {
        return 1 + 2 * y / 11 + 5 * z / 11;
    }
    
    private float findY(float x, float z)
    {
        return 1 - 5 * x / 7 + z / 7;
    }
    
    private float findZ(float x, float y)
    {
        return 1 + x / 5 + y / 5;
    }

    private bool isStop(float currentX, float nextX, float currentY, float nextY, float currentZ, float nextZ)
    {
        return Math.Abs(currentX - nextX) <= _eps && 
               Math.Abs(currentY - nextY) <= _eps && 
               Math.Abs(currentZ - nextZ) <= _eps;
    }

    public void start()
    {
        float nextX = 0;
        float nextY = 0;
        float nextZ = 0;
        float currentX = _initApprox.Item1;
        float currentY = _initApprox.Item2;
        float currentZ = _initApprox.Item3;
        float oldCurrentX;
        float oldCurrentY;
        float oldCurrentZ;
        int n = 0;
        Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}{8,-15}{9,-15}",
            "n","Xn","Xn+1","|Xn+1 - Xn|","Yn","Yn+1","|Yn+1 - Yn|","Zn","Zn+1","|Zn+1 - Zn|");
        do
        {
            oldCurrentX = currentX;
            oldCurrentY = currentY;
            oldCurrentZ = currentZ;
            switch (_iterationMethod)
            {
                case (Methods.SIMPLE_ITERATIONS):
                    nextX = findX(currentY, currentZ);
                    nextY = findY(currentX, currentZ);
                    nextZ = findZ(currentX, currentY);
                    break;
                case (Methods.SEIDEL):
                    nextX = findX(currentY, currentZ);
                    nextY = findY(nextX, currentZ);
                    nextZ = findZ(nextX, nextY);
                    break;
            }
            
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}{8,-15}{9,-15}",
                n, currentX, nextX, Math.Abs(currentX - nextX), currentY, nextY, Math.Abs(currentY - nextY), currentZ, nextZ, Math.Abs(currentZ - nextZ));
            currentX = nextX;
            currentY = nextY;
            currentZ = nextZ;
            n++;
        } while (!isStop(oldCurrentX, currentX, oldCurrentY, currentY, oldCurrentZ, currentZ));
    }
}