using System;

namespace NewtonDividedDifference
{
    class MainClass:NumericalMethods
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main()
		{
			Console.WriteLine("Given the time and velocity of a parachutist" +
							  "find the value of his velocity when t = 6");
			Double[] function = { 800, 2310, 3090, 3940, 4755 };
			Double[] time = { 1, 3, 5, 7, 13 };

			Double[,] table = { { 1, 800 }, { 3, 2310 },
				{ 5, 3090 }, { 7, 3940 },
				{ 13, 4755 } };
            
			Console.WriteLine(" x \t | \t f(x)");
			Console.WriteLine("------------------------");
			for (int i = 0; i < function.Length; i++)
			{
				Console.WriteLine(" {0, 6}  | \t {1,6}", time[i], function[i]);
			}

            Console.Write("Enter the of x: ");
            Double x = Convert.ToDouble(Console.ReadLine());

            NewtonDividedDifference newtonDividedDifference = new NewtonDividedDifference(time, function, x);
            newtonDividedDifference.NewtonsMethod();

		}
    }
}
