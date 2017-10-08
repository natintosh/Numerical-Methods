using System;
namespace Bisection
{
    internal class Bisection:NumericalMethods
    {
        readonly Double[] equation;
        Double a;
        Double b;
        Double c;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Bisection.Bisection"/> class.
        /// </summary>
        /// <param name="equation">Equation.</param>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public Bisection(Double[] equation, Double a, Double b)
        {
            this.equation = equation;
            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Bisect this instance.
        /// </summary>
        public void Bisect()
        {
            Double fa;
            Double fb;
            Double fc = 1;
            Double absoluteError = 100;
            const Double EPSILON = 1E-5;
            while (Math.Abs(absoluteError) > EPSILON)
			{
				c = (a + b) / 2;
                fa = Function(equation, a);
                fb = Function(equation, b);
                fc = Function(equation, c);
                Console.WriteLine("a: {0:F5} \t b: {1:F5} \t c: {2:F5}", a, b, c);
                Console.WriteLine("fa {0, -8:F5} \t fb {1, -8:F5} \t fc {2, -8:F5}", fa, fb, fc);
                Console.WriteLine();
                if (fc < 0)
                {
                    a = c;
                }
                else if (Math.Abs(fc) > EPSILON)
                {
                    b = c;
                }
                absoluteError = AbsoluteRelativeError(a, b);
                if (Math.Abs(fc) < EPSILON)
                {
                    break;
                }
                if (Math.Abs(a - b) < EPSILON)
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("The root is {0:F5}", c);

        }

        /// <summary>
        /// Function the specified f and x.
        /// </summary>
        /// <returns>The function.</returns>
        /// <param name="f">F.</param>
        /// <param name="x">The x coordinate.</param>
        private Double Function(double[] f, double x)
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
