using Program.Interfaces;
using Program.Iterators;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            float eps = 0.001f;
            float delta = 0.01f;
            IIteration iteration;
            while (true)
            {
                Console.Write("Выберете точность:\n" +
                              "1 - eps = 0.001, delta = 0.01\n" +
                              "2 - eps = 0.0001, delta = 0.001\n" +
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
                        delta = 0.01f;
                        break;
                    case 2:
                        eps = 0.0001f;
                        delta = 0.001f;
                        break;
                    default:
                        return;
                }

                while (true)
                {
                    Console.Write("Выберете метод:\n" +
                                  "1 - метод простых итераций\n" +
                                  "2 - метод Ньютона\n" +
                                  "3 - модифицированный метод Ньютона\n" +
                                  "4 - назад\n" +
                                  "> ");
                    var methodChoice = Convert.ToInt32(Console.ReadLine());

                    if (methodChoice == 4)
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
                        case 3:
                            iteration = new ModifiedNewtonMethodIteration();
                            break;
                        default:
                            return;
                    }

                    NonLinearEquationSolver solver = new NonLinearEquationSolver(iteration, eps, delta);
                    solver.start();
                }
            }
        }
    }
}