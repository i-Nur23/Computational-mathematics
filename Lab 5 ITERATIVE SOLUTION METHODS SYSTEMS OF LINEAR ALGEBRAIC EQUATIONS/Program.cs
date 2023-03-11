namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            float eps;
            Methods iterationMethod;
            var initApprox = new Tuple<float, float, float>(1f, 1f, 1f);
            while (true)
            {
                Console.Write("Выберете вариант:\n" +
                              "1 - eps = 0.001, начальное приближение = (1,1,1)\n" +
                              "2 - eps = 0.00001, начальное приближение = (1,1,1)\n" +
                              "3 - eps = 0.001, начальное приближение = (2, 1.5, 3)\n" +
                              "4 - eps = 0.00001, начальное приближение = (2, 1.5 ,3)\n" +
                              "5 - выход\n" +
                              "> ");
                var proximityChoice = Convert.ToInt32(Console.ReadLine());

                if (proximityChoice == 5)
                {
                    break;
                }

                switch (proximityChoice)
                {
                    case 1:
                        eps = 0.001f;
                        initApprox = new Tuple<float, float, float>(1f, 1f, 1f);
                        break;
                    case 2:
                        eps = 0.00001f;
                        initApprox = new Tuple<float, float, float>(1f, 1f, 1f);
                        break;
                    case 3:
                        eps = 0.001f;
                        initApprox = new Tuple<float, float, float>(2f, 1.5f, 3f);
                        break;
                    case 4:
                        eps = 0.00001f;
                        initApprox = new Tuple<float, float, float>(2f, 1.5f, 3f);
                        break;
                    default:
                        return;
                }

                while (true)
                {
                    Console.Write("Выберете метод:\n" +
                                  "1 - метод простых итераций\n" +
                                  "2 - метод Зейделя\n" +
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
                            iterationMethod = Methods.SIMPLE_ITERATIONS;
                            break;
                        case 2:
                            iterationMethod = Methods.SEIDEL;
                            break;
                        default:
                            return;
                    }

                    LinearAlgebraicEquationsSystemSolver solver = new LinearAlgebraicEquationsSystemSolver(iterationMethod, eps, initApprox);
                    solver.start();
                }
            }
        }
    }
}