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

        public void NewtonsMethod()
        {
            int s;
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
				DisplayMatrix(tempF);
                list[(x.Length) - (i - 1)] =tempF[0];
            }
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
            Console.WriteLine("f({0}) = {1}", a, answer);
        }

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

        private static Double DivideDifference(Double fx1, Double fx0, Double x1, Double x0)
        {
            Double numerator = fx1 - fx0;
            Double denominator = x1 - x0;
            return numerator / denominator;
        }

        private int CheckI(int i){
            if (i - 1 != 0){
                return i - 1;
            }
            return 0;
        }
    }
}
