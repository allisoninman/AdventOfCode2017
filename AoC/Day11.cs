using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC
{
    class Day11
    {
        public static int challenge1(string input)
        {
            var instructions = input.Split(',');
            var x = 0;
            var y = 0;
            var dists = new List<int>();
            foreach(var dir in instructions)
            {
                if(dir == "n")
                {
                    y++;
                } else if(dir == "ne")
                {
                    x++;
                    y++;
                } else if(dir == "se")
                {
                    x++;
                } else if(dir == "s")
                {
                    y--;
                } else if(dir == "sw")
                {
                    x--;
                    y--;
                } else if(dir == "nw")
                {
                    x--;
                }
                dists.Add(Math.Max(Math.Abs(x), Math.Abs(y)));
            }

            return Math.Max(Math.Abs(x), Math.Abs(y));
        }

        public static int challenge2(string input)
        {
            var instructions = input.Split(',');
            var x = 0;
            var y = 0;
            var dists = new List<int>();
            foreach (var dir in instructions)
            {
                if (dir == "n")
                {
                    y++;
                }
                else if (dir == "ne")
                {
                    x++;
                    y++;
                }
                else if (dir == "se")
                {
                    x++;
                }
                else if (dir == "s")
                {
                    y--;
                }
                else if (dir == "sw")
                {
                    x--;
                    y--;
                }
                else if (dir == "nw")
                {
                    x--;
                }
                dists.Add(Math.Max(Math.Abs(x), Math.Abs(y)));
            }
            return dists.Max();
        }
    }
}
