using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    class Day14
    {
        public static Dictionary<char, int> getHexMappings()
        {
            var hexMapping = new Dictionary<char, int>();
            hexMapping.Add('0', 0);
            hexMapping.Add('1', 1);
            hexMapping.Add('2', 2);
            hexMapping.Add('3', 3);
            hexMapping.Add('4', 4);
            hexMapping.Add('5', 5);
            hexMapping.Add('6', 6);
            hexMapping.Add('7', 7);
            hexMapping.Add('8', 8);
            hexMapping.Add('9', 9);
            hexMapping.Add('A', 10);
            hexMapping.Add('B', 11);
            hexMapping.Add('C', 12);
            hexMapping.Add('D', 13);
            hexMapping.Add('E', 14);
            hexMapping.Add('F', 15);
            return hexMapping;
        }
        public static int challenge1(string input)
        {
            var hexMapping = getHexMappings();
            var nums = new List<int>();
            for (var i = 0; i < 256; i++)
            {
                nums.Add(i);
            }
            var numUsed = 0;

            for(var i = 0; i < 128; i++)
            {
                var hash = knotHash(input + "-" + i);
                foreach(char c in hash)
                {
                    var temp = hexMapping[c];
                    for(var j = 0; j < 4; j++)
                    {
                        numUsed += (temp >> j) & 1;
                    }
                }
            }
            return numUsed;
        }

        public static string knotHash(string input)
        {
            var nums = new List<int>();
            for (var l = 0; l < 256; l++)
            {
                nums.Add(l);
            }
            var lens = new List<int>();
            foreach (char c in input)
            {
                lens.Add((int)c);
            }
            int[] added = { 17, 31, 73, 47, 23 };
            lens.AddRange(added);
            var pos = 0;
            var skip = 0;
            for (var count = 0; count < 64; count++)
            {
                foreach (var len in lens)
                {
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
            for (var i = 0; i < 256; i += 16)
            {
                var temp = nums[i];
                for (var j = i + 1; j < i + 16; j++)
                {
                    temp ^= nums[j];
                }
                xOrs.Add(temp);
            }

            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < xOrs.Count; i++)
            {
                var strRep = xOrs[i].ToString("X");
                if (strRep.Length == 1)
                {
                    sb.Append('0');
                }
                sb.Append(strRep);
            }
            return sb.ToString();
        }

        public static int challenge2(string input)
        {
            var hexMapping = getHexMappings();
            KnotHashNode[,] grid = new KnotHashNode[128, 128];
            for(var i = 0; i < 128; i++)
            {
                var index = 0;
                var hash = knotHash(input + "-" + i);
                for(var j = 0; j < hash.Length; j++)
                {
                    var temp = hexMapping[hash[j]];
                    for(var count = 0; count < 4; count++)
                    {
                        grid[i, index] = new KnotHashNode(i, index, (temp >> (3 - count)) & 1);
                        var c = grid[i, index].value == 1 ? '#' : '.';
                        index++;                        
                    }
                }
            }

            var regionCount = 0;
            for(var row = 0; row < 128; row++)
            {
                for(var col = 0; col < 128; col++)
                {
                    if (grid[row, col].value == 1 && grid[row, col].region < 0 && !grid[row, col].explored)
                    {
                        regionCount++;
                        var q = new Queue<KnotHashNode>();
                        q.Enqueue(grid[row, col]);
                        while(q.Count != 0)
                        {
                            var current = q.Dequeue();
                            current.region = regionCount;
                            //check above
                            if (current.row >= 1)
                            {
                                var above = grid[current.row - 1, current.col];
                                if (!above.explored && above.region < 0 && above.value == 1)
                                {
                                    q.Enqueue(above);
                                }
                                above.explored = true;
                            }

                            //check below
                            if (current.row <= 126)
                            {
                                var below = grid[current.row + 1, current.col];
                                if (!below.explored && below.region < 0 && below.value == 1)
                                {
                                    q.Enqueue(below);
                                }
                                below.explored = true;
                            }

                            //check right
                            if (current.col <= 126)
                            {
                                var right = grid[current.row, current.col + 1];
                                if (!right.explored && right.region < 0 && right.value == 1)
                                {                                    
                                    q.Enqueue(right);
                                }
                                right.explored = true;
                            }

                            //check left
                            if (current.col >= 1)
                            {
                                var left = grid[current.row, current.col - 1];
                                if (!left.explored && left.region < 0 && left.value == 1)
                                {
                                    q.Enqueue(left);
                                }
                                left.explored = true;
                            }
                        }
                    }
                }
            }
            return regionCount;
        }
    }

    public class KnotHashNode
    {
        public int row { get; set; }
        public int col { get; set; }
        public int value { get; set; }
        public int region { get; set; }
        public bool explored { get; set; }
        public KnotHashNode(int row, int col, int value)
        {
            this.row = row;
            this.col = col;
            this.value = value;
            this.region = -1;
            this.explored = false;
        }
    }
}
