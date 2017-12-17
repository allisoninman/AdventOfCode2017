using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    class Day17
    {
        public static int challenge1(int input)
        {
            var pos = 0;
            var nums = new List<int>();
            nums.Add(0);
            for(var i = 1; i <= 2017; i++)
            {
                pos = ((pos + input) % nums.Count) + 1;
                nums.Insert(pos, i);
            }

            var index = nums.IndexOf(2017) + 1;
            return nums[index];
        }

        public static int challenge2(int input)
        {
            var pos = 0;
            var num = -1;
            for (var i = 1; i <= 50000000; i++)
            {
                pos = ((pos + input) % i) + 1;
                if(pos == 1)
                {
                    num = i;
                }
            }

            return num;
        }
    }
}
