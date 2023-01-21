using Data_Structures._2.BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercises
{
    public static class Exercises_SlidingWindow
    {
        public static int MaximumSumOfConsecutiveNumbersBruteForce(int[] nums, int k)
        {
            var maxSum = 0;
            for (int i = 0; i <= nums.Length - k; i++)
            {
                var currentSum = 0;

                for (int j = i; j < k + i; j++)
                {
                    currentSum += nums[j];
                }

                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }
        public static int MaximumSumOfConsecutiveNumbers1(int[] nums, int k)
        {
            var maxSum = int.MinValue;
            var currentSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currentSum += nums[i];
                if (i >= k - 1) // We increment i and do the sum till we reach the end of our window
                {
                    maxSum = Math.Max(maxSum, currentSum); // We check if the sum is higher than the maximum sum
                    currentSum -= nums[i - (k - 1)]; // We substract the element at the start of the window 
                                                     // i is the current index where we are at and we need to do k-1 because of the index window.
                }
            }

            return maxSum;
        }

        public static int MaximumSumOfConsecutiveNumbers(int[] nums, int k)
        {
            var maxSum = int.MinValue;
            var currentSum = 0;

            // First window sum
            for (int i = 0; i < k; i++)
            {
                currentSum += nums[i];
            }

            for (int i = k; i < nums.Length; i++)
            {
                currentSum += nums[i] - nums[i - k];
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }

        // BAD LOOP 
        public static string Problem1(int[] arr, int k)
        {
            var stringBuilder = new StringBuilder();

            // Won't work this way because the loop will stop too son
            for (int i = 0; i < arr.Length - k; i++)
            {
                if (i >= k - 1)
                {
                    i += k;
                    stringBuilder.AppendLine();
                }

                stringBuilder.Append($"{arr[i]}");
            }

            return stringBuilder.ToString();
        }

        public static string Problem1_Try2(int[] arr, int k)
        {
            var stringBuilder = new StringBuilder();

            var j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                // This is more like a two pointer solution
                if (j > k - 1)
                {
                    stringBuilder.AppendLine();
                    j = 0;
                }
                stringBuilder.Append($"{arr[i]} ");

                j++;
            }

            return stringBuilder.ToString();
        }

        public static string Problem1_Try3(int[] arr, int k)
        {
            var queue = new Queue<int>();
            var whiteSpaceIndent = 0;

            for (int i = 0; i < k; i++)
            {
                queue.Enqueue(arr[i]);
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                queue.Dequeue();
                queue.Enqueue(arr[i + 1]);

                if (i + k <= arr.Length)
                    PrintTheWindowWithPointers_Try2(arr, i, i + k, whiteSpaceIndent);

                whiteSpaceIndent++;
            }

            return string.Empty;
        }

        private static void PrintTheWindowWithPointers_Try2(int[] arr, int leftPointer, int rightPointer, int indent)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(' ', indent);

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == leftPointer)
                    stringBuilder.Append("[ ");

                if (i == rightPointer)
                    stringBuilder.Append(" ]");

                stringBuilder.Append($"{arr[i]}");
            }

            if (rightPointer == arr.Length)
                stringBuilder.Append(" ]");

            Console.WriteLine(stringBuilder.ToString());
        }

        private static void PrintTheWindow_Try1(Queue<int> window)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append('[');
            foreach (var element in window)
            {
                stringBuilder.Append(element).Append(' ');
            }
            stringBuilder.Append(']');

            Console.WriteLine(stringBuilder.ToString());
        }

        public static int[][] Problem2(int[] arr, int k)
        {
            var res = Enumerable
                    .Range(0, arr.Length - (k - 1))
                    .Select(i => new int[arr.Length / (k - 1)])
                    .ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < k; i++)
            {
                queue.Enqueue(arr[i]);
            }

            Array.Copy(queue.ToArray(), res[0], 4);
            for (int i = k; i < arr.Length; i++)
            {
                queue.Enqueue(arr[i]);
                queue.Dequeue();
                Array.Copy(queue.ToArray(), res[Math.Abs(i - k + 1)], 4);
            }

            return res;
        }

        public static int[] Problem3(int[] arr, int k)
        {
            var res = new int[arr.Length - 2];
            var sum = 0;

            for (int i = 0; i < k; i++)
            {
                sum += arr[i];
            }

            res[0] = sum;
            for (int i = k - 1; i < arr.Length; i++)
            {
                if (i >= k)
                {
                    sum += arr[k + (i - k)];
                    sum -= arr[i - k];
                }

                res[i - 2] = sum;
            }

            return res;
        }

        public static int MinimumOfEachSubarraySlidingWindow(int[] arr, int k)
        {
            var minSum = 0;

            for (int i = 0; i < k; i++)
            {
                minSum += arr[i];
            }

            var currentSum = minSum;
            for (int i = k - 1; i < arr.Length - 1; i++)
            {
                currentSum += arr[i + 1];
                currentSum -= arr[i - k + 1];

                if (currentSum < minSum) minSum = currentSum;
            }

            return minSum;
        }

        public static int[] PairThatContainsMinimumElementInArray(int[] arr, int k)
        {
            var res = new int[2];
            var min = int.MaxValue;
            res[0] = arr[0];
            res[1] = arr[1];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (i >= k)
                {
                    Console.WriteLine($"Pair n1: {arr[i]} n2: {arr[i + (k - 1)]}");
                    if (min > arr[i] || min > arr[i + (k - 1)])
                    {
                        res[0] = arr[i];
                        res[1] = arr[i + (k - 1)];
                        if (min > arr[i]) min = arr[i];
                        else min = arr[i + (k - 1)];
                    }
                }
            }

            return res;
        }

        public static int CountGoodSubstrings0(string s)
        {
            var k = 3;
            var count = 0;

            for (int i = 0; i < s.Length - k + 1; i++)
            {
                if (s.Substring(i, k).ToHashSet().Count == 3) count++;
            }

            return count;
        }

        public static int CountGoodSubstrings(string s)
        {
            var charArray = s.ToCharArray();
            var k = 1;
            var count = 0;

            for (int i = k - 1; i < s.Length; i++)
            {
                if (charArray[i - k + 1] != charArray[i - 1] && 
                    charArray[i - k + 1] != charArray[i] &&
                    charArray[i - 1] != charArray[i])
                    count++;
            }

            return count;
        }
        /*
         owuxoelszb
        owu wux uxo xoe oel els lsz szb
         */
    }
}

/*
    My take with sliding window

----------------------------------------
--------- 1. Print in the console each window as you go forward in the array
           arr = [2,5,2,6,7,3,4,7,9,7,5] 
           k = 4
           How I iterate using sliding window
               [2,5,2,6] 7,3,4,7,9,7,5
                2 [5,2,6 7] 3,4,7,9,7,5
                   2 5 [2,6 7 3] 4,7,9,7,5
                     2 5 2 [6 7 3 4] 7,9,7,5
                       2 5 2 6 [7 3 4 7] 9,7,5
                         2 5 2 6 7 [3 4 7 9] 7,5
                           2 5 2 6 7 3 [4 7 9 7] 5
                             2 5 2 6 7 3 4 [7 9 7 5]

                [2,5,2,6] 7,3,4,7,9,7,5

           Notes:
                - We start with i which is the Left window bound and k-1 which is the Right window bound
                    - as long as i >= k-1 we are inside the window (e.g we can make a sum)

           Moving the window:
                - Unclear:
                    1. Increment i and k, till K is out of bounds, arr.Length - k 
                    2. Move by value arr[i] and arr[i-k-1]
                    

        Testcases: [2,5,2,6,7,3,4,7,9,7,5] k = 4
                   [3,5,2,4,7,1] k = 2
                   [2,5,8,4,7,9] k = 2

--------------------------------------------------------------  
---------- 2. Create a 2d array from each window 
                    arr = [2,3,5,2,6,7,3,4,7,9,7,5] 
                    k = 4

                    2dArray
                        (a) [2,3,5,2]
                            [6,7,3,4]
                            [7,9,7,5]
                    More like a two pointer approach.

                        (b) [2,3,5,2]
                            [3,5,2,6]
                            [5,2,6,7]
                            [2,6,7,3]
                            [6,7,3,4]
                            [7,3,4,7]
                            [3,4,7,9]
                            [4,7,9,7]
                            [7,9,7,5]
                    
                        arr.length = 12 => 4x9 matrix 
                                        => row = arr.length / (k-1)
                                        => col = arr.length - (k-1)

                        As I add i to k in a queue
                            i >= k-1
                                Convert queue to array and add it as a row
                                Dequeue value
                                Enqueue next value

           3. Create an array with sum of each window
                   arr = [2,3,5,2,6,7,3,1,7,9,7,5] k = 3

                    2+3+5 = 10
                    3+5+2 = 10
                    5+2+6 = 13
                    2+6+7 = 15
                    6+7+3 = 16
                    7+3+4 = 14
                    3+4+7 = 14
                    4+7+9 = 20
                    7+9+7 = 23
                    9+7+5 = 21

           4. Create an array with minimum sum of each window
           5. Return pair with minimum value
           6. Create an array with median of each window
           7. Sum of all medians  
           8. Increase, Decrease window by even numbers   
           9. Print in the console each window as you go forward in the 2d array
                e.g  1
                    1 * * * * * * *     
                    * 1 * * * * * * 
                    1 * 1 * * * * *
                    * 1 * 1 * * * *
                    * * 1 * 1 * * *
                    * * * 1 * 1 * *
                    * * * * 1 * 1 *
                    * * * * * 1 * 1
                     
                e.g 2
                    * 1 * * * * * *
                    * * 1 * * * * * 
                    1 * * 1 * * * *
                    * 1 * * 1 * * *
                    * * 1 * * 1 * *
                    * * * 1 * * 1 *
                    * * * * 1 * * 1
                    * * * * * 1 * *
               e.g 3
                    Opposite diagonal

            9. Leetcode Problems.
 */


