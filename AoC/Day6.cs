using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    class Day6
    {
        // Input: list of integers (represented as strings) that represent the starting
        // order of elements in an array

        // Finds the array element with the largest value, sets it to zero, and 
        // iterates over the array adding one to each value starting at the position 
        // that was just zeroed. It does this a number of times equivalent to the value 
        // that was overwritten by zero. Essentially it is redistributing resources. It counts
        // the number of times it does this before it reaches a state it has already been in 
        // and returns that count.
        public static int challenge1(List<string> banks)
        {
            var count = 0;
            var mem = Utility.stringListToIntList(banks);
            var seenBefore = new HashSet<string>();
            while (!seenBefore.Contains(hashFunction(mem)))
            {
                count++;
                seenBefore.Add(hashFunction(mem));
                var maxIndex = indexOfMax(mem);
                var amountOfMem = mem[maxIndex];
                mem[maxIndex] = 0;
                maxIndex++;
                for(var i = 0; i < amountOfMem; i++)
                {
                    mem[maxIndex % mem.Count]++;
                    maxIndex++;
                }
            }
            return count;
        }

        // Performs the same function as challenge 1, but returns the number of cycles it
        // takes to get from a state, back to that same state again.
        public static int challenge2(List<string> banks)
        {
            var count = 1;
            var mem = Utility.stringListToIntList(banks);
            var seenBefore = new Dictionary<string, int>();
            while (!seenBefore.ContainsKey(hashFunction(mem)))
            {
                count++;
                seenBefore.Add(hashFunction(mem), count);
                var maxIndex = indexOfMax(mem);
                var amountOfMem = mem[maxIndex];
                mem[maxIndex] = 0;
                maxIndex++;
                for (var i = 0; i < amountOfMem; i++)
                {
                    mem[maxIndex % mem.Count]++;
                    maxIndex++;
                }
            }
            return count - seenBefore[hashFunction(mem)] + 1;
        }

        // Finds the index of the maximum element in a list
        static int indexOfMax(List<int> list)
        {
            var maxIndex = 0;
            for(var i = 1; i < list.Count; i++)
            {
                if(list[i] > list[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        // Concatenates the elements of the array to a string
        static string hashFunction(List<int> ints)
        {
            var sum = "";
            for(var i = 0; i < ints.Count; i++)
            {
                sum += ints[i];
            }
            return sum;
        }
    }
}
