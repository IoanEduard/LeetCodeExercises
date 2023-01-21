using System.Text;
using Data_Structures._1.BasicTree;
using static System.Console;

namespace HelperFunctions
{
    public static class Display<T>
    {
        public static void DisplayCollection(IEnumerable<T> collection)
        {
            var sr = new StringBuilder();

            foreach (var item in collection)
            {
                sr.Append($"{item}");
                sr.Append(" ");
            }

            WriteLine(sr.ToString());
        }

        public static void DisplaySingleResult(T input)
        {
            WriteLine(input);
        }

        public static void DisplayMatrix(int[][] matrix)
        {
            for (int n = 0; n < matrix.Length; n++)
            {
                Write("Row({0}): ", n);
                for (int k = 0; k < matrix[n].Length; k++)
                {
                    Write("{0} ", matrix[n][k]);
                }
                WriteLine();
            }
        }
    }
}