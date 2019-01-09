using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public static void Main(string[] args)
    {
        int[] intArray = new int[args.Length];
        for(int i = 0; i<args.Length; i++)
        {
            intArray[i] = int.Parse(args[i]);
        }
        solution(intArray);
    }
    public static int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        //Peaks of array
        List<int> peakIndexes = new List<int>();
        for(int i = 1; i < A.Length - 1; i++)
        {
            if(A[i] > A[i-1] && A[i] > A[i+1])
            {
                peakIndexes.Add(i);
            }
        }

        //Now go through splitting A into equal length groups. Ignore if doesn't divide perfectly. Then check if each group has a peak
        for (int groupLength = 1; groupLength <= A.Length; groupLength++)
        {
            if (A.Length % groupLength != 0) continue; // skip if non-divisible
            int find = 0;
            int groups = A.Length / groupLength;
            bool ok = true;
            // Find whether every group has a peak
            foreach(int peakId in peakIndexes)
            {
                if (peakId / groupLength > find)
                {
                    ok = false;
                    break;
                }
                if (peakId / groupLength == find) find++;
            }
            if (find != groups) ok = false;
            if (ok) return groups;
        }
        return 0;
    }
}