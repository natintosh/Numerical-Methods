using System;
namespace GaussJordan
{
    internal class ForwardElimination:NumericalMethods
    {
        Double[,] matrix;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:GaussJordan.ForwardElimination"/> class.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        public ForwardElimination(ref Double[,] matrix)
        {
            this.matrix = matrix;
        }
        /// <summary>
        /// Eliminate this instance.
        /// </summary>
        public void Eliminate(){
            Guassian(ref matrix);
        }
        /// <summary>
        /// Guassian the specified matrix.
        /// </summary>
        /// <returns>The guassian.</returns>
        /// <param name="matrix">Matrix.</param>
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
        /// <summary>
        /// Multiplier the specified firstRow, secondRow and index.
        /// </summary>
        /// <returns>The multiplier.</returns>
        /// <param name="firstRow">First row.</param>
        /// <param name="secondRow">Second row.</param>
        /// <param name="index">Index.</param>
        private static Double Multiplier(Double[] firstRow, Double[] secondRow, int index)
		{
			Double multiplier = 1;
			multiplier = secondRow[index] / firstRow[index];
			return multiplier;
		}
        /// <summary>
        /// Elimination the specified firstRow, secondRow and multiplier.
        /// </summary>
        /// <returns>The elimination.</returns>
        /// <param name="firstRow">First row.</param>
        /// <param name="secondRow">Second row.</param>
        /// <param name="multiplier">Multiplier.</param>
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
        /// <summary>
        /// Replaces the matrix.
        /// </summary>
        /// <returns>The matrix.</returns>
        /// <param name="matrix">Matrix.</param>
        /// <param name="newRow">New row.</param>
        /// <param name="position">Position.</param>
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
