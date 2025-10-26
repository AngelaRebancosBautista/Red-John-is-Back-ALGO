using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'redJohn' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int redJohn(int n)
    {
         const int MAX_N = 50;
        int[] dp = new int[MAX_N + 1];
        dp[0] = 1; // base case

        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i - 1];
            if (i >= 4)
                dp[i] += dp[i - 4];
        }

        int totalWays = dp[n];

        return CountPrimes(totalWays);
    }

    private static int CountPrimes(int num)
    {
        if (num < 2) return 0;

        bool[] isPrime = new bool[num + 1];
        for (int i = 2; i <= num; i++) isPrime[i] = true;

        for (int i = 2; i * i <= num; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= num; j += i)
                    isPrime[j] = false;
            }
        }

        int count = 0;
        for (int i = 2; i <= num; i++)
            if (isPrime[i]) count++;

        return count;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.redJohn(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
