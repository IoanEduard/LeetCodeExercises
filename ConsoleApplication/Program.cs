using _HelperFunctions;
using Data_Structures;
using Data_Structures._1.BasicTree;
using HelperFunctions;
using System.Collections.Generic;
using System.Reflection;
using z_Resources._1._Algorithhms_4th_Edition_by_Robert_Sedgewick__Kevin_Wayne;
using static Exercises.Exercises_LeetCode;
using static Exercises.Exercises_Recursion;
using static z_Resources._1._Algorithhms_4th_Edition_by_Robert_Sedgewick__Kevin_Wayne.BinarySearchAlgorithm;
using static Exercises.Exercises_SlidingWindow;
using DesignPatterns.Code.Observer_Pattern.Example_One;

// Some basics to get restarted.
#region Warmup
// Display<bool>.DisplaySingleResult(UniqueOccurrences(TestCases.UniqueOccurrences_Test2));
// Display<bool>.DisplaySingleResult(UniqueOccurrences_Linq(TestCases.UniqueOccurrences_Test2));
// Display<int>.DisplayCollection(Intersection_2(TestCases.Intersection_TestCase1_Input1, TestCases.Intersection_TestCase1_Input2));
// Display<int>.DisplayCollection(Intersection_2(TestCases.Intersection_TestCase2_Input1, TestCases.Intersection_TestCase2_Input2));
// Display<int>.DisplayCollection(NextGreaterElement(TestCases.NextGreaterElement_TestCase1_Input1, TestCases.NextGreaterElement_TestCase1_Input2));
// Display<int>.DisplayCollection(NextGreaterElement(TestCases.NextGreaterElement_TestCase2_Input1, TestCases.NextGreaterElement_TestCase2_Input2));
// Display<int>.DisplayCollection(NextGreaterElement(TestCases.NextGreaterElement_TestCase3_Input1, TestCases.NextGreaterElement_TestCase3_Input2));
// Display<int>.DisplaySingleResult(FindMaxConsecutiveOnes_1(TestCases.FindMaxConsecutiveOnes_TestCase1));
// Display<int>.DisplaySingleResult(FindMaxConsecutiveOnes_1(TestCases.FindMaxConsecutiveOnes_TestCase2));
// Display<int>.DisplaySingleResult(Search(TestCases.Search_TestCase1_arr, TestCases.Search_TestCase1_param));
// Display<int>.DisplaySingleResult(Search(TestCases.Search_TestCase3_arr, TestCases.Search_TestCase3_param));
// Display<bool>.DisplaySingleResult(HalvesAreAlike(TestCases.HalvesAreAlike_TestCase2, Utils.wovewlsUpperCase));
// Display<string>.DisplaySingleResult(DefangIPaddr(TestCases.DefangIPaddr_TestCase1));
//Display<string>.DisplaySingleResult(ToGoatLatin(TestCases.ToGoatLatin_TestCase1, Utils.wovewlsUpperCase));
// Display<string>.DisplaySingleResult(GenerateTheString(TestCases.GenerateTheString_TestCase1));
// Display<string>.DisplayCollection(FindOcurrences(TestCases.FindOcurrences_TestCase1,
//                                                 TestCases.FindOcurrences_TestCase1_param1,
//                                                 TestCases.FindOcurrences_TestCase1_param2));
// Display<string>.DisplayCollection(FindOcurrences(TestCases.FindOcurrences_TestCase2,
//                                          TestCases.FindOcurrences_TestCase2_param1,
//                                          TestCases.FindOcurrences_TestCase2_param2));
// Display<string>.DisplaySingleResult(RemoveOuterParentheses(TestCases.RemoveOuterParentheses_TestCase1));
// Display<int>.DisplaySingleResult(ArrayPairSum(TestCases.ArrayPairSum_TestCase1));
// Display<int>.DisplaySingleResult(FindPoisonedDuration(TestCases.FindPoisonedDuration_TestCase2, TestCases.FindPoisonedDuration_TestCase2_param1));S
// Display<int>.DisplaySingleResult(Pow_Version2(5, 5));
// Display<int>.DisplaySingleResult(Multiply(4, 4));
// Display<int>.DisplaySingleResult(Fibonacci(13));
// Examples.ExampleBinaryTreeDisplay();
// Display<int>.DisplayCollection(SortArrayByParityII(TestCases.SortArrayByParityII_TestCase1));
//Display<int>.DisplaySingleResult(Factorial(6));
//Display<int>.DisplaySingleResult(Fibonacci(13));
//Display<string>.DisplaySingleResult(ReverseStringNotRecursive("Jonny"));
//Display<string>.DisplaySingleResult(ReverseString("Jonny"));
//Display<bool>.DisplaySingleResult(IsPalindrome("iTopiNonAvevanoNipoti".ToLower()));
//var person = new OOP.Problem1.Person("Juan");
//Display<string>.DisplaySingleResult(person.ToString());
//Display<int>.DisplaySingleResult(PrintNumbers(10));
//Display<int>.DisplaySingleResult(SumNumbers(5));
//DisplayDigits2(12345, 10000);
//Display<int>.DisplaySingleResult(DisplayDigits3(TestCases.DisplayDigits, (int)Math.Pow(10, Math.Floor(Math.Log10(TestCases.DisplayDigits)))));
//Display<int>.DisplaySingleResult(CountDigits(12345, 0));
//Display<int>.DisplaySingleResult(OddNumbers(2, 20));
//Display<bool>.DisplaySingleResult(PrimeNumber(37, 2));
//Display<bool>.DisplaySingleResult(IsPalindrome2("radar"));
//Display<int>.DisplaySingleResult(Fibonacci_NotRecursive(13));
//Display<int>.DisplaySingleResult(Fibonacci3(13, 1, 1, 0));
//foreach (var list in AllPermutations(new int[] { 1, 2, 3 }))
//{
//    Display<string>.DisplaySingleResult($"[{string.Join(',', list)}]");
//}
//Display<int>.DisplaySingleResult(GCD(10, 15));
//Display<int>.DisplaySingleResult(LCM(18, 24));
//Display<string>.DisplaySingleResult(ConvertToDecimal(65, string.Empty));
//Display<int>.DisplaySingleResult(PowerOfNumber(3, 5));
//Display<string>.DisplaySingleResult(ReverseString2("w3resource"));
//Display<int>.DisplayCollection(Utils.AllIntegers());
//Display<int>.DisplaySingleResult(BinarySearch(11, new int[] { 10, 11, 20, 30, 50, 60, 80, 110, 130, 140, 170 }));
//Display<int>.DisplaySingleResult(new int[] { 10, 11, 20, 30, 50, 60, 80, 110, 130, 140, 170 }.BinarySearch(110));
//Display<int>.DisplaySingleResult(Multiplication(1234));
//Display<int>.DisplaySingleResult(Factorial2(7));
//Display<int>.DisplaySingleResult(Fibonacci3(7));
//Display<int>.DisplaySingleResult(RangeMultiplication(50, 50));
//Display<int>.DisplaySingleResult(PowerOfNumber2(5,2));
//Display<bool>.DisplaySingleResult(Palindrome("radar"));
//Display<int>.DisplaySingleResult(MinimumElement(new int[] { -2, -9, 2, -3, 1, 0 }, int.MaxValue, 0));
//Display<bool>.DisplaySingleResult(Exercises.Exercises_LeetCode.IsPalindrome("ab2a"));
//Display<string>.DisplayCollection(CommonChars(TestCases.CommonChars_TestCase1));
//Display<int>.DisplayCollection(SortedSquares2(TestCases.SortedSquares_TestCase2));
//Display<int>.DisplayCollection(SortArrayByParityII2(TestCases.SortedSquares_TestCase4));
//Display<int>.DisplaySingleResult(FirstUniqChar(TestCases.FirstUniqChar_TestCase3));
//ReverseString(TestCases.ReverseString_TestCase1);
//Display<bool>.DisplaySingleResult(CanConstruct(TestCases.CanConstruct_TestCase1_param1, TestCases.CanConstruct_TestCase1_param2));
//Display<string>.DisplayCollection(FizzBuzz(15));
//Display<string>.DisplayCollection(FindWords(TestCases.FindWords_TestCase1));
//Display<bool>.DisplaySingleResult(JudgeCircle(TestCases.JudgeCircle_TestCase1));
//Display<int>.DisplaySingleResult(NumJewelsInStones(TestCases.NumJewelsInStones_TestCase1_param1, TestCases.NumJewelsInStones_TestCase1_param2));
//Display<int>.DisplaySingleResult(NumJewelsInStones(TestCases.NumJewelsInStones_TestCase2_param1, TestCases.NumJewelsInStones_TestCase2_param2));
//Display<int>.DisplaySingleResult(BalancedStringSplit(TestCases.BalancedStringSplit_TestCase1));
//Display<bool>.DisplaySingleResult(IsValid(TestCases.IsValid_TestCase1));
//Display<bool>.DisplaySingleResult(IsValid(TestCases.IsValid_TestCase2));
//Display<bool>.DisplaySingleResult(IsValid(TestCases.IsValid_TestCase3));
//Display<bool>.DisplaySingleResult(ArrayStringsAreEqualStack(TestCases.ArrayStringsAreEqual_TestCase1_param1, TestCases.ArrayStringsAreEqual_TestCase1_param2));
//Display<bool>.DisplaySingleResult(ArrayStringsAreEqualStack(TestCases.ArrayStringsAreEqual_TestCase2_param1, TestCases.ArrayStringsAreEqual_TestCase2_param2));
//Display<bool>.DisplaySingleResult(ArrayStringsAreEqualStack(TestCases.ArrayStringsAreEqual_TestCase3_param1, TestCases.ArrayStringsAreEqual_TestCase3_param2));
//Display<int[]>.DisplayCollection(LargestLocal(TestCases.LargestLocal_TestCase1));
//Display<int>.DisplaySingleResult(DiagonalSum(TestCases.DiagonalSum_TestCase4));
//Display<int>.DisplaySingleResult(CountNegatives(TestCases.CountNegatives_TestCase2));
//Display<bool>.DisplaySingleResult(CheckValid2(TestCases.CheckValid_TestCase1));
//Display<int[][]>.DisplayMatrix(FileProcessor.ReadMatrixFromFile());
//Display<bool>.DisplaySingleResult(CheckValid(FileProcessor.ReadMatrixFromFile()));
//Display<int[][]>.DisplayMatrix(TestCases.FlipAndInvertImage_TestCase1);
//Display<int[][]>.DisplayMatrix(ReverseRowsInMatrix(TestCases.FlipAndInvertImage_TestCase1));
//Display<int[][]>.DisplayMatrix(FlipAndInvertImage(TestCases.FlipAndInvertImage_TestCase1));
//Display<int[][]>.DisplayMatrix(ReverseElementRowsInMatrix(TestCases.FlipAndInvertImage_TestCase2));
//Display<int>.DisplaySingleResult(MaximumWealth(TestCases.MaximumWealth_TestCase1));
//Display<int>.DisplayCollection(KWeakestRows(TestCases.KWeakestRows_TestCase1, 3));
//Display<int>.DisplayCollection(KWeakestRows(TestCases.KWeakestRows_TestCase2, 2));
//Display<int>.DisplayCollection(KWeakestRows(TestCases.KWeakestRows_TestCase3, 1));
//Display<int>.DisplaySingleResult(FindLucky(TestCases.FindLucky_TestCase1));
//Display<int>.DisplaySingleResult(FindLucky(TestCases.FindLucky_TestCase2));
//Display<int>.DisplaySingleResult(FindLucky(TestCases.FindLucky_TestCase3));
//Display<bool>.DisplaySingleResult(IsToeplitzMatrix(TestCases.IsToeplitzMatrix_TestCase1));
//Display<bool>.DisplaySingleResult(IsToeplitzMatrix(TestCases.IsToeplitzMatrix_TestCase2));
//Display<int[][]>.DisplayMatrix(Transpose(TestCases.Transpose_TestCase1));
//Display<int[][]>.DisplayMatrix(Transpose(TestCases.Transpose_TestCase2));
//Display<int[][]>.DisplayMatrix(Construct2DArray(TestCases.Construct2DArray_TestCase1, 2, 2));
//Display<int[][]>.DisplayMatrix(Construct2DArray(TestCases.Construct2DArray_TestCase2, 1, 3));
//Display<int[][]>.DisplayMatrix(Construct2DArray(TestCases.Construct2DArray_TestCase3, 1, 1));
//Display<int>.DisplayCollection(GetConcatenation(TestCases.GetConcatenation_TestCase1));
//Display<int>.DisplayCollection(GetConcatenation(TestCases.GetConcatenation_TestCase2));
//Display<int>.DisplayCollection(Shuffle(TestCases.Shuffle_TestCase1, 3));
//Display<int>.DisplayCollection(Shuffle(TestCases.Shuffle_TestCase1, 4));
//Display<int>.DisplayCollection(SmallerNumbersThanCurrent(TestCases.SmallerNumbersThanCurrent_TestCase1));
//Display<int>.DisplayCollection(CreateTargetArray(TestCases.CreateTargetArray_TestCase1_param1, TestCases.CreateTargetArray_TestCase1_param2));
//Display<int>.DisplayCollection(CreateTargetArray(TestCases.CreateTargetArray_TestCase2_param1, TestCases.CreateTargetArray_TestCase2_param2));
//Display<int>.DisplayCollection(DecompressRLElist(TestCases.DecompressRLElist_TestCase1));
//Display<string>.DisplaySingleResult(RestoreString(TestCases.RestoreString_TestCase1_param1, TestCases.RestoreString_TestCase1_param2));
//Display<int>.DisplaySingleResult(MaximumValue(TestCases.MaximumValue_TestCase1));
//Display<int>.DisplaySingleResult(MaximumValue(TestCases.MaximumValue_TestCase2));
//Display<int>.DisplaySingleResult(MaximumSumOfConsecutiveNumbers(TestCases.SumOfConsecutiveNumbers_TestCase1_param1, TestCases.SumOfConsecutiveNumbers_TestCase1_param2));
//Display<int>.DisplaySingleResult(MaximumSumOfConsecutiveNumbers(TestCases.SumOfConsecutiveNumbers_TestCase2_param1, TestCases.SumOfConsecutiveNumbers_TestCase2_param2));
//Display<int>.DisplaySingleResult(CountConsistentStrings(TestCases.CountConsistentStrings_TestCase1, "ab"));
//Display<int>.DisplaySingleResult(CountConsistentStrings(TestCases.CountConsistentStrings_TestCase2, "abc"));
//Display<int>.DisplaySingleResult(CountConsistentStrings(TestCases.CountConsistentStrings_TestCase3, "cad"));
//Display<string>.DisplayCollection(CellsInRange("K1:L2"));
//Display<string>.DisplayCollection(CellsInRange("A1:F1"));
//Display<int>.DisplaySingleResult(CountGoodSubstrings("xyzzaz"));
//Display<bool>.DisplaySingleResult(IsPalindrome(121));
//Display<string>.DisplaySingleResult(ConvertToTitle(27)); 
//Display<string>.DisplaySingleResult(ConvertToTitle(58));
//Display<string>.DisplaySingleResult(ConvertToTitle(82595524));
//Display<string>.DisplaySingleResult(ConvertToBase26(58));
//Display<string>.DisplaySingleResult(ConvertToBase26(2));
//Display<string>.DisplaySingleResult(ConvertToBase26(701));
//Display<string>.DisplaySingleResult(ConvertToBase26(82595524));
//Display<string>.DisplaySingleResult(ConvertToBase26(2147483647));
//Display<int>.DisplaySingleResult(MostFrequentEven(new int[] { 8154, 9139, 8194, 3346, 5450, 9190, 133, 8239, 4606, 8671, 8412, 6290 }));
//Display<int>.DisplaySingleResult(MostFrequentEven(new int[] { 0, 1, 2, 2, 4, 4, 1 }));
//Display<int>.DisplaySingleResult(TitleToNumber("FXSHRXW"));
//Display<int>.DisplaySingleResult(CountSegments(", , , ,        a, eaefa"));
//Display<int>.DisplaySingleResult(CountSegments("                "));
//Display<int>.DisplaySingleResult(CountSegments("Hello, my name is John"));
//Display<bool>.DisplaySingleResult(CanBeIncreasing(new int[] { 2, 3, 1, 2 }));
//Display<int>.DisplaySingleResult(SmallestEvenMultiple(5));
//Display<int>.DisplaySingleResult(DifferenceOfSum(new int[] { 1, 15, 6, 3 }));
//Display<int>.DisplaySingleResult(GetLucky("iiii", 1));
//Display<int>.DisplaySingleResult(GetLucky("leetcode", 2));
//Display<int>.DisplaySingleResult(GetLucky("fleyctuuajsr", 5));
//Display<int>.DisplaySingleResult(GetLucky("dbvmfhnttvr", 5));
//Display<int>.DisplaySingleResult(AddDigits(38));
//Display<int>.DisplaySingleResult(MinimumSum(2932));
//Display<int>.DisplaySingleResult(CountEven(30));
//Display<bool>.DisplaySingleResult(IsHappy(19));
//Display<bool>.DisplaySingleResult(IsHappy(2));
//Display<bool>.DisplaySingleResult(IsHappy(7));
//Display<bool>.DisplaySingleResult(IsHappy(3));
//Display<bool>.DisplaySingleResult(IsUgly(6));
//Display<bool>.DisplaySingleResult(IsUgly(1));
//Display<bool>.DisplaySingleResult(IsUgly(14));

//Display<int>.DisplaySingleResult(MinMaxGame(new int[] { 1, 3, 5, 2, 4, 8, 2, 2 }));
//Display<long>.DisplaySingleResult(WaysToBuyPensPencils(20, 10, 5));
//Display<long>.DisplaySingleResult(WaysToBuyPensPencils(20, 10, 5));
//Display<long>.DisplaySingleResult(WaysToBuyPensPencils(100, 1, 1));
//Display<string>.DisplaySingleResult(DigitSum("11111222223", 3));

//Display<int>.DisplaySingleResult(XorOperation(4, 3));
Display<string>.DisplaySingleResult(FreqAlphabets("10#11#12"));
Display<string>.DisplaySingleResult(FreqAlphabets("1326#"));

#endregion

// Design Patterns
#region Observer Pattern
/* Example 1: https://refactoring.guru/design-patterns/observer

var editor = new Editor();

var logger = new LoggingAlertsListener("Someone has opened the file: ");
var eventListener1 = new EventListeners(logger, "save");
editor._eventManager.Subscribe(eventListener1);

var emailAlerts = new EmailAlertsListener("admin@example.com", "Someone has changed the file: ");
var eventListener2 = new EventListeners(emailAlerts, "save");
editor._eventManager.Subscribe(eventListener2);
editor.OpenFile("file.txt");
editor.SaveFile();
emailAlerts.Update("file.txt");

*/
/*Example 2: https://en.m.wikipedia.org/wiki/Observer_pattern
 
 */

#endregion
#region Sliding Window

//Display<string>.DisplaySingleResult(Problem1_Try3(new int[] { 2, 5, 2, 6, 7, 3, 4, 7, 9, 7, 5, 1 }, 4));
//Display<int[][]>.DisplayMatrix(Problem2(new int[] { 2, 3, 5, 2, 6, 7, 3, 4, 7, 9, 7, 5 }, 4));
//Display<int>.DisplayCollection(Problem3(new int[] { 2, 3, 5, 2, 6, 7, 3, 4, 7, 9, 7, 5 }, 3));
//Display<int>.DisplaySingleResult(MinimumOfEachSubarraySlidingWindow(new int[] { 2, 3, 5, 2, 6, 7, 0, 1, 7, 9, 7, 5 }, 3));
//Display<int>.DisplayCollection(PairThatContainsMinimumElementInArray(new int[] { 2, 3, 5, 2, 6, 7, 2, 1, 7, 9, 7, 5 }, 2));

// Dumb problem for k=3, every number is a median except int[0] and int[len-1], Its an O(n-2) problem without sliding window,
// If the len is even, then we avg arr[i+1] and arr[i+2] 
//Display<int>.DisplayCollection(GetMedianEachWindow(new int[] { 2, 3, 5, 2, 6, 7, 2, 1, 7, 9, 7, 5, 1 }, 3)); // odd
//Display<int>.DisplayCollection(GetMedianEachWindow(new int[] { 2, 3, 5, 2, 6, 7, 2, 1, 7, 9, 7, 5 }, 3)); // even

// LeetCode Sliding Window
//Display<int>.DisplaySingleResult(MaxScore(new int[] { 96, 90, 41, 82, 39, 74, 64, 50, 30 }, 8)); 
//Display<int>.DisplaySingleResult(MinimumRecolors("WBBWWBBWBW", 7));
//Display<int>.DisplaySingleResult(MinimumRecolors("WBWBBBW", 2));
//Display<int>.DisplaySingleResult(MinimumRecolors("WBB", 1));
//Display<int>.DisplaySingleResult(MinimumRecolors("WBWBBBW", 2));

#endregion