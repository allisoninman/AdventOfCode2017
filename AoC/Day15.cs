using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    class Day15
    {
        public static int challenge1(int genAInput, int genBInput)
        {
            long genA = genAInput;
            long genB = genBInput;
            int count = 0;
            long modVal = 2147483647;
            for (var i = 0; i < 40000000; i++)
            {
                genA = (genA * 16807) % modVal;
                genB = (genB * 48271) % modVal;
                if (((genA & 65535) ^ (genB & 65535)) == 0)
                {
                    count++;
                }                
            }
            return count;
        }

        public static int challenge2(int genAInput, int genBInput)
        {
            long genA = genAInput;
            long genB = genBInput;
            int count = 0;
            long modVal = 2147483647;
            for (var i = 0; i < 5000000; i++)
            {
                do
                {
                    genA = (genA * 16807) % modVal;
                } while (genA % 4 != 0);

                do
                {
                    genB = (genB * 48271) % modVal;
                } while (genB % 8 != 0) ;

                if (((genA & 65535) ^ (genB & 65535)) == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
