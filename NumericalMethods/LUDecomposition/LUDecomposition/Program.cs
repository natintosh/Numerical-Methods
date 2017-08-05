using System;

namespace LUDecomposition
{
    class MainClass:NumericalMethods
    {
        public static void Main()
        {
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
