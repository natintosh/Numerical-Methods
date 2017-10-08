using System;
namespace LUDecomposition
{
    internal class Decompostion:NumericalMethods
    {
        Double[,] matrix;
        Double[,] upperMatrix;
        Double[,] lowerMatrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LUDecomposition.Decompostion"/> class.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        public Decompostion(Double[,] matrix)
        {
            this.matrix = matrix;
            upperMatrix = matrix;
            PresetLowerMatrix(ref lowerMatrix, upperMatrix);
        }

        /// <summary>
        /// Decompose this instance.
        /// </summary>
        public void Decompose()
        {
            Guassian(matrix, ref upperMatrix, ref lowerMatrix);
        }

        /// <summary>
        /// Guassian the specified matrix, upperMatrix and lowerMatrix.
        /// </summary>
        /// <returns>The guassian.</returns>
        /// <param name="matrix">Matrix.</param>
        /// <param name="upperMatrix">Upper matrix.</param>
        /// <param name="lowerMatrix">Lower matrix.</param>
        private static void Guassian(Double[,] matrix, ref Double[,] upperMatrix, ref Double[,] lowerMatrix)
        {
            Console.WriteLine(@"Matrix: ");
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
                            lowerMatrix[j + 1, i] = Multiplier(firstRow, secondRow, i);
                        }
                    }
                    if (i + 1 < rows)
                    {
                        Console.WriteLine(@"Multiplier:  {0} ", Multiplier(firstRow, secondRow, i));
                        Console.WriteLine();
                        Console.WriteLine(@"LowerMatrix: ");
                        DisplayMatrix(lowerMatrix);
                        Console.WriteLine();
                        ReplaceMatrix(ref upperMatrix, Elimination(firstRow, secondRow, Multiplier(firstRow, secondRow, i)), j + 1);
                        Console.WriteLine(@"UpperMatrix: ");
                        DisplayMatrix(upperMatrix);
                        Console.WriteLine();
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
        /// <param name="upperMatrix">Upper matrix.</param>
        /// <param name="newRow">New row.</param>
        /// <param name="position">Position.</param>
        private static Double[,] ReplaceMatrix(ref Double[,] upperMatrix, Double[] newRow, int position)
        {
            int max = newRow.Length;
            for (int i = 0; i < max; i++)
            {
                upperMatrix[position, i] = newRow[i];
            }
            return upperMatrix;
        }

        /// <summary>
        /// Presets the lower matrix.
        /// </summary>
        /// <param name="lowerMatrix">Lower matrix.</param>
        /// <param name="upperMatrix">Upper matrix.</param>
        public void PresetLowerMatrix(ref Double[,] lowerMatrix, Double[,] upperMatrix)
        {
            int rows = upperMatrix.GetLength(0);
            int cols = upperMatrix.GetLength(1);
            lowerMatrix = new Double[rows, cols];
            Double[] zeeMatrix = new Double[rows];

            for (int i = 0; i < rows; i++)
            {
                zeeMatrix[i] = upperMatrix[i, cols -1];
                for (int j = 0; j < cols; j++)
                {
                    if (j == i)
                    {
                        lowerMatrix[i, j] = 1;
                    }if (j == 3)
                    {
                        lowerMatrix[i, j] = zeeMatrix[i];
                    }
                }
            }
        }

        /// <summary>
        /// Gets the upper matrix.
        /// </summary>
        /// <returns>The upper matrix.</returns>
        public Double[,] GetUpperMatrix(){
            return upperMatrix;
        }

        /// <summary>
        /// Gets the lower matrix.
        /// </summary>
        /// <returns>The lower matrix.</returns>
        public Double[,] GetLowerMatrix(){
            return lowerMatrix;
        }
 
    }
}
