using System;

namespace Bisection
{
    class MainClass:NumericalMethods
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main()
		{
            Console.WriteLine(@"Given a function 1x^2 + -2 find the root with in 5-decimal place"
                             +" Let [a, b] = [1, 2]");
            Double[] equation = { 1, 0, -2};
			//Double[] equation = { 1, 0, -1, -2 };
			Console.Write("Enter the value for a: ");
            Double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the value for b: ");
            Double b = Convert.ToDouble(Console.ReadLine());
            Bisection bisection = new Bisection(equation, a, b);
            bisection.Bisect();
        }
    }
}
