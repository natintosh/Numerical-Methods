using System;
namespace GaussJordan
{
    internal class ForwardElimination:NumericalMethods
    {
        Double[,] matrix;
        public ForwardElimination(ref Double[,] matrix)
        {
            this.matrix = matrix;
        }

        public void Eliminate(){
            Guassian(ref matrix);
        }

        private static void Guassian(ref Double[,] matrix)
		{
			DisplayMatrix(matrix);
			int degrees = matrix.Rank;
			int rows = matrix.GetLength(0);
			int cols = matrix.GetLength(1);
			Double[] firstRow = new Double[cols];
			Double[] secondRow = new Double[cols];

			for (int i = 0; i < rows - 1; i++)
			{
				for (int j = i; j < rows - 1; j++)
				{
					for (int k = 0; k < cols; k++)
					{
						firstRow[k] = matrix[i, k];

						if (j + 1 < rows)
						{
							secondRow[k] = matrix[j + 1, k];
						}
					}
					if (i + 1 < rows)
					{
						Console.WriteLine(@"Multiplier:  {0} ", Multiplier(firstRow, secondRow, i));
						ReplaceMatrix(ref matrix, Elimination(firstRow, secondRow, Multiplier(firstRow, secondRow, i)), j + 1);
						DisplayMatrix(matrix);
					}
				}
			}
		}

        private static Double Multiplier(Double[] firstRow, Double[] secondRow, int index)
		{
			Double multiplier = 1;
			multiplier = secondRow[index] / firstRow[index];
			return multiplier;
		}

        private static Double[] Elimination(Double[] firstRow, Double[] secondRow, Double multiplier)
		{
			int max = firstRow.Length;
			for (int i = 0; i < max; i++)
			{
				firstRow[i] = firstRow[i] * multiplier;
			}
			for (int i = 0; i < max; i++)
			{
				secondRow[i] = secondRow[i] - firstRow[i];
			}
			return secondRow;
		}

        private static Double[,] ReplaceMatrix(ref Double[,] matrix, Double[] newRow, int position)
		{
			int max = newRow.Length;
			for (int i = 0; i < max; i++)
			{
				matrix[position, i] = newRow[i];
			}
			return matrix;
		}
    }
}
