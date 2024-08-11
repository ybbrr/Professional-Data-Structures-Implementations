using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Graph'ımın dizini.
using DataStructures.Graph.AdjencencySet;

namespace Apps
{
    public class GraphExamples
    {
        public static void DirectionalWeightedGraphExample()
        {
            var graph = new WeightedDiGraph<char, int>(new char[] { 'A', 'B', 'C', 'D', 'E' });

            graph.AddEdge('A', 'C', 12);
            graph.AddEdge('A', 'D', 60);
            graph.AddEdge('B', 'A', 10);
            graph.AddEdge('C', 'D', 32);
            graph.AddEdge('C', 'B', 20);
            graph.AddEdge('E', 'A', 7);

            Console.Write("Vertices in the graph: ");
            foreach (var vertex in graph)
            {
                Console.Write(vertex + " ");
            }

            Console.WriteLine("\nNumber of vertices in the graph: " + graph.Count);

            Console.WriteLine("\nIs there an edge between A and C ? --> " + graph.HasEdge('A', 'C'));
            Console.WriteLine("Is there an edge between C and A ? --> " + graph.HasEdge('C', 'A'));
            Console.WriteLine("Is there an edge between A and D ? --> " + graph.HasEdge('A', 'D'));
            Console.WriteLine("Is there an edge between D and A ? --> " + graph.HasEdge('D', 'A'));
            Console.WriteLine("Is there an edge between B and A ? --> " + graph.HasEdge('B', 'A'));
            Console.WriteLine("Is there an edge between A and B ? --> " + graph.HasEdge('A', 'B'));
            Console.WriteLine("Is there an edge between C and D ? --> " + graph.HasEdge('C', 'D'));
            Console.WriteLine("Is there an edge between D and C ? --> " + graph.HasEdge('D', 'C'));
            Console.WriteLine("Is there an edge between C and B ? --> " + graph.HasEdge('C', 'B'));
            Console.WriteLine("Is there an edge between B and C ? --> " + graph.HasEdge('B', 'C'));
            Console.WriteLine("Is there an edge between E and A ? --> " + graph.HasEdge('E', 'A'));
            Console.WriteLine("Is there an edge between A and E ? --> " + graph.HasEdge('A', 'E'));

            Console.WriteLine();

            foreach (var key in graph)
            {
                Console.WriteLine("Node\n " + key);
                Console.WriteLine("    Connected with:");
                foreach (char vertex in graph.GetVertex(key))
                {
                    var node = graph.GetVertex(key);
                    Console.WriteLine("         " + vertex + " weight: " + node.GetEdge(graph.GetVertex(vertex)).Weight<int>());
                }
            }
        }

        public static void DirectionalUnweightedGraphExample()
        {
            var graph = new DiGraph<char>(new char[] { 'A', 'B', 'C', 'D', 'E' });

            graph.AddEdge('B', 'A');
            graph.AddEdge('A', 'D');
            graph.AddEdge('D', 'E');
            graph.AddEdge('C', 'D');
            graph.AddEdge('C', 'E');
            graph.AddEdge('C', 'A');
            graph.AddEdge('C', 'B');

            Console.Write("Vertices in the graph: ");
            foreach (var vertex in graph)
            {
                Console.Write(vertex + " ");
            }

            Console.WriteLine("\nNumber of vertices in the graph: " + graph.Count);

            Console.WriteLine("\nIs there an edge between B and A ? --> " + graph.HasEdge('B', 'A'));
            Console.WriteLine("Is there an edge between A and B ? --> " + graph.HasEdge('A', 'B'));
            Console.WriteLine("Is there an edge between A and D ? --> " + graph.HasEdge('A', 'D'));
            Console.WriteLine("Is there an edge between D and A ? --> " + graph.HasEdge('D', 'A'));
            Console.WriteLine("Is there an edge between D and E ? --> " + graph.HasEdge('D', 'E'));
            Console.WriteLine("Is there an edge between E and D ? --> " + graph.HasEdge('E', 'D'));
            Console.WriteLine("Is there an edge between C and D ? --> " + graph.HasEdge('C', 'D'));
            Console.WriteLine("Is there an edge between D and C ? --> " + graph.HasEdge('D', 'C'));
            Console.WriteLine("Is there an edge between C and E ? --> " + graph.HasEdge('C', 'E'));
            Console.WriteLine("Is there an edge between E and C ? --> " + graph.HasEdge('E', 'C'));
            Console.WriteLine("Is there an edge between C and A ? --> " + graph.HasEdge('C', 'A'));
            Console.WriteLine("Is there an edge between A and C ? --> " + graph.HasEdge('A', 'C'));
            Console.WriteLine("Is there an edge between C and B ? --> " + graph.HasEdge('C', 'B'));
            Console.WriteLine("Is there an edge between B and C ? --> " + graph.HasEdge('B', 'C'));

            Console.WriteLine();

            foreach (var key in graph)
            {
                Console.WriteLine("Node\n " + key);
                Console.WriteLine("    Connected with:");
                foreach (var vertex in graph.GetVertex(key).Edges)
                {
                    Console.WriteLine("         " + vertex);
                }
            }
        }
        public static void UndirectedWeightedGraphExample()
        {
            var graph = new WeightedGraph<char, double>(new char[] { 'A', 'B', 'C', 'D' });

            graph.AddEdge('A', 'B', 1.2);
            graph.AddEdge('A', 'D', 2.3);
            graph.AddEdge('D', 'C', 5.5);

            Console.Write("Vertices in the graph: ");
            foreach (var vertex in graph)
            {
                Console.Write(vertex + " ");
            }

            Console.WriteLine("\nNumber of vertices in the graph: " + graph.Count);

            Console.WriteLine("\nIs there an edge between A and B ? --> " + graph.HasEdge('A', 'B'));
            Console.WriteLine("Is there an edge between B and A ? --> " + graph.HasEdge('B', 'A'));
            Console.WriteLine("Is there an edge between A and D ? --> " + graph.HasEdge('A', 'D'));
            Console.WriteLine("Is there an edge between D and A ? --> " + graph.HasEdge('D', 'A'));
            Console.WriteLine("Is there an edge between D and C ? --> " + graph.HasEdge('D', 'C'));
            Console.WriteLine("Is there an edge between C and D ? --> " + graph.HasEdge('C', 'D'));

            Console.WriteLine();

            foreach (var key in graph)
            {
                Console.WriteLine("Node\n " + key);
                Console.WriteLine("    Connected with:");
                foreach (char vertex in graph.GetVertex(key))
                {
                    var node = graph.GetVertex(key);
                    Console.WriteLine("         " + vertex + " weight: " + node.GetEdge(graph.GetVertex(vertex)).Weight<double>());
                }
            }
        }

        public static void UndirectedUnweightedGraphExample()
        {
            var graph = new Graph<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' });

            graph.AddEdge('A', 'B');
            graph.AddEdge('A', 'D');
            graph.AddEdge('C', 'D');
            graph.AddEdge('C', 'E');
            graph.AddEdge('D', 'E');
            graph.AddEdge('E', 'F');
            graph.AddEdge('F', 'G');

            Console.Write("Vertices in the graph: ");
            foreach (var vertex in graph)
            {
                Console.Write(" " + vertex);
            }

            Console.WriteLine("\nNumber of vertices in the graph: " + graph.Count);

            Console.WriteLine("\nIs there an edge between A and B ? --> " + graph.HasEdge('A', 'B'));
            Console.WriteLine("Is there an edge between A and D ? --> " + graph.HasEdge('A', 'D'));
            Console.WriteLine("Is there an edge between C and D ? --> " + graph.HasEdge('C', 'D'));
            Console.WriteLine("Is there an edge between C and E ? --> " + graph.HasEdge('C', 'E'));
            Console.WriteLine("Is there an edge between D and E ? --> " + graph.HasEdge('D', 'E'));
            Console.WriteLine("Is there an edge between E and F ? --> " + graph.HasEdge('E', 'F'));
            Console.WriteLine("Is there an edge between F and G ? --> " + graph.HasEdge('F', 'G'));

            Console.WriteLine();

            foreach (var key in graph)
            {
                Console.WriteLine("Node\n " + key);
                Console.WriteLine("    Connected with:");
                foreach (var vertex in graph.GetVertex(key).Edges)
                {
                    Console.WriteLine("         " + vertex);
                }
            }
        }
    }
}
