namespace Program
{
    public class Program
    {
        private static readonly float _interval = 0.1f;
        private static readonly float _x0 = 0f;
        private static readonly float _x1 = 1f;
        private static readonly float _x2 = 2f;

        private static float FindAbsError(float accurateValue, float approximateValue)
        {
            return Math.Abs(accurateValue - approximateValue);
        }
        
        private static float CompInitFunction(float x)
        {
            return 17 * (float)Math.Tan(3 + Math.Sqrt(Math.Pow(x, 3)));
        }
        
        private static float CompLagrangePolynomial(float x)
        {
            return (float)-4.846 * (x - _x1) * (x - _x2) - (float)14.632 * (x - _x0) * (x - _x2)
                   + (float)39.366 * (x - _x0) * (x - _x1);
        }
        
        private static float CompFirstPolynomialNewton(float x)
        {
            return -2.423f + 12.162f*x + x*(2*x - 1)*9.944f;
        }
        
        private static float CompSecondPolynomialNewton(float x)
        {
            return 19.683f + 32.05f*(x-1)+(x-1)*(2*(x-1) + 1)*9.944f;
        }
        
        private static float CompApproximationPolynomial(float x)
        {
            return 19.888f*x*x + 2.244f*x - 2.416f;
        }
        
        private static void Main(string[] args)
        {
            Console.WriteLine("y(x)=17tg(3 + sqrt(x^3))");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-20}",
                "Xi","f(Xi)","L2(Xi)","|f(Xi) - L2(Xi)|","N1(Xi)","|f(Xi) - N1(Xi)|","N2(Xi)","|f(Xi) - N2(Xi)|","P2(Xi)","|f(Xi) - P2(Xi)|");

            for (int i = 0; i <= 10; i++)
            {
                float x = (float)Math.Round(0.1f * i, 1);
                var Y = CompInitFunction(x);
                var L2 = CompLagrangePolynomial(x);
                var N1 = CompFirstPolynomialNewton(x);
                var N2 = CompSecondPolynomialNewton(x);
                var P2 = CompApproximationPolynomial(x);

                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-20}",
                    x, Y, L2, FindAbsError(Y, L2), N1, FindAbsError(Y, N1), N2, FindAbsError(Y, N2), P2, FindAbsError(Y, P2));
                
            }
        }
    }
}