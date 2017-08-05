using System;
namespace Bisection
{
	class NumericalMethods
	{
		public static Double TrueError(Double trueValue, Double approximation)
		{
			Double trueError = Math.Abs(trueValue - approximation);
			return Math.Abs(trueError);
		}

		public static Double RelativeTrueError(Double trueValue, Double approximation)
		{
			Double numerator = Math.Abs(trueValue - approximation);
			Double denominator = trueValue;
			return Math.Abs((numerator / denominator));
		}

		public static Double ApproximateError(Double presentAppr, Double previousAppr)
		{
			return Math.Abs(presentAppr - previousAppr);
		}

		public static Double AbsoluteRelativeError(Double presentAppr, Double previousAppr)
		{
			Double numerator = presentAppr - previousAppr;
			Double denominator = presentAppr;
			return Math.Abs((numerator / denominator));
		}

		public static void DisplayMatrix(Double[,] matrix)
		{
			int degree = matrix.Rank;
			int rows = matrix.GetLength(0);
			int cols = matrix.GetLength(1);
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					Console.Write(@"{0, -6:0.####}", matrix[i, j]);
					Console.Write("  ");
				}
				Console.WriteLine();
			}
		}

		public static void DisplayMatrix(Double[] matrix)
		{
			int degree = matrix.Rank;
			int length = matrix.Length;
			for (int i = 0; i < length; i++)
			{
				Console.WriteLine(@"{0:0.######}", matrix[i]);
			}
		}
	}
}
