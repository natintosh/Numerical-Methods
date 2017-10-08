using System;

namespace GuassSeidel
{
    class LinearAlgebraicEquation: NumericalMethods
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Find the value of x1 x2 x3 of the equation");

			Double[,] linearEquation = new Double[,]{
				 { 1, 2, 1, 4 },
				 { 3, -4, -2, 2 },
				 { 5, 3, 5, 1 }
			};


			Double[][] matrix = new Double[][]{
                new Double[] { 1, 2, 1 },
                new Double[]  { 3, -4, -2 },
                new Double[] { 5, 3, 5 }
            };

            DisplayMatrix(linearEquation);

            Double[] bee = { 4, 2, -1 };
            Double[] guess = { 1, 1, 1 };

			Console.WriteLine("Enter the initial guess"); 

            for (int i = 0; i < bee.Length; i++)
			{
                Console.Write(" A{0}: ", i + 1);
                guess[i] = Convert.ToDouble(Console.ReadLine());
			}

            GuassSeidel guass = new GuassSeidel(matrix, bee, guess);
        }
    }
}