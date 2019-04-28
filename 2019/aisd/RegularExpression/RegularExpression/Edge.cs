using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpression
{
    //класс ребра графа
    public class Edge
    {
        public readonly string Weight;
        public readonly Node From;
        public readonly Node To;
        public Edge(Node first, Node second, string weight)
        {
            From = first;
            To = second;
            Weight = weight;
        }
        public Edge()
        {

        }
        public bool IsIncident(Node node)
        {
            return From == node || To == node;
        }
        public Node OtherNode(Node node)
        {
            if (!IsIncident(node)) throw new ArgumentException();
            if (From == node) return To;
            return From;
        }
        public override string ToString()
        {
            return $"From {From} To {To}";
        }
    }
}
