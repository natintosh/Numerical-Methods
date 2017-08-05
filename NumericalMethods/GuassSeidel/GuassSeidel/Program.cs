using System;

namespace GuassSeidel
{
    class LinearAlgebraicEquation: NumericalMethods
    {
        public static void Main()
        {

			Double[,] linearEquation = new Double[,]{
				 { 25, 2, 1, 4 },
				 { 81, -4, -2, 2 },
				 { 144, 3, 5, 1 }
			};


			Double[][] matrix = new Double[][]{
                new Double[] { 25, 2, 1 },
                new Double[]  { 81, -4, -2 },
                new Double[] { 144, 3, 5 }
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