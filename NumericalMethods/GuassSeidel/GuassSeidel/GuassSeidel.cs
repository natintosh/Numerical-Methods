using System;
namespace GuassSeidel
{
    public class GuassSeidel
    {


        public static double MaxError = .00001;
        public static double MaxIteration = 100;
        public static double Lambda = .5;
        public static double[] answer;
        Double[][] matrix;
        Double[] bee;
        Double[] guess;

        public GuassSeidel(Double[][] matrix, Double[] bee, Double[] guess)
        {
            this.matrix = matrix;
            this.bee = bee;
            this.guess = guess;
            GaussSeidel(matrix, bee, guess);
        }


        public static double[] GaussSeidel(double[][] matrix, double[] bee, double[] root)
        {
            int length = matrix.Length;

            //Division by the diagonal element to reduce calculation
            for (int i = 0; i < length; i++)
            {
                double d = matrix[i][i];
                for (int j = 0; j < length; j++)
                {
                    matrix[i][j] = matrix[i][j] / d;
                }
                bee[i] = bee[i] / d;
            }

            //Generation of initial values for roots
            for (int i = 0; i < length; i++)
            {
                double sum = bee[i];
                for (int j = 0; j < length; j++)
                {
                    if (i != j)
                    {
                        sum -= (matrix[i][j] * root[j]);
                    }
                }
                root[i] = sum;
            }
            Console.Write("Iteration \t");
            Console.WriteLine("{0, -4} \t {1, -6} \t {2, -4} \t {3, -6} \t {4, -4} \t {5, -6}",   "x1",  "A.R.E:",  "x2",  "A.R.E",  "x3",  "A.R.E,");

            //Iterations for converging to the real roots
            for (int itr = 1; itr < MaxIteration; itr++)
            {
                Console.Write("{0, -9}\t", itr);
                for (int i = 0; i < length; i++)
                {
                    double old = root[i];
                    double sum = bee[i];

                    for (int j = 0; j < length; j++)
                    {
                        if (i != j)
                            sum -= (matrix[i][j] * root[j]);
                    }

                    root[i] = Lambda * sum + (1 - Lambda) * old;
                    if (root[i] != 0)
                    {
						double ea = Math.Abs((root[i] - old) / root[i]) * 100;
						Console.Write("{0, -4:N} \t {1, -6:N} \t", root[i], ea);
                        if (ea < MaxError)
						{
                            return root;
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return root;
        }
    }
}
