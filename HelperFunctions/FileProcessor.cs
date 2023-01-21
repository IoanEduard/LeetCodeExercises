using Newtonsoft.Json;
using System.Data.Common;

namespace _HelperFunctions
{
    public static class FileProcessor
    {
        public static int[][] ReadMatrixFromFile()
        {
            string file = File.ReadAllText("RawTestcases.txt");
            int[][] matrix = JsonConvert.DeserializeObject<int[][]>(file)
                .Where(array => array.Length > 0)
                .ToArray();

            return matrix;
        }
    }
}
