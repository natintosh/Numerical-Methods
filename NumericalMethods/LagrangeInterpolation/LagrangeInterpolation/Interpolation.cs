using System;
namespace LagrangeInterpolation
{
    internal class Interpolation:NumericalMethods
    {
        Double[,] table;
        Double[] functions;
        Double[] time;
        Double[] terms;
        Double[] values;
        Double[] answers;
        Double t;
        Double answer = 0;
        int orderPlus1;
        Double[] weightFunction;

        public Interpolation(Double[,] table, Double[] functions, Double[] time, Double t, int orderPlus1)
        {
            this.table = table;
            this.functions = functions;
            this.time = time;
            this.t = t;
            this.orderPlus1 = orderPlus1;
            terms = new Double[orderPlus1];
            values = new Double[orderPlus1];
            answers = new Double[orderPlus1];
            weightFunction = new Double[orderPlus1];
            GetIndex();
        }

        private void GetIndex()
        {
            int rows = table.GetLength(0);
            int cols = table.GetLength(1);
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                while (time[i] < t)
                {
                    index = i;
                    break;
                }
            }
            for (int i = 0; i < orderPlus1; i++)
            {
                weightFunction[i] = 1; 
                if (i % 2  == 0)
                {
                    terms[i] = time[index - i];
					values[i] = functions[index - i];

                }
                else
                {
                    terms[i] = time[index + 1];
                    values[i] = functions[index + 1];
                    index = index + 1;
                }
            }
            DisplayMatrix(terms);
            Console.WriteLine();
            DisplayMatrix(values);
            Console.WriteLine();

            for (int i = 0; i < orderPlus1; i++)
            {
                WeightingFunction(i);
            }
            Console.WriteLine("Values of x: ");
            DisplayMatrix(terms);
            Console.WriteLine();
            Console.WriteLine("Values of L(x)");
            DisplayMatrix(weightFunction);

            for (int i = 0; i < orderPlus1; i++)
            {
                answers[i] = weightFunction[i] * values[i];
                answer = answer + answers[i];
            }

            Console.WriteLine("f({0}) = {1}",t ,answer);

        }

        private void WeightingFunction(int i)
        {
            Double numerator;
			Double denominator;
			Console.WriteLine("ti = {0}", terms[i]);
            for (int j = 0; j < orderPlus1; j++)
			{
                if (j != i)
				{
                    Console.WriteLine("tj = {0}" ,terms[j]);
                    numerator = t - terms[j];
					denominator = terms[i] - terms[j];
                    weightFunction[i] = weightFunction[i] * (numerator / denominator);
                }
            }
            Console.WriteLine();
        }
    }
}
