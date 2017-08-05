using System;
namespace NewtonRaphson
{
    internal class NewtonRaphson:NumericalMethods
    {
        Double[] equation;
        Double[] difference;
        Double initial;
        public NewtonRaphson(Double[] equation, Double initial)
        {
            this.equation = equation;
            this.initial = initial;
            difference = new Double[equation.Length - 1];
        }


        public void NewtonRaphsonMethod()
        {
            Double x0 = initial;
			Double x1;
			Differentiate();
            Double relativeError = 100;
            function(difference, x0);
            int i = 1;
            while (relativeError != 0)
            {
                if (function(difference, x0) == 0)
                {
                    Console.WriteLine("Division by zero");
                    break;
                }

                x1 = Math.Round(x0 - (function(equation, x0) / function(difference, x0)), 15);
                relativeError = Math.Round(ApproximateError(x1, x0), 7);
                Console.WriteLine("n: {0} x: {1:N3} \t ea: {2:N10}", i++, x1, relativeError);
				x0 = x1; 
            }
        }

        private Double function(double[] f, double x0)
        {
            Double sum = 0;
            int s;
            for (int i = 0; i < f.Length; i++)
            {
                s = i + 1;
                sum = sum + equation[i] * Math.Pow(x0, f.Length - s);
            }
            return sum;
        }

        public void Differentiate()
        {
            DisplayMatrix(equation);
            Console.WriteLine();
            for (int i = 1; i < equation.Length; i++)
            {
                difference[i - 1] = (equation.Length - i) * equation[i - 1];
            }
            Console.WriteLine();
            DisplayMatrix(difference);
        }
    }
}
