using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC
{
    class Day4
    {
        // Input: several strings that represent "passphrases" where each contains several
        // space separated "words" (combinations of characters, not necessarily english words)

        // In this scenario, a passphrase is valid if no "word" is repeated. This function
        // counts the valid passphrases using this rule.
        public static int challenge1(List<string> passphrases)
        {
            var count = 0;
            foreach(var phrase in passphrases)
            {
                var split = phrase.Split(' ').ToList<string>();
                count += split.Distinct().ToList<string>().Count == split.Count ? 1 : 0;
            }
            return count;
        }

        // In this scenario, a passphrase is valid if no two words are anagrams of each other.
        // This function counts the valid passphrases using this rule.
        public static int challenge2(List<string> passphrases)
        {
            var count = 0;

            foreach(var phrase in passphrases)
            {
                var split = phrase.Split(' ').ToList<string>();
                for(var i = 0; i < split.Count; i++)
                {
                    var sorted = split[i].ToCharArray().ToList<char>();
                    sorted.Sort();
                    split[i] = new string(sorted.ToArray<char>());
                }
                count += split.Distinct().ToList<string>().Count == split.Count ? 1 : 0;
            }

            return count;
        }
    }
}
