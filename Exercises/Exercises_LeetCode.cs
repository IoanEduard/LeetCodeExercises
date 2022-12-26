using _HelperFunctions;
using System.Collections;
using System.Linq;
using System.Text;

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
    }
}
