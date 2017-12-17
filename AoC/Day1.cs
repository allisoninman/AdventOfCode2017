using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    class Day1
    {
        //Input: string of several, consecutive integer characters

        // Sums up the integer value of characters in a string that are identical to the next character
        public static int challenge1(string input)
        {
            var sum = 0;
            for(var i = 0; i < input.Length - 1; i++)
            {
                if(input[i] == input[i + 1])
                {
                    sum += Int32.Parse(input[i] + "");
                }

            }
            if(input[0] == input[input.Length - 1])
            {
                sum += Int32.Parse(input[0] + "");
            }

            return sum;
        }

        // Sums up the integer value of characters in a string that 
        // are identical to the character at (i + length / 2) % length
        public static int challenge2(string input)
        {
            var halfLen = input.Length / 2;
            var sum = 0;
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[(i + halfLen) % input.Length])
                {
                    sum += Int32.Parse(input[(i + halfLen) % input.Length] + "");
                }
            }

            return sum;
        }
    }
}
