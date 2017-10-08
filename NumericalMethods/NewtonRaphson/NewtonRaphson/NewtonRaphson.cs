using System;
namespace NewtonRaphson
{
    internal class NewtonRaphson:NumericalMethods
    {
        // I declare array variables equation, difference and a variable initial
        Double[] equation;
        Double[] difference;
        Double initial;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:NewtonRaphson.NewtonRaphson"/> class.
        /// </summary>
        /// <param name="equation">Equation.</param>
        /// <param name="initial">Initial.</param>
        public NewtonRaphson(Double[] equation, Double initial)
        {
            this.equation = equation;
            this.initial = initial;
            difference = new Double[equation.Length - 1];
        }
        /// <summary>
        /// Newtons the raphson method.
        /// for finding the root of the equation
        /// </summary>
        public void NewtonRaphsonMethod()
        {
            Double x0 = initial;
			Double x1;
			Differentiate();
            Double relativeError = 100;
            function(difference, x0);
            int i = 1;
            const Double EPSILON = 1E-5; // EPSILON is the allow approxiamte
            // Error which is E - 10^5
            Console.WriteLine("Results");
            while (Math.Abs(relativeError) > EPSILON)
            {
                if (Math.Abs(function(difference, x0)) < EPSILON)
                {
                    Console.WriteLine("Division by zero");
                    break;
                }

                x1 = Math.Round(x0 - (function(equation, x0) / function(difference, x0)), 15);
                relativeError = Math.Round(ApproximateError(x1, x0), 7);
                // I displayed the results
                Console.WriteLine("n: {0, 3}  x: {1,7:N5} \t ea: {2:N5}", i++, x1, relativeError);
				x0 = x1; 
            }
        }

        /// <summary>
        /// Function the specified f and x0 and is to return the sum of the 
        /// sum of the function.
        /// </summary> 
        /// <returns>The function returns the sum of a function.</returns>
        /// <param name="f">F.</param>
        /// <param name="x0">X0</param>
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

        /// <summary>
        /// Differentiate this function.
        /// </summary>
        public void Differentiate()
        {
            Console.WriteLine("The equation");
            DisplayMatrix(equation);
            Console.WriteLine();
            for (int i = 1; i < equation.Length; i++)
            {
                difference[i - 1] = (equation.Length - i) * equation[i - 1];
            }
            Console.WriteLine("Differentiated Equation");
            DisplayMatrix(difference);
        }
    }
}
