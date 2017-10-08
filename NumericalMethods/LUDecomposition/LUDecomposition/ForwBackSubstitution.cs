using System;
namespace LUDecomposition
{
    internal class ForwBackSubstitution:NumericalMethods
    {
        Double[,] upperMatrix;
        Double[,] lowerMatrix;
        Double[] zee;
        Double[] bee;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LUDecomposition.ForwBackSubstitution"/> class.
        /// </summary>
        /// <param name="upperMatrix">Upper matrix.</param>
        /// <param name="lowerMatrix">Lower matrix.</param>
        public ForwBackSubstitution(Double[,] upperMatrix, Double[,] lowerMatrix)
        {
            int rows = upperMatrix.GetLength(0);
            this.upperMatrix = upperMatrix;
            this.lowerMatrix = lowerMatrix;
            zee = new Double[rows];
            bee = new Double[rows];
            for (int i = 0; i < upperMatrix.GetLength(0); i++)
			{
                zee[i] = 1;
                bee[i] = 1;
			}
        }

        /// <summary>
        /// Substitute this instance.
        /// </summary>
		public void Substitute()
		{
            int degrees = upperMatrix.Rank;
            int rows = upperMatrix.GetLength(0);
			int cols = upperMatrix.GetLength(1);
			Double val;
			Double[] coefficients = new Double[rows];
			Console.WriteLine(@"Rows: {0} Cols {1}", rows, cols);
            for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < rows; j++)
				{
                    coefficients[j] = lowerMatrix[i, j];
                    val = lowerMatrix[i, rows];
					Substitution(ref zee, coefficients, val, i);
				}
			}
			Console.WriteLine();
            DisplayAnswer(zee);
            ReplaceBee();
			for (int i = rows - 1; i >= 0; i--)
			{
				for (int j = 0; j < rows; j++)
				{
                    coefficients[j] = upperMatrix[i, j];
                    val = upperMatrix[i, rows];
					Substitution(ref bee, coefficients, val, i);
				}
			}
			Console.WriteLine();
            DisplayAnswer(bee);
		}

        /// <summary>
        /// Replaces the bee.
        /// </summary>
        private void ReplaceBee(){
            int rows = upperMatrix.GetLength(0);
            int cols = upperMatrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                upperMatrix[i, cols - 1] = zee[i];
            }
            Console.WriteLine(@"Replace the B with Z: ");
            DisplayMatrix(upperMatrix);
        }

        /// <summary>
        /// Substitution the specified answer, coefficients, val and index.
        /// </summary>
        /// <returns>The substitution.</returns>
        /// <param name="answer">Answer.</param>
        /// <param name="coefficients">Coefficients.</param>
        /// <param name="val">Value.</param>
        /// <param name="index">Index.</param>
        private void Substitution(ref Double[] answer, Double[] coefficients, Double val, int index)
		{
			int length = coefficients.Length;
			Double summation = val;
			for (int i = length - 1; i >= 0; i--)
			{
				if (i != index)
				{
                    summation = summation - (coefficients[i] * answer[i]);
				}
			}
            answer[index] = summation / coefficients[index];
		}

        /// <summary>
        /// Displaies the answer.
        /// </summary>
        /// <param name="answer">Answer.</param>
        private void DisplayAnswer(Double[] answer)
		{
            for (int i = 0; i < answer.Length; i++)
			{
                Console.WriteLine("x{0} = {1}", i + 1, answer[i]);
			}

		}

	}
}
