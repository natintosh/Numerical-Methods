using System;
namespace LagrangeInterpolation
{
    internal class Interpolation : NumericalMethods
    {
        Double[,] table;
        Double[] functions;
        Double[] time;
        Double[] terms;
        Double[] values;
        Double[] answers;
        readonly Double t;
        Double answer = 0;
        int order;
        Double[] weightFunction;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LagrangeInterpolation.Interpolation"/> class.
        /// </summary>
        /// <param name="table">Table.</param>
        /// <param name="functions">Functions.</param>
        /// <param name="time">Time.</param>
        /// <param name="t">T.</param>
        /// <param name="order">Order.</param>
        public Interpolation(Double[,] table, Double[] functions, Double[] time, Double t, int order)
        {
            this.table = table;
            this.functions = functions;
            this.time = time;
            this.t = t;
            this.order = order;
            terms = new Double[order];
            values = new Double[order];
            answers = new Double[order];
            weightFunction = new Double[order];
            GetIndexOfX();
        }

        public double[] WeightFunction { get => weightFunction; set => weightFunction = value; }
        public int Order { get => order; set => order = value; }

        /// <summary>
        /// Gets the index of x.
        /// </summary>
        private void GetIndexOfX()
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
            for (int i = 0; i < order; i++)
            {
                weightFunction[i] = 1;
                if (i % 2 == 0)
                {
                    terms[i] = time[index - i];
                    values[i] = functions[index - i];
                }
                else
                {
                    if (index + 1 > terms.Length)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Matrix Out of Bound reduce the n : the order");
                        Console.ResetColor();
                    }
                    else
                    {
                        terms[i] = time[index + 1];
                        values[i] = functions[index + 1];
                        index = index + 1;
                    }
                }
            }

            for (int i = 0; i < order; i++)
            {
                WeightingFunction(i);
            }
            Console.WriteLine("Values of x: ");
            DisplayMatrix(terms);
            Console.WriteLine();
            Console.WriteLine("Values of L(x)");

            foreach (var item in weightFunction)
            {
                Console.WriteLine("{0}", item);
            }

            for (int i = 0; i < order; i++)
            {
                answers[i] = weightFunction[i] * values[i];
                answer = answer + answers[i];
            }

            Console.WriteLine();
            Console.Write("Result: ");
            Console.WriteLine("f({0}) = {1:#.#####}", t, answer);

        }

        /// <summary>
        /// Weightings the function.
        /// </summary>
        /// <param name="i">The index.</param>
        private void WeightingFunction(int i)
        {
            Double numerator;
            Double denominator;
            Console.Write("When ti is ");
            Console.WriteLine("ti = {0}", terms[i]);
            Console.WriteLine("tj is");
            for (int j = 0; j < order; j++)
            {

                if (j != i)
                {
                    Console.WriteLine("tj = {0}", terms[j]);
                    numerator = t - terms[j];
                    denominator = terms[i] - terms[j];
                    weightFunction[i] = weightFunction[i] * (numerator / denominator);
                }
            }
            Console.WriteLine();
        }
    }
}
