using System;

namespace NewtonRaphson
{
    class MainClass:NumericalMethods
    {
        public static void Main(string[] args)
        {
			// x^3 + 3x^2 - 3x - 4 = 0

			//Double[] equation = { 1, 3, -3, -4 };
			Double[] equation = { 1, 2, 1 };
            Console.Write("Enter initial guess: ");
            Double guess = Convert.ToDouble(Console.ReadLine());
            NewtonRaphson newtonRaphson = new NewtonRaphson(equation, guess);
            newtonRaphson.NewtonRaphsonMethod();
        }
    }
}
