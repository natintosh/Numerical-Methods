using System;

namespace GaussJordan
{
    class MainClass : NumericalMethods
    {
        public static void Main()
        {
            Double[,] matrix = { { 1, 2, 1, 4 }, { 3, -4, -2, 2 }, { 5, 3, 5, -1 } };
            ForwardElimination forwardElimination = new ForwardElimination(ref matrix);
            forwardElimination.Eliminate();
            BackwardSubstitution backwardSubstitution = new BackwardSubstitution(matrix);
            backwardSubstitution.Substitute();
        }

    }
}
