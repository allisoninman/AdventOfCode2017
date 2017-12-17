using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC
{
    class Day12
    {
        public static int challenge1(List<string> input)
        {
            return getNumsInGroup(input, 0).Count;
        }

        public static int challenge2(List<string> input)
        {
            var inAnyGroup = new List<int>();
            var groupCount = 0;
            for(var i = 0; i < input.Count; i++)
            {
                if (!inAnyGroup.Contains(i))
                {
                    groupCount++;
                    inAnyGroup.AddRange(getNumsInGroup(input, i));
                }
            }
            return groupCount;
        }

        private static List<int> getNumsInGroup(List<string> input, int numInGroup)
        {
            var inGroup = new List<int>();
            var toExplore = new List<string>();
            var current = input[numInGroup];
            while (current != null)
            {
                var split = current.Split(' ');
                for (var i = 2; i < split.Length; i++)
                {
                    split[i] = split[i].Replace(",", "");
                    if (!inGroup.Contains(int.Parse(split[i])))
                    {
                        toExplore.Add(input[int.Parse(split[i])]);
                        inGroup.Add(int.Parse(split[i]));
                    }
                }

                current = toExplore.Count > 0 ? toExplore[0] : null;
                if (toExplore.Count > 0)
                {
                    toExplore.RemoveAt(0);
                }
            }
            return inGroup;
        }
    }
}
