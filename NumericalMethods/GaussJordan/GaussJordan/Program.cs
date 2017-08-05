using System;

namespace GaussJordan
{
    class MainClass : NumericalMethods
    {
        public static void Main()
        {
            Double[,] matrix = { { 25, 5, 1, 106.8 }, { 64, 8, 1, 177.2 }, { 144, 12, 1, 292.2 } };
            ForwardElimination forwardElimination = new ForwardElimination(ref matrix);
            forwardElimination.Eliminate();
            BackwardSubstitution backwardSubstitution = new BackwardSubstitution(matrix);
            backwardSubstitution.Substitute();
        }

    }
}
