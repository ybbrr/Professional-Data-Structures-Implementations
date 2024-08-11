using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Graph'ımın dizini.
using DataStructures.Graph.AdjencencySet;
//Benim Algoritmalar'ımın dizini.
using DataStructures.Graph.Search;

namespace Apps
{
    public class DepthFirstSearchExamples
    {
        public static void DepthFirstSearchExample()
        {
            var graph = new Graph<int>();

            for (int i = 0; i <= 11; i++) graph.AddVertex(i);

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 0);
            graph.AddEdge(0, 2);

            graph.AddEdge(2, 5);
            graph.AddEdge(2, 10);
            graph.AddEdge(2, 9);
            graph.AddEdge(10, 11);
            graph.AddEdge(9, 11);

            graph.AddEdge(5, 7);
            graph.AddEdge(7, 8);
            graph.AddEdge(5, 8);

            var algorithm = new DepthFirst<int>();

            int value = 22;

            Console.WriteLine("\nIs " + value + " in the graph? --> {0}", algorithm.Find(graph, value));
            Console.WriteLine();

            value = 9;

            Console.WriteLine("\nIs " + value + " in the graph? --> " + algorithm.Find(graph, value));
        }
    }
}
