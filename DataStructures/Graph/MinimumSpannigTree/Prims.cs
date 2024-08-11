using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Heap'min dizini
using DataStructures.Heap;
//Benin Shared Özelliklerimin dizini. (Buradaki özelliği Heap için kullandım.)
using DataStructures.Shared;

namespace DataStructures.Graph.MinimumSpannigTree
{
    public class Prims<T, TW> where T : IComparable where TW : IComparable
    {
        public List<MSTEdge<T, TW>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T,TW>>();

            dfs(graph, graph.ReferenceVertex, new BinaryHeap<MSTEdge<T, TW>>(SortDirection.Ascending), new HashSet<T>(), edges);

            return edges;
        }

        private void dfs(IGraph<T> graph, IGraphVertex<T> currentVertex, BinaryHeap<MSTEdge<T, TW>> spNeignours, 
            HashSet<T> spVertices, List<MSTEdge<T, TW>> spEdges)
        {
            while (true)
            {
                foreach (var edge in currentVertex.Edges)
                {
                    //min heap içinde kenarlar düzenlenecek
                    spNeignours.Add(new MSTEdge<T, TW>(currentVertex.Key, edge.TargetVertexKey, edge.Weight<TW>()));
                }

                //minumum değere sahip kenar
                var minEdge = spNeignours.DeleteMinMax();

                //var olan kenarları dikkate alma
                while (spVertices.Contains(minEdge.Source) && spVertices.Contains(minEdge.Destination))
                {
                    minEdge = spNeignours.DeleteMinMax();
                    if (spNeignours.Count == 0) return;
                }

                //vertex takibi
                if (!spVertices.Contains(minEdge.Source))
                {
                    spVertices.Add(minEdge.Source);
                }

                spVertices.Add(minEdge.Destination);
                spEdges.Add(minEdge);

                currentVertex = graph.GetVertex(minEdge.Destination);
            }
        }
    }
}
