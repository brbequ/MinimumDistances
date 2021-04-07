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

class Solution
{
    // The distance between two array values is the number of indices between them.Given a,
    // find the minimum distance between any pair of equal elements in the array.
    // If no such value exists, return -1.
    //
    // a = [3,2,1,2,3]
    // Distance between 3's is 4
    // Distance between 2's is 2
    // Min distance is 2

    // Complete the minimumDistances function below.
    static int minimumDistances(int[] a)
    {
        int min = -1;
        HashSet<int> seen = new HashSet<int>();

        // Walk the array. If we have found a min of 1,
        // there is no point in searching further
        for (int i = 0; i < a.Length && min != 1; i++)
        {
            // Don't look at numbers seen before
            if (!seen.Contains(a[i]))
            {
                int iSave = i;

                // Walk forward looking for a smaller min distance
                for (int j = i + 1; j < a.Length && min != 1; j++)
                {
                    if (a[i] == a[j])
                    {
                        int dist = j - i;
                        if (min == -1 || dist < min)
                            min = dist;
                        i = j;
                    }
                }

                // Put i back and add a[i] to the seen list
                i = iSave;
                seen.Add(a[i]);
            }
        }

        return min;
    }

    static void Main(string[] args)
    {
        int[] a = new int[] { 7, 1, 3, 4, 1, 7 };

        int result = minimumDistances(a);

        Console.WriteLine(result);
    }
}
