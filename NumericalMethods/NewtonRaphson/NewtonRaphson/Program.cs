using System;

namespace NewtonRaphson
{
    class MainClass:NumericalMethods
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            // This Program is to calculate this equation
            // x^3 + 3x^2 - 3x - 4 = 0
            // using newton raphson method
            Console.WriteLine("Find the root of this equation");
            Console.WriteLine(@"x^3 + 3x^2 - 3x - 4 = 0");
			Double[] equation = { 1, 3, -3, -4 };
			//Double[] equation = { 1, 2, 1 };
            Console.Write("Enter initial guess: ");
            Double guess = Convert.ToDouble(Console.ReadLine());
            NewtonRaphson newtonRaphson = new NewtonRaphson(equation, guess);
            newtonRaphson.NewtonRaphsonMethod();
        }
    }
}
