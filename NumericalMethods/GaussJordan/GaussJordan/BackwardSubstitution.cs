using System;

namespace GaussJordan
{
    internal class BackwardSubstitution:NumericalMethods
    {
        Double[,] matrix;
        protected internal Double[] answers;
        public BackwardSubstitution(Double[,] matrix){
			this.matrix = matrix;
            answers = new Double[matrix.GetLength(0)];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				answers[i] = 1;
			}
        }

        public void Substitute()
		{
			int degrees = matrix.Rank;
			int rows = matrix.GetLength(0);
			int cols = matrix.GetLength(1);
            Double val;
            Double[] coefficients = new Double[rows];
            Console.WriteLine(@"Rows: {0} Cols {1}", rows, cols);
            Console.WriteLine(@"Determinant: {0}", Determinant(matrix));
            for (int i = rows -1; i >= 0; i--)
            {
                for (int j = 0; j < rows; j++)
                {
                    coefficients[j] = matrix[i, j];
				}
				val = matrix[i, rows];
				Substitution(coefficients, val, i);
            }
            Console.WriteLine();
            DisplayAnswer();
        }

        private void Substitution(Double[] coefficients, Double val, int index)
        {
            int length = coefficients.Length;
            DisplayMatrix(coefficients);
            Double summation = val;
            for (int i = length - 1; i >= 0; i--)
            {
                if (i != index)
                {
                    summation = summation - (coefficients[i] * answers[i]);
                }
			}
			answers[index] = summation / coefficients[index];
        }


		private static Double Determinant(Double[,] matrix)
		{
			int length = matrix.GetLength(0);
			Double summation = 1;
			for (int i = 0; i < length; i++)
			{
				summation = summation * matrix[i, i];
			}
			return summation;
		}

        private void DisplayAnswer()
        {
			for (int i = 0; i < answers.Length; i++)
			{
                Console.WriteLine("x{0} = {1}", i + 1, answers[i]);
			}

        }
    }
}