using System;
namespace Bisection
{
    internal class Bisection:NumericalMethods
    {
        Double[] equation;
        Double a;
        Double b;
        Double c;
        public Bisection(Double[] equation, Double a, Double b)
        {
            this.equation = equation;
            this.a = a;
            this.b = b;
        }

        public void Bisect()
        {
            Double fa;
            Double fb;
            Double fc = 1;
            Double absoluteError = 100;
            while (absoluteError != 0)
			{
				c = (a + b) / 2;
                fa = function(equation, a);
                fb = function(equation, b);
                fc = function(equation, c);
                Console.WriteLine("a: {0} b: {1} c: {2}", a, b, c);
                Console.WriteLine("fa \t {0:N7} \t fb  {1:N7} \t fc   {2:N7}", fa, fb, fc);
                Console.WriteLine();
                if (fc < 0)
                {
                    a = c;
                }
                else if (fc > 0)
                {
                    b = c;
                }
                absoluteError = AbsoluteRelativeError(a, b);
                if (fc == 0)
                {
                    break;
                }
                if (a == b)
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("The root is {0}", c);

        }

        private Double function(double[] f, double x)
        {
            Double sum = 0;
            int s;
            for (int i = 0; i < f.Length; i++)
            {
                s = i + 1;
                sum = sum + equation[i] * Math.Pow(x, f.Length - s);
            }
            return sum;
        }

    }
}
