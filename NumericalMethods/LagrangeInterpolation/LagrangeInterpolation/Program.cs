using System;

namespace LagrangeInterpolation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Double[] function = { 0, 227.04, 362.78, 517.35, 602.97, 901.67};
            Double[] time = { 0, 10, 15, 20, 22.5, 30};

            Double[,] table = { { 0, 0 }, { 10, 227.04 },
                { 15, 362.78 }, { 20, 517.35 },
                { 22.5, 602.97 }, { 40, 901.67 } };

            Console.WriteLine(" t \t | \t f(t)");
            Console.WriteLine("------------------------");
            for (int i = 0; i < function.Length; i++)
            {
                Console.WriteLine(" {0, 6}  | \t {1,6}", time[i], function[i]);
            }

            Console.Write(@"Enter the value of t: ");
            int t = Convert.ToInt32(Console.ReadLine());
			Console.Write(@"Enter the value of n: ");
			int order = Convert.ToInt32(Console.ReadLine());

            if (order + 1 > time.Length)
            {
                Console.WriteLine("Out of range Error");
            }
            else
			{
				Interpolation interpolation = new Interpolation(table, function, time, t, order + 1);
            }
        }
    }
}
