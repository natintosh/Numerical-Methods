using System;
namespace NewtonDividedDifference
{
    internal class NewtonDividedDifference:NumericalMethods
    {
        Double[] x;
        Double[] f;
        Double[] list;
        Double[] dividedList;
		Double[] tempF;
		Double a;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:NewtonDividedDifference.NewtonDividedDifference"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="f">F.</param>
        /// <param name="a">The alpha component.</param>
        public NewtonDividedDifference(Double[] x, Double[] f, Double a)
        {
            this.x = x;
            this.f = f;
            this.a = a;
            dividedList = new Double[x.Length];
			list = new Double[x.Length];
            list[0] = f[0]; 
            dividedList = f;
        }
        /// <summary>
        /// Newtonses the method.
        /// </summary>
        public void NewtonsMethod()
		{
			int s;
			foreach (var item in f)
			{
				Console.Write("{0, -12:#.#####} \t", item);
			}
            for (int i = x.Length; i > 1; i--)
            {
                s = i - 1;
                tempF = new Double[CheckI(i)];
                for (int j = 0; j < i - 1; j++)
				{
                    tempF[j] = DivideDifference(dividedList[j + 1], dividedList[j], x[j + x.Length - s], x[j]);
				}
                dividedList = new Double[CheckI(i)];
                dividedList = tempF;
                Console.WriteLine();
                foreach (var item in tempF)
                {
                    Console.Write("{0, -12:#.#####} \t", item);
                }
                list[(x.Length) - (i - 1)] =tempF[0];
            }
            Console.WriteLine();
            Console.WriteLine();
            DisplayMatrix(list);

            Double multiplier = 1;
            Double answer = 0;

            for (int i = 0; i < list.Length; i++)
            {
                answer = answer + (list[i] * multiplier);
                multiplier = Multiplier(i);
            }
            Console.WriteLine();
            Console.WriteLine("f({0}) = {1:F5}", a, answer);
        }
        /// <summary>
        /// Multiplier the specified i.
        /// </summary>
        /// <returns>The multiplier.</returns>
        /// <param name="i">The index.</param>
        Double Multiplier(int i)
        {
            Double multiplier = 1;
            if (i == 0)
            {
                multiplier = multiplier * a - x[i];
            }
            else
            {
                for (int j = 0; j <= i; j++)
                {
                    multiplier = multiplier * (a - x[i]);
                }
            }

            return multiplier;
        }
        /// <summary>
        /// Divides the difference.
        /// </summary>
        /// <returns>The difference.</returns>
        /// <param name="fx1">Fx1.</param>
        /// <param name="fx0">Fx0.</param>
        /// <param name="x1">The first x value.</param>
        /// <param name="x0">X0.</param>
        private static Double DivideDifference(Double fx1, Double fx0, Double x1, Double x0)
        {
            Double numerator = fx1 - fx0;
            Double denominator = x1 - x0;
            return numerator / denominator;
        }
        /// <summary>
        /// Checks the i.
        /// </summary>
        /// <returns>The i.</returns>
        /// <param name="i">The index.</param>
        private int CheckI(int i){
            if (i - 1 != 0){
                return i - 1;
            }
            return 0;
        }
    }
}
