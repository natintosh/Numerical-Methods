using System;

namespace GuassSeidel
{
    class LinearAlgebraicEquation: NumericalMethods
    {
        public static void Main()
        {

			Double[,] linearEquation = new Double[,]{ 
			{ 25, 5, 1, 106.8 },
			{ 64, 8, 1, 177.2 },
			{ 144, 12, 1, 292.2 } }
			;


			Double[][] matrix = new Double[][]{
                new Double[] { 25, 5, 1, 106.8 },
                new Double[]  { 64, 8, 1, 177.2 },
                new Double[] { 144, 12, 1, 292.2 }
            };

            DisplayMatrix(linearEquation);

            Double[] bee = { 106.8, 177.2, 292.2 };
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
