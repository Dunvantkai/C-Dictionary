using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmet1
{
    internal class Node
    {
        public string Word { get; set; }
        public int Length { get; set; }

        public Node(string word, int length)
        {
            Word = word;
            Length = length;
        }

        public override string ToString()   
        {
            return $"Word: {Word}, Length: {Length}";
        }
    }
}

