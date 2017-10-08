using System;

namespace LUDecomposition
{
    class MainClass:NumericalMethods
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main()
        {

            Console.WriteLine("Find the value of x1 x2 x3 of the equation");

            Double[,] matrix = { { 1, 2, 1, 4 }, { 3, -4, -2, 2 }, { 5, 3, 5, -1 } };
            Decompostion decomposition = new Decompostion(matrix);
            decomposition.Decompose();
            Double[,] upperMatrix = decomposition.GetUpperMatrix();
            Double[,] lowerMatrix = decomposition.GetLowerMatrix();
            ForwBackSubstitution forwBackSubstitution = new ForwBackSubstitution(upperMatrix, lowerMatrix);
            forwBackSubstitution.Substitute();
        }
    }
}
