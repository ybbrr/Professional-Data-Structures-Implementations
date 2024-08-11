using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures.Graph.AdjencencySet;
//Benim Algoritmalar'ımın dizini.
using DataStructures.Graph.MinimumSpannigTree;

namespace Apps
{
    public class MinSpanningTreeExamples
    {
        public static void KRUSKAL()
        {
            Console.WriteLine("\nKRUSKAL\n");

            var graph = new WeightedGraph<int, int>();

            for (int i = 0; i <= 11; i++) graph.AddVertex(i);

            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 7, 8);
            graph.AddEdge(1, 7, 11);
            graph.AddEdge(1, 2, 8);
            graph.AddEdge(7, 8, 7);
            graph.AddEdge(7, 6, 1);
            graph.AddEdge(6, 8, 6);
            graph.AddEdge(2, 8, 2);
            graph.AddEdge(2, 3, 7);
            graph.AddEdge(2, 5, 4);
            graph.AddEdge(6, 5, 2);
            graph.AddEdge(3, 5, 14);
            graph.AddEdge(3, 4, 9);
            graph.AddEdge(5, 4, 10);

            var algorithm = new Kruskals<int, int>();

            var minimumSpTree = algorithm.FindMinimumSpanningTree(graph);

            foreach (var edge in minimumSpTree)
            {
                Console.WriteLine(edge);
            }
        }

        public static void PRIMS()
        {
            Console.WriteLine("\nPRIMS\n");

            var graph = new WeightedGraph<int, int>();

            for (int i = 0; i <= 11; i++) graph.AddVertex(i);

            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 7, 8);
            graph.AddEdge(1, 7, 11);
            graph.AddEdge(1, 2, 8);
            graph.AddEdge(7, 8, 7);
            graph.AddEdge(7, 6, 1);
            graph.AddEdge(6, 8, 6);
            graph.AddEdge(2, 8, 2);
            graph.AddEdge(2, 3, 7);
            graph.AddEdge(2, 5, 4);
            graph.AddEdge(6, 5, 2);
            graph.AddEdge(3, 5, 14);
            graph.AddEdge(3, 4, 9);
            graph.AddEdge(5, 4, 10);

            var algorithm = new Prims<int, int>();

            var minimumSpTree = algorithm.FindMinimumSpanningTree(graph);

            foreach (var edge in minimumSpTree)
            {
                Console.WriteLine(edge);
            }
        }
    }
}
