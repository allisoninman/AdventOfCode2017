using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC
{
    class Day8
    {
        // Input: several instructions about manipulating register values

        // Each line contains an instruction (which register to increase or decrease
        // and by how much) if a certain condition is true (something about the condition
        // of that or another register). This function completes all of the instructions
        // and returns the maximum stored in any register at the end
        public static int challenge1(List<string> instructions)
        {
            var registers = new Dictionary<string, int>();
            foreach(var line in instructions)
            {
                var parts = line.Split(' ');
                var dest = parts[0];
                var check = parts[4];
                if (!registers.ContainsKey(dest))
                {
                    registers.Add(dest, 0);
                }
                if (!registers.ContainsKey(check))
                {
                    registers.Add(check, 0);
                }

                var op = parts[5];
                var checkVal = int.Parse(parts[6]);
                var change = parts[1] == "inc" ? int.Parse(parts[2]) : int.Parse(parts[2]) * -1;
                if (op == ">" && registers[check] > checkVal)
                {
                    registers[dest] += change;
                } else if(op == "<" && registers[check] < checkVal)
                {
                    registers[dest] += change;
                } else if(op == "==" && registers[check] == checkVal)
                {
                    registers[dest] += change;
                } else if(op == ">=" && registers[check] >= checkVal)
                {
                    registers[dest] += change;
                } else if(op == "<=" && registers[check] <= checkVal)
                {
                    registers[dest] += change;
                } else if(op == "!=" && registers[check] != checkVal)
                {
                    registers[dest] += change;
                }
            }

            var maxVal = registers.Keys.Max(x => registers[x]);
            return maxVal;
        }

        // This function follows all of the same rules as challenge 1, but instead
        // returns the largest value that was ever stored in any of the registers, not
        // just at the end of instruciton execution.
        public static int challenge2(List<string> instructions)
        {
            var registers = new Dictionary<string, int>();
            var maxVal = 0;
            foreach (var line in instructions)
            {
                var parts = line.Split(' ');
                var dest = parts[0];
                var check = parts[4];
                if (!registers.ContainsKey(dest))
                {
                    registers.Add(dest, 0);
                }
                if (!registers.ContainsKey(check))
                {
                    registers.Add(check, 0);
                }

                var op = parts[5];
                var checkVal = int.Parse(parts[6]);
                var change = parts[1] == "inc" ? int.Parse(parts[2]) : int.Parse(parts[2]) * -1;
                if (op == ">" && registers[check] > checkVal)
                {
                    registers[dest] += change;
                }
                else if (op == "<" && registers[check] < checkVal)
                {
                    registers[dest] += change;
                }
                else if (op == "==" && registers[check] == checkVal)
                {
                    registers[dest] += change;
                }
                else if (op == ">=" && registers[check] >= checkVal)
                {
                    registers[dest] += change;
                }
                else if (op == "<=" && registers[check] <= checkVal)
                {
                    registers[dest] += change;
                }
                else if (op == "!=" && registers[check] != checkVal)
                {
                    registers[dest] += change;
                }

                if(registers[dest] > maxVal)
                {
                    maxVal = registers[dest];
                }
            }
            return maxVal;
        }
    }
}
