namespace HelperFunctions
{
    public static class TestCases
    {
        public static int[] UniqueOccurrences_Test1 = new int[] { 1, 2, 2, 1, 1, 3 };
        public static int[] UniqueOccurrences_Test2 = new int[] { 1, 2 };
        public static int[] UniqueOccurrences_Test3 = new int[] { -3, 0, 1, -3, 1, 1, 1, -3, 10, 0 };

        public static int[] Intersection_TestCase1_Input1 = new int[] { 1, 2, 2, 1 };
        public static int[] Intersection_TestCase1_Input2 = new int[] { 2, 2 };
        public static int[] Intersection_TestCase2_Input1 = new int[] { 4, 9, 5 };
        public static int[] Intersection_TestCase2_Input2 = new int[] { 9, 4, 9, 8, 4 };

        public static int[] NextGreaterElement_TestCase1_Input1 = new int[] { 4, 1, 2 };
        public static int[] NextGreaterElement_TestCase1_Input2 = new int[] { 1, 3, 4, 2 };
        public static int[] NextGreaterElement_TestCase2_Input1 = new int[] { 2, 4 };
        public static int[] NextGreaterElement_TestCase2_Input2 = new int[] { 1, 2, 3, 4 };
        public static int[] NextGreaterElement_TestCase3_Input1 = new int[] { 1, 3, 5, 2, 4 };
        public static int[] NextGreaterElement_TestCase3_Input2 = new int[] { 6, 5, 4, 3, 2, 1, 7 };

        public static int[] FindMaxConsecutiveOnes_TestCase1 = new int[] { 1, 1, 0, 1, 1, 1 };
        public static int[] FindMaxConsecutiveOnes_TestCase2 = new int[] { 1, 0, 1, 1, 0, 1 };

        public static int[] Search_TestCase1_arr = new int[] { -1, 0, 3, 5, 9, 12 };
        public static int Search_TestCase1_param = 9;
        public static int[] Search_TestCase2_arr = new int[] { -1, 0, 3, 5, 9, 12 };
        public static int Search_TestCase2_param = 2;
        public static int[] Search_TestCase3_arr = new int[] { 5 };
        public static int Search_TestCase3_param = 5;

        public static string HalvesAreAlike_TestCase1 = "book";
        public static string HalvesAreAlike_TestCase2 = "textbook";

        public static string DefangIPaddr_TestCase1 = "1.1.1.1";
        public static string DefangIPaddr_TestCase2 = "255.100.50.0";

        public static string ToGoatLatin_TestCase1 = "I speak Goat Latin";
        public static string ToGoatLatin_TestCase2 = "The quick brown fox jumped over the lazy dog";

        public static int GenerateTheString_TestCase1 = 4;
        public static int GenerateTheString_TestCase2 = 2;

        public static string FindOcurrences_TestCase1 = "alice is aa good girl she is a good student";
        public static string FindOcurrences_TestCase1_param1 = "a";
        public static string FindOcurrences_TestCase1_param2 = "good";
        public static string FindOcurrences_TestCase2 = "we will we will rock you";
        public static string FindOcurrences_TestCase2_param1 = "we";
        public static string FindOcurrences_TestCase2_param2 = "will";

        public static string RemoveOuterParentheses_TestCase1 = "(()())(())";
        public static string RemoveOuterParentheses_TestCase2 = "(()())(())(()(()))";

        public static int[] ArrayPairSum_TestCase1 = new int[] { 1, 4, 3, 2 };
        public static int[] ArrayPairSum_TestCase2 = new int[] { 6, 2, 6, 5, 1, 2 };

        public static int[] FindPoisonedDuration_TestCase1 = new int[] { 1, 4 };
        public static int FindPoisonedDuration_TestCase1_param1 = 2;
        public static int[] FindPoisonedDuration_TestCase2 = new int[] { 1, 2 };
        public static int FindPoisonedDuration_TestCase2_param1 = 2;

        public static int[] SortArrayByParityII_TestCase1 = new int[] { 4, 2, 5, 7 };
        public static int[] SortArrayByParityII_TestCase2 = new int[] { 2, 3 };

        public static int DisplayDigits = 12345;

        public static string[] CommonChars_TestCase1 = new string[] { "bella", "label", "roller" };

        public static int[] SortedSquares_TestCase1 = new int[] { -4, -1, 0, 3, 10 };
        public static int[] SortedSquares_TestCase2 = new int[] { -7, -3, 2, 3, 11 };
        public static int[] SortedSquares_TestCase3 = new int[] { 4, 1, 2, 1 };
        public static int[] SortedSquares_TestCase4 = new int[] { 3, 1, 4, 2, 6, 5, 2, 6, 8, 1, 3, 5 };

        public static char[] ReverseString_TestCase1 = new char[] { 'h', 'e', 'l', 'l', 'o' };

        public static string FirstUniqChar_TestCase1 = "leetcode";
        public static string FirstUniqChar_TestCase2 = "loveleetcode";
        public static string FirstUniqChar_TestCase3 = "aabb";

        public static string CanConstruct_TestCase1_param1 = "aa";
        public static string CanConstruct_TestCase1_param2 = "aab";

        public static string[] FindWords_TestCase1 = new string[] { "Hello", "Alaska", "Dad", "Peace" };
        public static string[] FindWords_TestCase2 = new string[] { "adsdf", "sfd" };

        public static string JudgeCircle_TestCase1 = "UD";
        public static string JudgeCircle_TestCase2 = "LL";

        public static string NumJewelsInStones_TestCase1_param1 = "aA";
        public static string NumJewelsInStones_TestCase1_param2 = "aAAbbbb";

        public static string NumJewelsInStones_TestCase2_param1 = "z";
        public static string NumJewelsInStones_TestCase2_param2 = "ZZ";

        public static string BalancedStringSplit_TestCase1 = "RLRRLLRLRL";
        public static string BalancedStringSplit_TestCase2 = "RLRRRLLRLL";
        public static string BalancedStringSplit_TestCase3 = "LLLLRRRR";

        public static string IsValid_TestCase2 = "()";
        public static string IsValid_TestCase1 = "()[]{}";
        public static string IsValid_TestCase3 = "(]";

        public static string[] ArrayStringsAreEqual_TestCase1_param1 = new string[] { "ab", "c" };
        public static string[] ArrayStringsAreEqual_TestCase1_param2 = new string[] { "a", "bc" };

        public static string[] ArrayStringsAreEqual_TestCase2_param1 = new string[] { "a", "cb" };
        public static string[] ArrayStringsAreEqual_TestCase2_param2 = new string[] { "ab", "c" };

        public static string[] ArrayStringsAreEqual_TestCase3_param1 = new string[] { "abc", "d", "defg" };
        public static string[] ArrayStringsAreEqual_TestCase3_param2 = new string[] { "abcddefg" };

        public static int[][] LargestLocal_TestCase1 = new int[][] {
            new int[] { 9,9,8,1 },
            new int[] { 5,6,2,6 },
            new int[] { 8,2,6,4 },
            new int[] { 6,2,2,2 },
        };

        public static int[][] DiagonalSum_TestCase1 = new int[][] {
            new int[] { 1,2,3 },
            new int[] { 4,5,6 },
            new int[] { 7,8,9 },
        };

        public static int[][] DiagonalSum_TestCase2 = new int[][] {
            new int[] { 1,1,1,1 },
            new int[] { 1,1,1,1 },
            new int[] { 1,1,1,1 },
            new int[] { 1,1,1,1 },
        };

        public static int[][] DiagonalSum_TestCase4 = new int[][] {
            new int[] { 7,3,1,9 },
            new int[] { 3,4,6,9 },
            new int[] { 6,9,6,6 },
            new int[] { 9,5,8,5 },
        };

        public static int[][] DiagonalSum_TestCase3 = new int[][] {
            new int[] { 5 },
        };

        public static int[][] CountNegatives_TestCase1 = new int[][] {
            new int[] { 4,3,2,-1 },
            new int[] { 3,2,1,-1 },
            new int[] { 1,1,-1,-2 },
            new int[] { -1,-1,-2,-3 },
        };

        public static int[][] CountNegatives_TestCase2 = new int[][] {
            new int[] { 5,1,0 },
            new int[] { -5,-5,-5 },
        };

        public static int[][] CheckValid_TestCase1 = new int[][] {
            new int[] { 1,2,3 },
            new int[] { 3,1,2 },
            new int[] { 2,3,1 },
        };

        public static int[][] CheckValid_TestCase1 = new int[][] {
            new int[] { 1,2,3 },
            new int[] { 3,1,2 },
            new int[] { 2,3,1 },
        };
    }
}

