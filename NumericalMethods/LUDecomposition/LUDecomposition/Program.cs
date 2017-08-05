using System;

namespace LUDecomposition
{
    class MainClass:NumericalMethods
    {
        public static void Main()
        {
            Double[,] matrix = { 
			{ 25, 5, 1, 106.8 },
			{ 64, 8, 1, 177.2 },
			{ 144, 12, 1, 292.2 } };
            Decompostion decomposition = new Decompostion(matrix);
            decomposition.Decompose();
            Double[,] upperMatrix = decomposition.GetUpperMatrix();
            Double[,] lowerMatrix = decomposition.GetLowerMatrix();
            ForwBackSubstitution forwBackSubstitution = new ForwBackSubstitution(upperMatrix, lowerMatrix);
            forwBackSubstitution.Substitute();
        }
    }
}
