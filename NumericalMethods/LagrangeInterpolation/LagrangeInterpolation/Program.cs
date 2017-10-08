using System;

namespace LagrangeInterpolation
{
    class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Given the time and velocity of a parachutist falling " +
                              "find the value of his velocity when t = 6");
            Double[] function = { 800, 2310, 3090, 3940, 4755};
            Double[] time = { 1, 3, 5, 7, 13};

            Double[,] table = { { 1, 800 }, { 3, 2310 },
                { 5, 3090 }, { 7, 3940 },
                { 13, 4755 } };

            Console.WriteLine(" t \t | \t f(t)");
            Console.WriteLine("------------------------");
            for (int i = 0; i < function.Length; i++)
            {
                Console.WriteLine(" {0, 6}  | \t {1,6}", time[i], function[i]);
            }

            Console.Write("Enter the value of t: ");
            int t = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the value of n less than {0}: ", time.Length);
			int order = Convert.ToInt32(Console.ReadLine());

            if (order + 1 < time.Length)
			{
				Interpolation interpolation = new Interpolation(table, function, time, t, order + 1);
            }
            else
			{
				Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("Out of range Error");
				Console.ResetColor();
            }
        }
    }
}
