namespace Program
{
    public class Program
    {
        static float _x0 = 0f ;
        static float _x2 = 1f ;
        static int n = 10 ;
        
        static float _x1 = (_x0 + _x2) / 2 ;
        static float _h = _x1 - _x0;
        
        static float step = (_x2 - _x0) / n ;

        static float _y0 = CompInitFunction(_x0);
        static float _y1 = CompInitFunction(_x1);
        static float _y2 = CompInitFunction(_x2);
        
        // Коэффициенты интерполяционного полинома Лагранжа
        static float a0 = _y0 / ((_x0 - _x1) * (_x0 - _x2));
        static float a1 = _y1 / ((_x1 - _x0) * (_x1 - _x2));
        static float a2 = _y2 / ((_x2 - _x0) * (_x2 - _x1));
        
        // Табличные разности для интерполяционных формул Ньютона
        static float[] dy = { _y1 - _y0, _y2 - _y1 };
        
        // Вычисление коэффициентов аппроксимационного многочлена
        static float[] x_arr = {_x0, _x1, _x2 };
        static float[] y_arr = {_y0, _y1, _y2 };
        static IEnumerable<(float X, float Y)> x_y_arrs = x_arr.Zip(y_arr);

        static float[][] columns =
        {
            new [] { 3, x_arr.Sum(), x_arr.Sum(x => x * x) },
            new [] { x_arr.Sum(), x_arr.Sum(x => x * x), x_arr.Sum(x => x * x * x) },
            new [] { x_arr.Sum(x => x * x), x_arr.Sum(x => x * x * x), x_arr.Sum(x => x * x * x * x) }
        };
        
        static float[] free_column = {y_arr.Sum(), x_y_arrs.Sum(z => z.X * z.Y), x_y_arrs.Sum(z => z.X * z.X * z.Y)};

        private static float det = FindDeterminator(columns);
        private static float det_1 = FindDeterminator(new[] { free_column, columns[1], columns[2]  });
        private static float det_2 = FindDeterminator(new[] { columns[0], free_column, columns[2]  });
        private static float det_3 = FindDeterminator(new[] { columns[0], columns[1], free_column });

        private static float _a0 = det_1 / det;
        private static float _a1 = det_2 / det;
        private static float _a2 = det_3 / det;


        private static float FindDeterminator(float[][] columns)
        {
            return columns[0][0] * (columns[1][1] * columns[2][2] - columns[2][1] * columns[1][2]) -
                   columns[0][1] * (columns[1][0] * columns[2][2] - columns[2][0] * columns[1][2]) +
                   columns[0][2] * (columns[1][0] * columns[2][1] - columns[2][0] * columns[1][1]);
        }

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
            
            return a0 * (x - _x1) * (x - _x2) + a1 * (x - _x0) * (x - _x2)
                   + a2 * (x - _x0) * (x - _x1);
        }
        
        private static float CompFirstPolynomialNewton(float x)
        {
            var t = (x - _x0) / _h;

            return _y0 + t * dy[0] + (t * (t - 1) / 2) * (dy[1] - dy[0]) ;
        }
        
        private static float CompSecondPolynomialNewton(float x)
        {
            var t = (x - _x2) / _h;

            return _y2 + t * dy[1] + (t * (t + 1) / 2) * (dy[1] - dy[0]) ;
        }
        
        private static float CompApproximationPolynomial(float x)
        {
            return _a2*x*x + _a1*x + _a0;
        }
        
        private static void Main(string[] args)
        {
            var separator = string.Join(null, Enumerable.Repeat( '-', 55));
            
            Console.WriteLine("y(x)=17tg(3 + sqrt(x^3))\n");
            Console.WriteLine(separator);
            Console.WriteLine("|{0, -5}|{1,-15}|{2,-15}|{3, -15}|","Xi",_x0,_x1,_x2);
            Console.WriteLine(separator);
            Console.WriteLine("|{0, -5}|{1,-15}|{2,-15}|{3, -15}|","Yi",_y0,_y1,_y2);
            Console.WriteLine(separator + "\n");

            separator = string.Join(null, Enumerable.Repeat("-", 156));
            Console.WriteLine("|{0,-10}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|{7,-15}|{8,-15}|{9,-15}|",
                "Xi","f(Xi)","L2(Xi)","|f(Xi)-L2(Xi)|","N1(Xi)","|f(Xi)-N1(Xi)|","N2(Xi)","|f(Xi)-N2(Xi)|","P2(Xi)","|f(Xi)-P2(Xi)|");
            Console.WriteLine(separator);

            for (float i = _x0; i < _x2 + step / 2; i+= step)
            {
                float x = (float)Math.Round(i, 3);
                var Y = CompInitFunction(x);
                var L2 = CompLagrangePolynomial(x);
                var N1 = CompFirstPolynomialNewton(x);
                var N2 = CompSecondPolynomialNewton(x);
                var P2 = CompApproximationPolynomial(x);

                Console.WriteLine("|{0,-10}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|{7,-15}|{8,-15}|{9,-15}|",
                    x, Y, L2, FindAbsError(Y, L2), N1, FindAbsError(Y, N1), N2, FindAbsError(Y, N2), P2, FindAbsError(Y, P2));
                Console.WriteLine(separator);
                
            }
        }
    }
}