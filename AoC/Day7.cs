using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC
{
    class Day7
    {
        // Input: list of nodes and the corresponding children of each

        // Finds the data that would be stored in the root node of a tree constructed with the data
        public static string challenge1(List<string> input)
        {
            var allWords = new List<string>();
            var childWords = new HashSet<string>();
            foreach(var line in input)
            {
                var split = line.Split(' ');
                allWords.Add(split[0]);
                for(var i = 3; i < split.Length; i++)
                {
                    var temp = split[i];
                    childWords.Add(temp.Replace(",", ""));
                }
            }

            foreach(var key in allWords)
            {
                if (!childWords.Contains(key))
                {
                    return key;
                }
            }
            return "";
        }

        // Finds the node in the tree with an incorrect balance such that its balance does
        // not make it have the same weight as its siblings
        public static int challenge2(List<string> input)
        {
            var starter = "eugwuhl";
            for (var j = 0; j < input.Count; j++)
            {
                if (input[j].StartsWith(starter)){
                    starter = input[j];
                }
            }
            var tree = buildTree(input, starter);
            var problem = tree.children.Max(x => x.getWeight());
            var problemNode = tree.children.Find(x => x.getWeight() == problem);
            var norm = tree.children.Find(x => x.getWeight() < problem);
            var currentCorrect = norm.getWeight();
            while (problemNode != null)
            {
                var current = problemNode;
                if(current.children.Count != 0)
                {
                    var sum = 0;
                    current.children.ForEach(x => sum += x.getWeight());
                    if(sum % current.children[0].getWeight() == 0)
                    {
                        return currentCorrect - sum;
                    }
                    else
                    {
                        problem = current.children.Max(x => x.getWeight());
                        problemNode = current.children.Find(x => x.getWeight() == problem);
                        norm = current.children.Find(x => x.getWeight() < problem);
                        currentCorrect = norm.getWeight();
                    }

                }
                
            }
            return 0;
        }

        // Recursively builds a tree
        public static Node buildTree(List<string> input, string line)
        {
            var split = line.Split(' ');
            var name = split[0];
            var weight = Int32.Parse(split[1].Replace("(", "").Replace(")", ""));
            var children = new List<Node>();
            for(var i = 3; i < split.Length; i++)
            {
                var j = 0;
                for (j = 0; j < input.Count; j++)
                {
                    if(input[j].StartsWith(split[i].Replace(",", ""))){
                        break;
                    }
                }
                if(j < input.Count)
                {
                    var tempLine = input[j];
                    children.Add(buildTree(input, tempLine));
                }
            }
            var node = new Node(name, weight, children);

            return node;
        }

    }

    //Node class for tree construction
    class Node
    {
        public string name { get; set; }
        public int weight { get; set; }
        public List<Node> children { get; set; }
        
        public Node(string name, int weight, List<Node> children)
        {
            this.name = name;
            this.weight = weight;
            this.children = children;
        }

        // Recursively calculates the weight of a node by adding the 
        // weight of the node itself to the weight of all its children
        public int getWeight()
        {
            var sum = 0;
            for(var i = 0; i < this.children.Count; i++)
            {
                sum += this.children[i].getWeight();
            }

            return sum + this.weight;
        }
    }
}
