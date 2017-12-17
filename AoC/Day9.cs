using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    class Day9
    {
        public static int challenge1(string input)
        {
            //filter out cancelled characters
            StringBuilder sb = new StringBuilder();
            for(var i = 0; i < input.Length; i++)
            {
                if(input[i] == '!')
                {
                    i += 1;
                }
                else
                {
                    sb.Append(input[i]);
                }
            }

            input = sb.ToString();
            sb.Clear();
            //filter out garbage
            for(var i = 0; i < input.Length; i++)
            {
                if(input[i] != '<')
                {
                    sb.Append(input[i]);
                }
                else
                {
                    while(input[i] != '>')
                    {
                        i++;
                    }
                }
            }
            input = sb.ToString();
            var braces = new StringBuilder();
            for(var i = 0; i < input.Length; i++)
            {
                if(input[i] == '{' || input[i] == '}')
                {
                    braces.Append(input[i]);
                }
            }
            return getScore(braces.ToString(), 1);
        }

        public static int getScore(string input, int score)
        {
            var sum = 0;
            var subGroups = getSubGroups(input);
            foreach(var group in subGroups)
            {
                sum += getScore(group, score + 1);
            }
            return score + sum;
        }

        public static List<string> getSubGroups(string input)
        {
            var subGroups = new List<string>();
            var braceCount = 0;
            int start = 1;
            for(var i = 1; i < input.Length - 1; i++)
            {
                if(input[i] == '{')
                {
                    braceCount++;
                }
                else
                {
                    braceCount--;
                }

                if(braceCount == 0)
                {
                    subGroups.Add(input.Substring(start, i - start + 1));
                    start = i + 1;
                }
            }
            return subGroups;
        }

        public static int challenge2(string input)
        {
            //filter out cancelled characters
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '!')
                {
                    i += 1;
                }
                else
                {
                    sb.Append(input[i]);
                }
            }

            input = sb.ToString();

            // count characters in the garbage
            var count = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '<')
                {
                    i++;
                    while (input[i] != '>')
                    {
                        count++;
                        i++;
                    }
                }
            }
            return count;
        }
    }
}
