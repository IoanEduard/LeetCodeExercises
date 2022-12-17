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
            var prev = 2;
            var sum = 1;

            for (var i = 2; i <= n; i++)
            {
                result = prev + sum;
                prev = result;
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
    }
}