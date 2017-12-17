using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC
{
    class Day2
    {
        //Input: each line contains several, space separated integers

        // Sums up the differences between the max and min numbers on each line
        public static int challenge1(List<string> input)
        {
            var intLists = getIntLists(input);
            var sum = 0;
            foreach(var line in intLists)
            {
                sum += line.Max() - line.Min();
            }
            return sum;
        }

        // On each line, there is exactly one pair of numbers x & y such that
        // x divides evenly into y. This function finds that pair on each line and
        // sums up y / x.
        public static int challenge2(List<string> input)
        {
            var sum = 0;
            var intLists = getIntLists(input);
            foreach(var intList in intLists)
            {
                for(var i = 0; i < intList.Count - 1; i++)
                {
                    for(var j = i + 1; j < intList.Count; j++)
                    {
                        if (intList[i] % intList[j] == 0)
                        {
                            sum += intList[i] / intList[j];

                        } else if(intList[j] % intList[i] == 0)
                        {
                            sum += intList[j] / intList[i];
                        }
                    }
                }
            }
            return sum;
        }

        static List<List<int>> getIntLists(List<string> input)
        {
            List<List<int>> output = new List<List<int>>();
            foreach (var line in input)
            {
                var tokens = line.Split(' ');
                var nums = new List<int>();
                foreach (var token in tokens)
                {
                    nums.Add(Int32.Parse(token));
                }
                output.Add(nums);

            }
            return output;
        }
    }
}
