using System.Text;

namespace Exercises
{
    public static class Exercises
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
    }
}