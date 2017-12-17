using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC
{
    class Utility
    {
        public static List<string> getFileLines(string fileName)
        {
            return File.ReadAllLines(fileName).ToList<string>();

        }

        public static List<int> stringListToIntList(List<string> strings)
        {
            var ints = new List<int>();
            foreach (var str in strings)
            {
                ints.Add(int.Parse(str));
            }
            return ints;
        }

        public static List<int> getListOfSizeAtIndex(List<int> nums, int size, int start)
        {
            var toReturn = new List<int>();
            for (var i = 0; i < size; i++)
            {
                toReturn.Add(nums[start % nums.Count]);
                start++;
            }
            return toReturn;
        }

        public static List<char> getListOfSizeAtIndex(List<char> nums, int size, int start)
        {
            var toReturn = new List<char>();
            for (var i = 0; i < size; i++)
            {
                toReturn.Add(nums[start % nums.Count]);
                start++;
            }
            return toReturn;
        }
    }
}
