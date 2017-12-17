using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC
{
    class Day16
    {
        public static string challenge1(string input, string start = "abcdefghijklmnop")
        {
            var moves = input.Split(',');
            var programs = new List<char>(start.ToCharArray());
            foreach(var move in moves)
            {
                if(move[0] == 's')
                {
                    var size = int.Parse(move.Substring(1));
                    var newStart = Utility.getListOfSizeAtIndex(programs, size, 16 - size);
                    var newEmd = Utility.getListOfSizeAtIndex(programs, 16 - size, 0);

                    var i = 0;
                    for(; i < newStart.Count; i++)
                    {
                        programs[i] = newStart[i];
                    }

                    foreach(var prog in newEmd)
                    {
                        programs[i] = prog;
                        i++;
                    }
                } else if(move[0] == 'x')
                {
                    var spl = move.Split('/');
                    var pos1 = int.Parse(spl[0].Substring(1));
                    var pos2 = int.Parse(spl[1]);

                    var temp = programs[pos1];
                    programs[pos1] = programs[pos2];
                    programs[pos2] = temp;
                }
                else
                {
                    var a = move[1];
                    var b = move[3];

                    var aIndex = -1;
                    var bIndex = -1;

                    for(var i = 0; i < 16; i++)
                    {
                        if(programs[i] == a)
                        {
                            aIndex = i;
                        } else if(programs[i] == b)
                        {
                            bIndex = i;
                        }
                    }

                    var temp = programs[aIndex];
                    programs[aIndex] = programs[bIndex];
                    programs[bIndex] = temp;
                }
            }

            StringBuilder sb = new StringBuilder();
            for(var i = 0; i < 16; i++)
            {
                sb.Append(programs[i]);
            }
            return sb.ToString();
        }

        public static string challenge2(string input)
        {
            var moves = input.Split(',');
            var start = "abcdefghijklmnop";
            var memoization = new Dictionary<string, string>();
            for(var i = 0; i < 1000000000; i++)
            {
                if (memoization.ContainsKey(start))
                {
                    start = memoization[start];
                }
                else
                {
                    var next = challenge1(input, start);
                    memoization.Add(start, next);
                    start = next;
                }
            }

            return start;
        }
    }
}
