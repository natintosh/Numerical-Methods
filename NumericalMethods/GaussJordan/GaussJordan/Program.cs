using System;

namespace GaussJordan
{
    class MainClass : NumericalMethods
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Find the value of x1 x2 x3 of the matrix given below");
            Double[,] matrix = { { 1, 2, 1, 4 }, { 3, -4, -2, 2 }, { 5, 3, 5, -1 } };
            ForwardElimination forwardElimination = new ForwardElimination(ref matrix);
            forwardElimination.Eliminate();
            BackwardSubstitution backwardSubstitution = new BackwardSubstitution(matrix);
            backwardSubstitution.Substitute();
        }

    }
}
