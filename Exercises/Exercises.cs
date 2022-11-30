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
    }
}