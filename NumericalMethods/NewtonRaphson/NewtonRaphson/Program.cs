using System;

namespace NewtonRaphson
{
    class MainClass:NumericalMethods
    {
        public static void Main(string[] args)
        {
	    Double[] equation = { 5, 6, 1 };
            Console.Write("Enter initial guess: ");
            Double guess = Convert.ToDouble(Console.ReadLine());
            NewtonRaphson newtonRaphson = new NewtonRaphson(equation, guess);
            newtonRaphson.NewtonRaphsonMethod();
        }
    }
}
