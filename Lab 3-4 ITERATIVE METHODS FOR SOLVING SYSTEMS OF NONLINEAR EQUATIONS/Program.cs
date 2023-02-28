using Program.Interfaces;
using Program.Iterators;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            float eps = 0.001f;
            IIteration iteration;
            Console.WriteLine(-2.5f + ": " +(2 * Math.Sin(-2.5f) - (- 2.5f) + 0.4f)*(-2 * Math.Sin(-2.5f)));
            Console.WriteLine(-1.5f + ": " +(2 * Math.Sin(-1.5f) - (- 1.5f) + 0.4f)*(-2 * Math.Sin(-1.5f)));
            while (true)
            {
                Console.Write("Выберете точность:\n" +
                              "1 - eps = 0.001\n" +
                              "2 - eps = 0.00001\n" +
                              "3 - выход\n" +
                              "> ");
                var proximityChoice = Convert.ToInt32(Console.ReadLine());

                if (proximityChoice == 3)
                {
                    break;
                }

                switch (proximityChoice)
                {
                    case 1:
                        eps = 0.001f;
                        break;
                    case 2:
                        eps = 0.00001f;
                        break;
                    default:
                        return;
                }

                while (true)
                {
                    Console.Write("Выберете метод:\n" +
                                  "1 - метод простых итераций\n" +
                                  "2 - метод Ньютона\n" +
                                  "3 - назад\n" +
                                  "> ");
                    var methodChoice = Convert.ToInt32(Console.ReadLine());

                    if (methodChoice == 3)
                    {
                        break;
                    }

                    switch (methodChoice)
                    {
                        case 1:
                            iteration = new SimpleIterationsIteration();
                            break;
                        case 2:
                            iteration = new NewtonMethodIteration();
                            break;
                        default:
                            return;
                    }

                    NonLinearEquationSolver solver = new NonLinearEquationSolver(iteration, eps);
                    solver.start();
                }
            }
        }
    }
}