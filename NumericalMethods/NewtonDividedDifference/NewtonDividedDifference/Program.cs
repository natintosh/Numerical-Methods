using System;

namespace NewtonDividedDifference
{
    class MainClass:NumericalMethods
    {
        public static void Main()
		{
			Double[] function = { 0, 227.04, 362.78, 517.35, 602.97, 901.67 };
			Double[] time = { 0, 10, 15, 20, 22.5, 30 };

			//Double[,] table = { { 0, 0 }, { 10, 227.04 },
			//	{ 15, 362.78 }, { 20, 517.35 },
			//	{ 22.5, 602.97 }, { 40, 901.67 } };

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
