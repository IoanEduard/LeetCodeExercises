using _HelperFunctions;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercises
{
    public static class Exercises_LeetCode
    {
        public static bool UniqueOccurrences(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            var hashset = new HashSet<int>();

            for (var i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i], 1);
                }
                else
                {
                    dict[arr[i]]++;
                }
            }

            foreach (var item in dict)
            {
                if (hashset.Contains(item.Value)) return false;

                hashset.Add(item.Value);
            }

            return true;
        }

        public static bool UniqueOccurrences_Linq(int[] arr)
        {
            var result = arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            return result.Values.Distinct().Count() == result.Count();
        }

        public static bool UniqueOccurrences_Linq2(int[] arr)
        {
            return !arr.GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count())
                .GroupBy(x => x.Value)
                .Any(x => x.Count() > 1);
        }

        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            return nums1.Intersect(nums2).ToArray();
        }

        public static int[] Intersection_2(int[] nums1, int[] nums2)
        {
            var nums1HashSet = nums1.ToHashSet();
            var result = new HashSet<int>();

            foreach (var item in nums2)
            {
                if (nums1HashSet.Contains(item))
                {
                    nums1HashSet.Remove(item);
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        public static int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var result = new List<int>();
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < nums2.Length; i++)
            {
                dict.Add(nums2[i], i);
            }

            for (var i = 0; i < nums1.Length; i++)
            {
                var nextIndex = dict[nums1[i]] + 1;

                if (nextIndex >= nums2.Length)
                {
                    result.Add(-1);
                    continue;
                }

                for (var j = nextIndex; j < nums2.Length; j++)
                {
                    if (nums2[j] > nums2[dict[nums1[i]]])
                    {
                        result.Add(nums2[j]);
                        break;
                    }

                    if (j == nums2.Length - 1)
                    {
                        result.Add(-1);
                    }
                }
            }

            return result.ToArray();
        }

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            // 💩💩💩💩💩💩💩💩💩💩💩💩
            var result = 0;
            var count = 1;

            for (var i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                if (count > result)
                {
                    result = count;
                }
            }

            return result;
        }

        public static int FindMaxConsecutiveOnes_1(int[] nums)
        {
            var resultCount = 0;
            var currentCount = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 0;
                }

                if (currentCount > resultCount) resultCount = currentCount;
            }

            return resultCount;
        }

        public static int Search(int[] nums, int target)
        {
            var result = BinarySearchLoop(nums, target, 0, nums.Length - 1);

            return result;
        }

        private static int BinarySearch(int[] nums, int target, int left, int right)
        {
            // 💩💩💩💩💩💩💩💩💩💩💩💩 C# no tail recursion
            if (left >= right)
            {
                return -1;
            }
            else
            {
                var mid = (left + right) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    return BinarySearch(nums, target, mid + 1, right);
                }
                else
                {
                    return BinarySearch(nums, target, left, mid + 1);
                }
            }
        }

        private static int BinarySearchLoop(int[] nums, int target, int left, int right)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        public static bool HalvesAreAlike(string s, char[] vowels)
        {
            var middle = (int)Math.Ceiling((decimal)(s.Length - 1) / 2);

            var start = s.Substring(0, middle);
            var startCount = 0;

            var end = s.Substring(middle, Math.Abs(s.Length - middle));
            var endCount = 0;

            for (var i = 0; i < start.Length; i++)
            {
                if (vowels.Contains(start[i])) startCount++;
            }

            for (var i = 0; i < end.Length; i++)
            {
                if (vowels.Contains(end[i])) endCount++;
            }

            return startCount == endCount;
        }

        public static string DefangIPaddr(string address)
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < address.Length; i++)
            {
                if (address[i] != '.')
                {
                    stringBuilder.Append(address[i]);
                    continue;
                }

                stringBuilder.Append("[.]");
            }

            return stringBuilder.ToString();
        }

        public static string ToGoatLatin(string sentence, char[] wovewlsUpperCase)
        {
            var words = sentence.Split(' ');
            var stringBuilder = new StringBuilder();
            var increasingChars = new StringBuilder();

            for (var i = 0; i < words.Length; i++)
            {
                increasingChars.Append(string.Concat(Enumerable.Repeat('a', i + 1)));

                var whiteSpace = i == words.Length - 1 ? "" : " ";

                if (wovewlsUpperCase.Contains(words[i][0]))
                {
                    stringBuilder.Append(words[i] + "ma" + increasingChars.ToString() + whiteSpace);
                }
                else
                {
                    var firstLetter = words[i][0];
                    var wordWitoutFirstChar = words[i].Remove(0, 1);

                    stringBuilder.Append(wordWitoutFirstChar + firstLetter + "ma" + increasingChars.ToString() + whiteSpace);
                }

                increasingChars.Clear();
            }

            return stringBuilder.ToString();
        }

        public static string GenerateTheString(int n)
        {
            return n % 2 == 1 ? new string('a', n) : "a" + new string('b', n - 1);
        }

        public static string[] FindOcurrences(string text, string first, string second)
        {
            var splitText = text.Split(' ');
            var result = new List<string>();

            for (var i = 0; i < splitText.Length - 2; i++)
            {
                if (splitText[i] == first && splitText[i + 1] == second)
                {
                    result.Add(splitText[i + 2]);
                }
            }

            return result.ToArray();
        }

        public static string RemoveOuterParentheses(string s)
        {
            var sr = new StringBuilder();
            var count = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    if (count > 0)
                        sr.Append(s[i]);
                    count++;
                }
                else
                {
                    if (count > 1)
                        sr.Append(s[i]);
                    count--;
                }
            }

            return sr.ToString();
        }

        public static int ArrayPairSum(int[] nums)
        {
            var result = 0;
            Array.Sort(nums);

            for (var i = 0; i < nums.Length; i += 2)
            {
                result += nums[i];
            }

            return result;
        }

        public static int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            var result = 0;

            for (var i = 0; i < timeSeries.Length - 1; i++)
            {
                var sum = timeSeries[i] + duration;
                if (sum <= timeSeries[i + 1])
                {
                    result += sum;
                }

                if (sum > timeSeries[i + 1])
                {
                    result += timeSeries[i + 1] - timeSeries[i];
                }
            }

            result += duration;

            return result;
        }

        public static int[] SortArrayByParityII(int[] nums)
        {
            var result = new int[nums.Length];

            var even = 0;
            var odd = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    result[even] = nums[i];
                    even += 2;
                }

                if (nums[i] % 2 != 0)
                {
                    result[odd] = nums[i];
                    odd += 2;
                }
            }

            return result;
        }

        public static bool IsPalindrome(string s)
        {
            var start = 0;
            var end = s.Length - 1;

            while (start < (s.Length - 1) / 2)
            {
                if (!char.IsLetterOrDigit(s[start]))
                {
                    start++;
                    continue;
                }

                if (!char.IsLetterOrDigit(s[end]))
                {
                    end--;
                    continue;
                }

                if (char.ToLower(s[start]) != char.ToLower(s[end]))
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }

        public static int[] SortedSquares(int[] nums)
        {
            var result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i] * nums[i];
            }

            Array.Sort(nums);

            return nums;
        }

        public static int[] SortedSquares2(int[] nums)
        {
            var result = new int[nums.Length];

            var start = 0;
            var end = nums.Length - 1;

            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (Math.Abs(nums[start]) >= Math.Abs(nums[end]))
                {
                    result[i] = nums[start] * nums[start];
                    start++;
                }
                else
                {
                    result[i] = nums[end] * nums[end];
                    end--;
                }
            }

            return result;
        }

        public static int[] SortedSquares3(int[] nums)
        {
            var result = new int[nums.Length];

            var start = 0;
            var end = nums.Length - 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] = Math.Abs(nums[start]) >= Math.Abs(nums[end])
                    ? nums[start] * nums[start++]
                    : nums[end] * nums[end--];
            }

            return result;
        }
        public static int[] SortArrayByParityII2(int[] nums)
        {
            var result = new int[nums.Length];
            var start = 0;
            var startOdd = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    result[start] = nums[i];
                    start += 2;
                }
                else
                {
                    result[startOdd] = nums[i];
                    startOdd += 2;
                }
            }

            return result;
        }

        public static IList<string> CommonChars(string[] words)
        {
            var dict = new Dictionary<char, int>();
            var tempDictionary = new Dictionary<char, int>();

            foreach (char character in words[0])
            {
                if (dict.ContainsKey(character))
                {
                    dict[character]++;
                }
                else
                {
                    dict.Add(character, 1);
                }
            }

            for (var i = 0; i < words.Length; i++)
            {
                var dict2 = new Dictionary<char, int>();

                for (int j = 0; j < words[i].Length; j++)
                {
                    if (dict2.ContainsKey(words[i][j]))
                    {
                        dict2[words[i][j]]++;
                    }
                    else
                    {
                        dict2.Add(words[i][j], 1);
                    }
                }

                foreach (var key in dict.Keys)
                {
                    if (dict2.ContainsKey(key))
                    {
                        tempDictionary.Add(key, Math.Min(dict[key], dict2[key]));
                    }
                }

                dict = tempDictionary;
                tempDictionary = new Dictionary<char, int>();
            }

            var list = new List<string>();

            foreach (var item in dict)
            {
                list.AddRange(Enumerable.Repeat(item.Key.ToString(), item.Value));
            }

            return list;
        }

        public static void ReverseString(char[] s)
        {
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }
        }

        public static int FirstUniqChar(string s)
        {
            var isDuplicate = false;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (isDuplicate == false && i != j)
                    {
                        if (s[i] == s[j])
                        {
                            isDuplicate = true;
                            break;
                        }
                    }
                }

                if (isDuplicate == false)
                    return i;

                isDuplicate = false;
            }

            return -1;
        }

        public static bool CanConstruct(string ransomNote, string magazine)
        {
            var dict = new Dictionary<char, int>();

            foreach (var character in magazine)
            {
                if (dict.ContainsKey(character))
                {
                    dict[character]++;
                }
                else
                {
                    dict.Add(character, 1);
                }
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (dict.ContainsKey(ransomNote[i]))
                {
                    if (dict[ransomNote[i]] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        dict[ransomNote[i]]--;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static IList<string> FizzBuzz(int n)
        {
            var list = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    list.Add("FizzBuzz");
                    continue;
                }

                if (i % 3 == 0)
                {
                    list.Add("Fizz");
                    continue;
                }

                if (i % 5 == 0)
                {
                    list.Add("Buzz");
                    continue;
                }

                list.Add(i.ToString());
            }

            return list;
        }

        public static string[] FindWords(string[] words)
        {
            var hash1 = new HashSet<char> { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            var hash2 = new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            var hash3 = new HashSet<char> { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };

            var result = new List<string>();

            var flag = true;
            for (int i = 0; i < words.Length; i++)
            {
                if (hash1.Contains(char.ToLower(words[i][0])))
                {
                    foreach (var character in words[i].ToLower())
                    {
                        if (!hash1.Contains(character))
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag == true)
                        result.Add(words[i]);
                }

                else if (hash2.Contains(char.ToLower(words[i][0])))
                {
                    foreach (var character in words[i].ToLower())
                    {
                        if (!hash2.Contains(character))
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag == true)
                        result.Add(words[i]);
                }

                else if (hash3.Contains(char.ToLower(words[i][0])))
                {
                    foreach (var character in words[i].ToLower())
                    {
                        if (!hash3.Contains(character))
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag == true)
                        result.Add(words[i]);
                }
                flag = true;
            }

            return result.ToArray();
        }

        public static bool JudgeCircle(string moves)
        {
            var upDown = 0;
            var leftRight = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'U':
                        upDown++;
                        break;
                    case 'D':
                        upDown--;
                        break;
                    case 'L':
                        leftRight++;
                        break;
                    case 'R':
                        leftRight--;
                        break;
                    default:
                        break;
                }
            }

            return upDown == 0 && leftRight == 0;
        }

        public static int NumJewelsInStones(string jewels, string stones)
        {
            var dict = new Dictionary<char, int>();

            foreach (var jewel in jewels)
            {
                dict.InsertOrIncrement(jewel);
            }

            for (int i = 0; i < stones.Length; i++)
            {
                if (dict.ContainsKey(stones[i]))
                {
                    dict[stones[i]]++;
                }
            }

            return dict.Values.Sum() - dict.Values.Count();
        }

        public static int BalancedStringSplit(string s)
        {
            var result = 0;
            var rCounter = 0;
            var lCounter = 0;

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'R':
                        rCounter++;
                        break;
                    case 'L':
                        lCounter++;
                        break;
                    default:
                        break;
                }
                if (lCounter == rCounter && i > 0) result++;
            }

            return result;
        }

        public static bool IsValid(string s)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                var stackValue = new char();
                stack.TryPeek(out stackValue);

                if ((stackValue == '(' && s[i] == ')')
                    || (stackValue == '[' && s[i] == ']')
                    || (stackValue == '{' && s[i] == '}'))
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(s[i]);
                }
            }

            return !(stack.Count > 0);
        }

        // Wrong way
        public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            var dictionary = new Dictionary<char, int>();

            foreach (var word in word1)
            {
                foreach (var character in word)
                {
                    dictionary.InsertOrIncrement<char>(character);
                }
            }

            for (int i = 0; i < word2.Length; i++)
            {
                for (int j = 0; j < word2[i].Length; j++)
                {
                    dictionary.RemoveOrDecrement<char>(word2[i][j]);
                }
            }

            return dictionary.Count() > 0;
        }

        public static bool ArrayStringsAreEqualStack(string[] word1, string[] word2)
        {
            return string.Concat(word1).Equals(string.Concat(word2));
        }

        public static int[][] LargestLocal(int[][] grid)
        {
            int[][] result = new int[grid.Length - 2][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[grid.Length - 2];
            };

            for (int i = 0; i < grid.Length - 2; ++i)
            {
                for (int j = 0; j < grid.Length - 2; ++j)
                {
                    for (int k = i; k < i + 3; ++k)
                    {
                        for (int l = j; l < j + 3; ++l)
                        {
                            result[i][j] = Math.Max(result[i][j], grid[k][l]);
                        }
                    }
                }
            }

            return result;
        }

        public static int DiagonalSum0(int[][] mat)
        {
            var sum = 0;

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat.Length; j++)
                {
                    if (i == j)
                    {
                        sum += mat[i][j];
                    }
                }
            }

            for (int n = 0; n < mat.Length; n++)
            {
                sum += mat[n][mat[0].Length - n - 1];
            }

            if (mat[0].Length % 2 != 0)
                sum -= mat[mat.Length / 2][mat[0].Length / 2];

            return sum;
        }

        public static int DiagonalSum(int[][] mat)
        {
            var sum = 0;

            for (int n = 0; n < mat.Length; n++)
            {
                sum += mat[n][n];
                sum += mat[n][mat[0].Length - n - 1];
            }

            if (mat[0].Length % 2 != 0)
                sum -= mat[mat.Length / 2][mat[0].Length / 2];

            return sum;
        }

        public static int CountNegatives(int[][] grid)
        {
            var count = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = grid[i].Length - 1; j >= 0; j--)
                {
                    if (grid[i][j] < 0)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return count;
        }

        // Cool solution, doesn't work for all testCases
        public static bool CheckValid(int[][] matrix)
        {
            var desiredSum = matrix[0].Length * (matrix[0].Length + 1) / 2;
            var colSum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                var rowSum = 0;

                for (int j = 0; j < matrix.Length; j++)
                {
                    colSum += matrix[i][j];
                    rowSum += matrix[j][i];
                }

                if (colSum != desiredSum) return false;
                if (rowSum != desiredSum) return false;

                colSum = 0;
            }

            return true;
        }

        public static bool CheckValid2(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var hashsetCol = new HashSet<int>();
                var hashsetRow = new HashSet<int>();

                for (int j = 0; j < matrix.Length; j++)
                {
                    if (!hashsetCol.Add(matrix[i][j]) || !hashsetRow.Add(matrix[j][i])) return false;
                }
            }

            return true;
        }

        public static int[][] FlipAndInvertImage(int[][] image)
        {

            for (int i = 0; i < image.Length; i++)
            {
                for (int j = 0; j < image.Length / 2; j++)
                {
                    var temp = image[i][j] ^ 1;
                    image[i][j] = image[i][image.Length - j - 1] ^ 1;
                    image[i][image.Length - j - 1] = temp;
                }
            }

            return image;
        }

        public static int[][] ReverseMatrix(int[][] image)
        {
            for (int i = 0; i < image.Length; i++)
            {
                var temp = image[i];
                image[i] = image[image.Length - i - 1];
                image[image.Length - i - 1] = temp;
            }

            return image;
        }
        public static int[][] ReverseRowsInMatrix(int[][] image)
        {
            for (int i = 0; i < image.Length / 2; i++)
            {
                for (int j = 0; j < image.Length; j++)
                {
                    var temp = image[i][j];
                    image[i][j] = image[image.Length - i - 1][j];
                    image[image.Length - i - 1][j] = temp;
                }
            }

            return image;
        }

        public static int MaximumWealth(int[][] accounts)
        {
            var max = int.MinValue;

            for (int i = 0; i < accounts.Length; i++)
            {
                var sum = accounts[i].Sum();
                if (sum > max) max = sum;
            }

            return max;
        }

        public static int MaximumWealth2(int[][] accounts)
        {
            var max = int.MinValue;

            for (int i = 0; i < accounts.Length; i++)
            {
                var sum = 0;
                for (int j = 0; j < accounts[i].Length; j++)
                {
                    sum += accounts[accounts.Length - i - 1][j];
                }
                if (sum > max) max = sum;
            }

            return max;
        }

        public static int[] KWeakestRows(int[][] mat, int k)
        {
            var dictionaryRowSoldierCount = new Dictionary<int, int>();

            for (int i = 0; i < mat.Length; i++)
            {
                dictionaryRowSoldierCount.Add(i, 0);

                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        dictionaryRowSoldierCount[i]++;
                    }
                }
            }

            return dictionaryRowSoldierCount.OrderBy(x => x.Value).Take(k).Select(x => x.Key).ToArray();
        }

        public static int FindLucky(int[] arr)
        {
            var luckyNumbersDictionary = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                luckyNumbersDictionary.InsertOrIncrement(arr[i]);
            }

            foreach (var item in luckyNumbersDictionary)
            {
                if (item.Key != item.Value) luckyNumbersDictionary.Remove(item.Key);
            }

            return luckyNumbersDictionary.Count() > 0 ? luckyNumbersDictionary.Max(item => item.Value) : -1;
        }

        public static bool IsToeplitzMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 1; i++)
                for (int j = 0; j < matrix[i].Length - 1; j++)
                    if (matrix[i][j] != matrix[i + 1][j + 1]) return false;

            return true;
        }

        public static int[][] Transpose(int[][] matrix)
        {
            var result = new int[matrix[0].Length][];

            for (int i = 0; i < matrix[0].Length; i++)
            {
                result[i] = new int[matrix.Length];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    result[j][i] = matrix[i][j];
                }
            }

            return result;
        }
        public static int[][] Construct2DArray(int[] original, int m, int n)
        {
            if (original.Length != m * n) return Array.Empty<int[]>();

            var result = new int[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
            }
            var k = 0;
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    result[i][j] = original[k++];
                }
            }

            return result;
        }

        public static int[] BuildArray(int[] nums)
        {
            var result = new int[nums.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = nums[nums[i]];
            }

            return result;
        }

        public static int[] GetConcatenation(int[] nums)
        {
            //return nums.Concat(nums).ToArray();

            var result = new int[nums.Length * 2];

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i];
                result[i + nums.Length] = nums[i];
            }

            return result;
        }

        public static int FinalValueAfterOperations(string[] operations)
        {
            var x = 0;

            for (int i = 0; i < operations.Length; i++)
            {
                switch (operations[i])
                {
                    case "++X":
                    case "X++":
                        x++;
                        break;
                    case "--X":
                    case "X--":
                        x--;
                        break;
                }
            }

            return x;
        }

        public static int[] RunningSum(int[] nums)
        {
            var result = new int[nums.Length];
            result[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = nums[i] + nums[i - 1];
            }

            return result;
        }

        public static int NumIdenticalPairs(int[] nums)
        {
            var count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j] && i < j) count++;
                }
            }

            return count;
        }

        public static int[] Shuffle1(int[] nums, int n)
        {
            var list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(nums[i]);
                list.Add(nums[n + i]);
            }

            return list.ToArray();
        }

        public static int[] Shuffle(int[] nums, int n)
        {
            var arr = new int[nums.Length];

            var j = 0;
            for (int i = 0; i < n; i++)
            {
                arr[j] = nums[i];
                arr[j + 1] = nums[i + n];
                j += 2;
            }

            return arr;
        }

        public static int MostWordsFound(string[] sentences)
        {
            var max = int.MinValue;
            foreach (var item in sentences)
            {
                var sentencesWords = item.Split(' ');
                if (max < sentencesWords.Length) max = sentencesWords.Length;
            }

            return max;
        }

        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var res = new bool[candies.Length];
            var max = candies.Max();

            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] + extraCandies >= max)
                {
                    res[i] = true;
                }
            }

            return res;
        }

        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                var count = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j && nums[i] > nums[j])
                        count++;
                }
                res[i] = count;
            }

            return res;
        }

        public static int[] CreateTargetArray_NotCool(int[] nums, int[] index)
        {
            var res = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                res.Insert(nums[i], index[i]);
            }

            return res.ToArray();
        }
        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            var res = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == index[i])
                {
                    res[index[i]] = nums[i];
                }
                else
                {
                    var temp = 0;
                    for (int j = index[i]; j < i + 1; j++)
                    {
                        temp = res[j];
                        res[j] = nums[i];
                        nums[i] = temp;
                    }
                }
            }

            return res;
        }

        public static int[] Decode(int[] encoded, int first)
        {
            var res = new int[encoded.Length + 1];

            res[0] = first;
            for (int i = 0; i < encoded.Length; i++)
            {
                res[i + 1] = encoded[i] ^ res[i];
            }

            return res;
        }

        public static int[] DecompressRLElist(int[] nums)
        {
            var list = new List<int>();

            for (int i = 0; i < nums.Length; i += 2)
            {
                for (int j = 0; j < nums[i]; j++)
                {
                    list.Add(nums[i + 1]);
                }
            }

            return list.ToArray();
        }

        public static string RestoreString(string s, int[] indices)
        {
            var charArr = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                charArr[indices[i]] = s[i];
            }

            return new string(charArr);
        }

        public static int MaximumValue(string[] strs)
        {
            var count = 0;
            var max = int.MinValue;
            foreach (var item in strs)
            {
                if (int.TryParse(item, out int value))
                {
                    count = value;
                }
                else
                {
                    count = item.Length;
                }

                if (count > max) max = count;
            }

            return max;
        }

        public static int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            var count = 0;
            var indexRuleKey = 0;

            switch (ruleKey)
            {
                case "type":
                    indexRuleKey = 0;
                    break;
                case "color":
                    indexRuleKey = 1;
                    break;
                case "name":
                    indexRuleKey = 2;
                    break;
            }

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i][indexRuleKey] == ruleValue)
                {
                    count++;
                }
            }

            return count;
        }
        public static int ArithmeticTriplets(int[] nums, int diff)
        {
            var count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[j] - nums[i] == diff && nums[k] - nums[j] == diff)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        public static int[] TwoSumBruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target) return new int[] { i, j };
                }
            }

            return new int[2];
        }
        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];

                if (dict.ContainsKey(diff))
                {
                    return new int[] { dict[diff], i };
                }
                else
                {
                    dict.Add(diff, i);
                }
            }

            return new int[2];
        }

        public static int CountKDifference(int[] nums, int k)
        {
            var count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) == k)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int CountPairs(int[] nums, int k)
        {
            var count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j] && i * j == k)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static string TruncateSentence(string s, int k)
        {
            var split = s.Split(' ');
            return string.Join(' ', split.SkipLast(split.Length - k));
        }

        public static int MinMovesToSeat(int[] seats, int[] students)
        {
            Array.Sort(seats);
            Array.Sort(students);

            var moves = 0;

            for (int i = 0; i < seats.Length; i++)
            {
                for (int j = 0; j < students.Length; j++)
                {
                    moves += Math.Abs(seats[i] - students[j]);
                }
            }

            return moves;
        }

        public static int CountConsistentStrings(string[] words, string allowed)
        {
            var result = words.Length;

            var hashset = new HashSet<char>(allowed);

            for (int i = 0; i < words.Length; i++)
            {
                foreach (var character in words[i].ToCharArray())
                {
                    if (!allowed.Contains(character))
                    {
                        result--;
                        break;
                    }
                }
            }

            return result;
        }
        public static string Interpret(string command)
        {
            if (command.Length == 1 && char.IsLetter(command[0]))
                return command;

            var sr = new StringBuilder();
            for (int i = 0; i < command.Length - 1; i++)
            {
                if (command[i] == '(' && command[i + 1] == ')')
                {
                    sr.Append('o');
                    i++;
                }

                if (char.IsLetter(command[i]))
                    sr.Append(command[i]);

                if (i + 1 == command.Length - 1 && char.IsLetter(command[i + 1]))
                    sr.Append(command[command.Length - 1]);
            }

            return sr.ToString();
        }

        public static IList<string> CellsInRange(string s)
        {
            char leftLetter = s[0];
            char rightLetter = s[3];
            var leftRange = int.Parse(s.Substring(1, 1));
            var rightRange = int.Parse(s.Substring(s.Length - 1, 1));

            var result = new List<string>();
            for (char i = leftLetter; i <= rightLetter; i++)
            {
                for (int j = leftRange; j <= rightRange; j++)
                {
                    result.Add((i.ToString() + j).ToString());
                }
            }

            return result;
        }

        public static bool IsPalindrome(int x)
        {
            var result = 0;
            var temp = x;

            while (temp > 0)
            {
                var rest = temp % 10;
                result = result * 10 + rest;
                temp /= 10;
            }
            return result == x;
        }

        public static int MaxScore(int[] cardPoints, int k)
        {
            var currentSum = 0;
            var maxScore = int.MinValue;
            var pointerRight = 0;

            for (int i = 0; i < k; i++)
            {
                currentSum += cardPoints[i];
            }

            maxScore = currentSum;
            for (var i = 0; i < k; i++)
            {
                currentSum += cardPoints[cardPoints.Length - pointerRight - 1];
                currentSum -= cardPoints[k - i - 1];

                maxScore = Math.Max(maxScore, currentSum);
                pointerRight++;
            }

            return maxScore;
        }

        public static int MaxScoreLeetCodeSolution(int[] cardPoints, int k)
        {
            var n = cardPoints.Length;
            var res = 0;

            // n - k makes more sense, in my solution I started from the left prefix sum
            for (int i = n - k; i < n; i++) res += cardPoints[i];

            for (int i = 0, s = res; i < k; i++)
            {
                s -= cardPoints[n - k + i];
                s += cardPoints[i];
                res = Math.Max(res, s);
            }

            return res;
        }

        public static int MinimumRecolors(string blocks, int k)
        {
            var recolorCount = 0;
            var minimumRecolorCount = int.MaxValue;
            var len = blocks.Length;

            for (int i = 0; i < len; i++)
            {
                if (blocks[i] == 'W') recolorCount++;

                if (i >= k - 1)
                {
                    if (recolorCount < minimumRecolorCount)
                        minimumRecolorCount = recolorCount;

                    if (blocks[i - (k - 1)] == 'W')
                    {
                        recolorCount--;
                    }
                }
            }

            return minimumRecolorCount;
        }

        public static string ConvertToTitle(int columnNumber)
        {
            var dictionary = new Dictionary<int, char>();
            var i = 1;
            var division = 0;
            var remainder = 0;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                dictionary.Add(i++, c);
            }

            if (columnNumber <= 26) return dictionary[columnNumber].ToString();

            while (division > 26)
            {
                division = columnNumber / 26;
                remainder = columnNumber - (division * 26);
            }

            //division = columnNumber / 26;
            //remainder = columnNumber - (division * 26);

            return new string(new char[] { dictionary[division], dictionary[remainder] });
        }

        public static string ConvertToBase26FirstTry(int columnNumber)
        {
            var temp = columnNumber;
            var stringBuilder = new StringBuilder();

            var dictionary = new Dictionary<int, char>();
            var i = 1;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                dictionary.Add(i++, c);
            }

            if (columnNumber <= 26) return dictionary[columnNumber].ToString();

            while (temp > 0)
            {
                temp--;
                var character = (dictionary[temp % 26 + 1]);
                stringBuilder.Append(character);
                temp = temp / 26;
            }

            var result = stringBuilder.ToString().ToCharArray();
            Array.Reverse(result);

            return new string(result);
        }

        public static string ConvertToBase26(int columnNumber)
        {
            var temp = columnNumber;
            var stack = new Stack<char>();

            while (temp > 0)
            {
                temp--;
                stack.Push((char)(temp % 26 + 'A'));
                temp = temp / 26;
            }

            return string.Join("", stack);
        }

        public static int MajorityElement(int[] nums)
        {
            Array.Sort(nums);

            return nums[nums.Length / 2];
        }

        public static int MostFrequentEven(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 != 0) continue;

                if (!dictionary.ContainsKey(nums[i]))
                    dictionary.Add(nums[i], 0);

                dictionary[nums[i]]++;
            }

            if (dictionary.Count() == 0) return -1;

            var result = 0;
            var maximumCount = int.MinValue;

            foreach (var element in dictionary)
            {
                if (element.Value > maximumCount || element.Value == maximumCount && element.Key < result)
                {
                    result = element.Key;
                    maximumCount = element.Value;
                }
            }

            return result;
        }

        public static int TitleToNumber(string columnTitle)
        {
            var dictionary = new Dictionary<char, int>();
            var j = 1;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                dictionary.Add(c, j++);
            }

            if (columnTitle.Length == 1) return dictionary[columnTitle[0]];

            var res = dictionary[columnTitle[0]] * 26;

            for (int i = 1; i < columnTitle.Length - 1; i++)
            {
                var val = dictionary[columnTitle[i]] * 26;
                res = res * 26 + val;
            }

            return res + dictionary[columnTitle[columnTitle.Length - 1]];
        }

        public static int CountSegments1(string s)
        {
            var sr = new StringBuilder();
            var whitespaceCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s[i]))
                {
                    sr.Append(s[i]);
                    whitespaceCount = 0;
                }

                if (char.IsWhiteSpace(s[i]))
                {
                    whitespaceCount++;
                    if (whitespaceCount == 1)
                    {
                        sr.Append(s[i]);
                    }
                }
            }

            var ss = sr.ToString().Trim();
            if (ss == string.Empty) return 0;

            return ss.Split(' ').Length;
        }

        public static int CountSegments(string s)
        {
            if (s == string.Empty) return 0;
            if (s.Length == 1 && !char.IsWhiteSpace(s[0])) return 1;
            var count = 0;

            if (!char.IsWhiteSpace(s[0])) count++;

            for (int i = 1; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s[i]) && char.IsWhiteSpace(s[i - 1]))
                    count++;
            }

            return count;
        }

        public static bool CanBeIncreasing(int[] nums)
        {
            var count = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] <= nums[i - 1])
                {
                    count++;
                    if (count > 1) break;
                    if (i > 1 && nums[i] <= nums[i - 2])
                    {
                        nums[i] = nums[i - 1];
                    }
                }
            }

            return count < 2;
        }

        public static double[] ConvertTemperature(double celsius)
        {
            return new double[] { celsius * 1.8 + 32, celsius + 273.15 };
        }

        public static int SmallestEvenMultiple(int n)
        {
            if (n % 2 == 0 && n % n == 0)
                return n;

            return SmallestEvenMultiple(n + n);
        }

        public static int DifferenceOfSum(int[] nums)
        {
            var sum = 0;
            var sumOfDigits = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                while (nums[i] > 0)
                {
                    sumOfDigits += nums[i] % 10;
                    nums[i] /= 10;
                }
            }

            return Math.Abs(sum - sumOfDigits);
        }

        public static int AddDigits(int num)
        {
            if (num % 9 == 0) return 9;

            return num % 9;
        }

        public static int GetLucky(string s, int k)
        {
            BigInteger temp = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int character = s[i] - 'a' + 1;

                if (character < 10 || i < 1)
                {
                    temp = temp * 10 + character;
                }
                else
                {
                    var tempCharacter = character;
                    while (tempCharacter > 0)
                    {
                        tempCharacter /= 10;
                        temp = temp * 10;
                    }

                    temp = temp + character;
                }
            }

            BigInteger res = 0;
            while (k > 0)
            {
                res += temp % 10;
                temp = temp / 10;
                if (temp < 10)
                {
                    res += temp;
                    temp = res;
                    if (k > 1) res = 0;
                    k--;
                }
            }

            return (int)res;
        }

        public static int MinimumSum(int num)
        {
            var arr = new int[4];

            for (int i = 0; i < 4; i++)
            {
                arr[i] = num % 10;
                num /= 10;
            }

            Array.Sort(arr);

            return (arr[0] * 10 + arr[2]) + (arr[1] * 10 + arr[3]);
        }

        public static int CountEven(int num)
        {
            var count = 0;

            for (int i = 0; i < num; i++)
            {
                var sum = 0;
                var nr = i;
                while (nr > 0)
                {
                    var temp = nr % 10;
                    nr /= 10;
                    sum += temp;
                }

                if (sum % 2 == 0) count++;
            }

            return count;
        }

        public static bool IsHappy(int n)
        {
            var temp = n;
            var hashset = new HashSet<int>();

            var sum = 0;
            while (true)
            {
                var remainder = (int)Math.Pow(temp % 10, 2);
                sum += remainder;
                temp /= 10;

                if (temp < 1)
                    if (sum == 1) return true;

                if (temp < 1)
                {
                    if (!hashset.Add(sum)) return false;

                    hashset.Add(sum);
                    temp = sum;
                    sum = 0;
                }
            }
        }

        public static bool IsUgly(int n)
        {
            if (n <= 0) return false;

            var primes = new int[] { 2, 3, 5 };

            while (n > 0)
            {
                for (var i = 0; i < primes.Length; i++)
                {
                    if (n == 1) return true;
                    if (n % primes[i] == 0)
                    {
                        n /= primes[i];
                        break;
                    }

                    if (i == primes.Length - 1)
                        return false;
                }
            }

            return true;
        }

        public static int MinMaxGame(int[] nums)
        {
            return 0;
        }

        public static long WaysToBuyPensPencils(int total, int cost1, int cost2)
        {
            if (cost1 + cost2 > total) return 1;

            var sum = 0l;
            sum += (int)Math.Floor((double)total / cost1);
            sum += (int)Math.Floor((double)total / cost2);
            sum += (int)Math.Floor((double)total / (cost1 + cost2));
            sum += (int)Math.Floor((double)cost1 / cost2);

            return sum;
        }

        public static string DigitSum(string s, int k)
        {
            var stringBuilder = new StringBuilder();

            while (stringBuilder.ToString().Length != k)
            {
                var j = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    stringBuilder.Append(s[i]);
                    if (stringBuilder.ToString().Length == k)
                    {

                    }
                }
            }

            return stringBuilder.ToString();
        }

        public static int XorOperation(int n, int start)
        {
            var res = 0;

            for (int i = 0; i < n; i++)
                res = res ^ (start + 2 * i);

            return res;
        }

        public static string FreqAlphabets(string s)
        {
            var stack = new Stack<char>();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '#')
                {
                    var nrIndex = s.IndexOf(s[i], i);
                    var number = int.Parse(s.Substring(nrIndex - 2, 2));
                    var character = (char)(number + 'a' - 1);
                    stack.Push(character);
                    i -= 2;
                }
                else
                {
                    char ch = s[i];
                    var character = (char)(ch -'0' + 96);
                    stack.Push(character);
                }

            }
            return new string(stack.ToArray());
        }
    }
}
