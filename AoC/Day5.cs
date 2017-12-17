using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    class Day5
    {
        // Input: A list of integer numbers (represented as strings)

        // Similar to the assembly jump instruction, each number in the list represents how far
        // to "step" up or down the list. For example, if the number at the current position is 1,
        // you should move to the next index. After an instruction is taken, that instruction should be
        // incremented by one. This function calculates the number of jumps it takes to escape the list 
        // (jump to an index < zero or >= list size)
        public static int challenge1(List<string> instructions)
        {
            var count = 0;
            var currentIndex = 0;
            var ints = Utility.stringListToIntList(instructions);
            while(currentIndex >= 0 && currentIndex < instructions.Count)
            {
                var step = ints[currentIndex];
                ints[currentIndex]++;
                currentIndex += step;
                count++;
            }

            return count;
        }

        // Follows the same rules as challenge 1, with the added stipulation that if the instruction
        // has a value of 3 or more, it should be decreased by 1 instead of increased by 1
        public static int challenge2(List<string> instructions)
        {
            var count = 0;
            var currentIndex = 0;
            var ints = Utility.stringListToIntList(instructions);
            while (currentIndex >= 0 && currentIndex < instructions.Count)
            {
                var step = ints[currentIndex];
                if(step >= 3)
                {
                    ints[currentIndex]--;
                }
                else
                {
                    ints[currentIndex]++;
                }
                currentIndex += step;
                count++;
            }

            return count;
        }
    }
}
