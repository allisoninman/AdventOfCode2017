using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC
{
    class Day10
    {
        public static int challenge1(List<string> input)
        {
            var lengths = Utility.stringListToIntList(input);
            var nums = new List<int>();
            for(var i = 0; i < 256; i++)
            {
                nums.Add(i);
            }
            var skip = 0;
            var pos = 0;

            for(var i = 0; i < lengths.Count; i++)
            {
                var len = lengths[i];
                var toReverse = Utility.getListOfSizeAtIndex(nums, len, pos);
                toReverse.Reverse();
                for(var j = 0; j < toReverse.Count; j++)
                {
                    nums[pos] = toReverse[j];
                    pos = (pos + 1) % nums.Count;
                }
                pos += skip;
                skip++;
            }

            return nums[0] * nums[1];
            
        }

        public static string challenge2(List<string> input)
        {
            var str = input.Aggregate((x, y) => x + "," + y);
            int[] toAppend = { 17, 31, 73, 47, 23 };
            var lengths = new List<int>();
            foreach(char c in str)
            {
                lengths.Add((int)c);
            }
            for(var i = 0; i < toAppend.Length; i++)
            {
                lengths.Add(toAppend[i]);
            }
            var nums = new List<int>();
            for (var i = 0; i < 256; i++)
            {
                nums.Add(i);
            }
            var skip = 0;
            var pos = 0;

            for (var count = 0; count < 64; count++)
            {
                for (var i = 0; i < lengths.Count; i++)
                {
                    var len = lengths[i];
                    var toReverse = Utility.getListOfSizeAtIndex(nums, len, pos);
                    toReverse.Reverse();
                    for (var j = 0; j < toReverse.Count; j++)
                    {
                        nums[pos] = toReverse[j];
                        pos = (pos + 1) % nums.Count;
                    }
                    pos = (pos + skip) % nums.Count;
                    skip++;
                }
            }

            var xOrs = new List<int>();
            for(var i = 0; i < 256; i += 16)
            {
                var temp = nums[i];
                for(var j = i + 1; j < i + 16; j++)
                {
                    temp ^= nums[j];
                }
                xOrs.Add(temp);
            }

            StringBuilder sb = new StringBuilder();
            for(var i = 0; i < xOrs.Count; i++)
            {
                var strRep = xOrs[i].ToString("X");
                if(strRep.Length == 1)
                {
                    sb.Append('0');
                }
                sb.Append(strRep);
            }
            return sb.ToString();
        }
    }
}
