using System;
namespace GaussJordan
{
    class NumericalMethods
    {
        /// <summary>
        /// Trues the error.
        /// </summary>
        /// <returns>The error.</returns>
        /// <param name="trueValue">True value.</param>
        /// <param name="approximation">Approximation.</param>
        public static Double TrueError(Double trueValue, Double approximation){
            Double trueError = Math.Abs(trueValue - approximation);
            return trueError;
        }
        /// <summary>
        /// Relatives the true error.
        /// </summary>
        /// <returns>The true error.</returns>
        /// <param name="trueValue">True value.</param>
        /// <param name="approximation">Approximation.</param>
        public static Double RelativeTrueError(Double trueValue, Double approximation){
            Double numerator = Math.Abs(trueValue - approximation);
            Double denominator = trueValue;
            return (numerator / denominator) * 100;
        }
        /// <summary>
        /// Approximates the error.
        /// </summary>
        /// <returns>The error.</returns>
        /// <param name="presentAppr">Present appr.</param>
        /// <param name="previousAppr">Previous appr.</param>
        public static Double ApproximateError(Double presentAppr, Double previousAppr){
            return presentAppr - previousAppr;
        }
        /// <summary>
        /// Absolutes the relative error.
        /// </summary>
        /// <returns>The relative error.</returns>
        /// <param name="presentAppr">Present appr.</param>
        /// <param name="previousAppr">Previous appr.</param>
        public static Double AbsoluteRelativeError(Double presentAppr, Double previousAppr){
            Double numerator = presentAppr - previousAppr;
            Double denominator = presentAppr;
            return (numerator/denominator) * 100;
        }
        /// <summary>
        /// Displaies the matrix.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        public static void DisplayMatrix(Double[,] matrix){
            int degree = matrix.Rank;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(@"{0, -6}",  matrix[i, j]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Displaies the matrix.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
		public static void DisplayMatrix(Double[] matrix)
		{
			int degree = matrix.Rank;
            int length = matrix.Length;
            for (int i = 0; i < length; i++)
			{
                Console.WriteLine(@"{0}", matrix[i]);
			}
		}
    }
}
