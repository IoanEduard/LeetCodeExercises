using System;
using System.Text;
using static System.Console;

namespace Exercises
{
    public static class Exercises_Recursion
    {
        public static int Pow_NotRecursive(int n, int p)
        {
            var power = p;
            while (p >= 2)
            {
                n *= power;
                p--;
            }

            return n;
        }

        public static int Pow(int n, int p, int increment)
        {
            if (increment == p) return n;
            n *= p;
            increment++;

            return Pow(n, p, increment);
        }

        public static int Pow_Version2(int n, int p)
        {
            if (p == 0) return 1;
            return n * Pow_Version2(n, p - 1);
        }

        public static int Multiply(int n1, int n2)
        {
            if (n2 == 0) return 0;
            return n1 + Multiply(n1, n2 - 1);
        }

        public static int Fibonacci_NotRecursive(int n)
        {
            var result = 0;
            var prev = 1;

            for (var i = 0; i <= n; i++)
            {
                var temp = result;
                result = prev;
                prev = temp + prev;
            }

            return result;
        }

        public static int Fibonacci(int n)
        {
            if (n == 1 || n == 2) return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static int Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }

        public static string ReverseStringNotRecursive(string s)
        {
            if (s == null) return string.Empty;

            var result = new char[s.Length];

            for (int i = s.Length - 1, j = 0; i >= 0 && j < s.Length; i--, j++)
            {
                result[j] = s[i];
            }

            return new string(result);
        }

        public static string ReverseString(string s)
        {
            if ((s.Length <= 1) || (s == null)) return s;

            return ReverseString(s.Substring(1)) + s[0];
        }

        public static bool IsPalindromeNotRecursive(string s)
        {
            for (int i = s.Length - 1, j = 0; j <= s.Length / 2; i--, j++)
                if (s[i] != s[j]) return false;

            return true;
        }

        public static bool IsPalindrome(string s)
        {
            if (s.Length <= 1) return true;

            return s[0] != s[s.Length - 1]
                ? false
                : IsPalindrome(s.Substring(1, s.Length - 2));
        }

        public static int PrintNumbers(int n)
        {
            if (n == 2) return 1;

            WriteLine(n);

            return PrintNumbers(n - 1);
        }

        public static int SumNumbers(int n)
        {
            if (n == 1) return 1;

            //Write($"{n} ");

            return n + SumNumbers(n - 1);
        }

        public static int DisplayDigits(int n)
        {
            if (n <= 1) return 1;

            Write($"{n % 10} ");

            return DisplayDigits(n / 10);
        }

        public static void DisplayDigits2(int n, int len)
        {
            while (len > 0)
            {
                var res = (n / len) % 10;
                Write($"{res} ");
                len /= 10;
            }
        }

        public static int DisplayDigits3(int n, int len)
        {
            var res = (n / len) % 10;

            if (len < 10) return res;

            Write($"{res} ");

            return DisplayDigits3(n, len /= 10);
        }

        public static int CountDigits(int n, int count)
        {
            if (n <= 0) return count;

            return CountDigits(n / 10, ++count);
        }

        public static int OddNumbers(int start, int end)
        {
            if (start % 2 == 0) start++;
            if (start + 2 > end) return start;

            Write($"{start} ");

            return OddNumbers(start += 2, end);
        }

        public static int EvenNumbers(int start, int end)
        {
            if (start % 2 != 0) start++;
            if (start + 2 > end) return start;

            Write($"{start} ");

            return EvenNumbers(start += 2, end);
        }

        public static bool PrimeNumberNotRecursive(int n)
        {
            for (int i = 2; i < n / 2; i++)
                if (n % i == 0) return false;

            return true;
        }

        public static bool PrimeNumber(int n, int counter)
        {
            if (n % counter == 0) return false;
            if (n / 2 == counter) return true;

            return PrimeNumber(n, ++counter);
        }

        public static bool IsPalindrome2(string s)
        {
            if (s.Length <= 1) return false;

            if (s[0] == s[s.Length - 1])
            {
                return true;
            }
            else
            {
                return IsPalindrome2(s.Substring(1, s.Length - 2));
            }
        }

        public static int Fibonacci2(int n)
        {
            if (n == 1 || n == 2) return 1;

            return Fibonacci2(n - 1) + Fibonacci2(n - 2);
        }

        public static int Fibonacci3NotRecursive(int n)
        {
            var result = 0;
            var prev = 1;

            for (var i = 0; i <= n; i++)
            {
                var temp = result;
                result = prev;
                prev = temp + prev;
            }

            return result;
        }

        public static int Fibonacci3(int n, int current, int count, int previous)
        {
            if (count == 0)
                current = 0;
            else if (count == 1)
            {
                previous = 0;
                current = 1;
            }

            if (count < n - 1)
            {
                int temp = previous + current;

                Write(previous + " ");
                return Fibonacci3(n, temp, ++count, current);
            }
            else
            {
                Write(previous + " ");
                return current;
            }
        }

        // More on this
        // https://stackoverflow.com/questions/774457/combination-generator-in-linq/774628#774628
        // https://stackoverflow.com/questions/4319049/generating-permutations-using-linq/4326669#4326669
        // https://stackoverflow.com/questions/33336540/how-to-use-linq-to-find-all-combinations-of-n-items-from-a-set-of-numbers
        public static IList<IList<int>> AllPermutations(int[] digits)
        {
            var list = new List<IList<int>>();
            return Permute(digits, 0, digits.Length - 1, list);
        }

        static IList<IList<int>> Permute(int[] digits, int start, int end, IList<IList<int>> list)
        {
            if (start == end)
            {
                list.Add(new List<int>(digits));
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(ref digits[start], ref digits[i]);
                    Permute(digits, start + 1, end, list);
                    Swap(ref digits[start], ref digits[i]);
                }
            }

            return list;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // https://www.youtube.com/watch?v=p5gn2hj51hs
        public static int GCDNotRecursive(int n1, int n2)
        {
            int temp;
            while (n2 != 0)
            {
                temp = n1 % n2;
                n1 = n2;
                n2 = temp;
            }

            return n1;
        }

        public static int GCD(int n1, int n2)
        {
            if (n2 == 0)
            {
                return n1;
            }
            else
            {
                return GCD(n2, n1 % n2);
            }
        }

        // https://www.youtube.com/watch?v=89mJLJjL6YQ
        public static int LCM(int n1, int n2)
        {
            return (n1 * n2) / GCD(n1, n2);
        }

        public static string ConvertToDecimalNotRecursive(int n)
        {
            int remainder;
            var result = string.Empty;

            while (n > 0)
            {
                remainder = n % 2;
                n /= 2;
                result = remainder.ToString() + result;
            }

            return result;
        }

        public static string ConvertToDecimal(int n, string result)
        {
            int remainder;

            if (n <= 0) return result;

            remainder = n % 2;

            return ConvertToDecimal(n /= 2, remainder.ToString() + result);
        }

        public static int PowerOfNumber(int n, int pow)
        {
            if (pow < 1) return 1;

            return n * PowerOfNumber(n, --pow);
        }

        public static string ReverseString2(string s)
        {
            if (s.Length - 1 <= 1 || s == null) return s;

            return ReverseString2(s.Substring(1)) + s[0];
        }

        public static int MultiplicationNotRecursive(int n)
        {
            var result = 1;

            while (n > 0)
            {
                result = result * (n % 10);
                n /= 10;
            }

            return result;
        }

        public static int Multiplication(int n)
        {
            if (n < 10) return n % 10;

            return n % 10 * Multiplication(n / 10);
        }

        public static int FactorialNonRecursive(int n)
        {
            var result = 1;

            while (n > 1)
            {
                result *= n;
                n--;
            }
            return result;
        }

        public static int Factorial2(int n)
        {
            if (n < 1) return 1;

            return n * Factorial2(--n);
        }

        public static int Fibonacci4NotRecursive(int n)
        {
            var result = 0;
            var sum = 1;

            for (int i = 2; i <= n; i++)
            {
                var temp = result;
                result = sum;
                sum = temp + sum;
            }

            return result;
        }

        public static int Fibonacci3(int n)
        {
            if (n == 1 || n == 2) return 1;

            return Fibonacci3(n - 1) + Fibonacci3(n - 2);
        }

        public static int RangeMultiplication(int n, int m)
        {
            if (n > m) return 1;

            return n * RangeMultiplication(++n, m);
        }

        public static int PowerOfNumber2(int n, int p)
        {
            if (p < 1) return 1;

            return n * PowerOfNumber2(n, --p);
        }

        public static string ReverseString3(string s)
        {
            if (s.Length < 1) return s;

            return ReverseString(s.Substring(1)) + s[0];
        }

        public static bool Palindrome(string s)
        {
            if (s.Length <= 1) return true;

            if (s[0] != s[s.Length - 1])
            {
                return false;
            }
            else
            {
                return Palindrome(s.Substring(1, s.Length - 2));
            }
        }

        public static int MinimumElement(int[] n, int min, int index)
        {
            if (index >= n.Length - 1) return min;

            if (min > n[index]) min = n[index];

            return MinimumElement(n, min, ++index);
        }
    }
}