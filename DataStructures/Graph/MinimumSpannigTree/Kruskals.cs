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
    public class Kruskals<T, TW> where T : IComparable  where TW : IComparable
    {
        
        public List<MSTEdge<T, TW>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            // 1. kenar listesi oluştur (dfs kullan.)
            var edges = new List<MSTEdge<T, TW>>();
            dfs(graph.ReferenceVertex, new HashSet<T>(), new Dictionary<T, HashSet<T>>(), edges);
            // 2. kenarları sırala
            var heap = new BinaryHeap<MSTEdge<T, TW>>(SortDirection.Ascending);
            foreach (var edge in edges)
            {
                heap.Add(edge);
            }
            var sortedEdgeArr = new MSTEdge<T, TW>[edges.Count];
            for (int i = 0; i < edges.Count; i++)
            {
                sortedEdgeArr[i] = heap.DeleteMinMax();
            }
            // 3. set oluştur (küme oluştur)
            var disjointset = new Set.DisjointSet<T>();
            foreach (var vertex in graph.VerticesAsEnumerable)
            {
                disjointset.MakeSet(vertex.Key);
            }
            var resultEdgeList = new List<MSTEdge<T, TW>>();
            for (int i = 0; i < edges.Count; i++)
            {
                var currentEdge = sortedEdgeArr[i];
                var setA = disjointset.FindSet(currentEdge.Source);
                var setB = disjointset.FindSet(currentEdge.Destination);

                if (setA.Equals(setB)) continue;

                resultEdgeList.Add(currentEdge);
                disjointset.Union(setA, setB);
            }

            return resultEdgeList;
        }

        private void dfs(IGraphVertex<T> currentVertex, HashSet<T> visitedVertices, 
            Dictionary<T, HashSet<T>> visitedEdges, List<MSTEdge<T, TW>> edges)
        {
            if (!visitedVertices.Contains(currentVertex.Key))
            {
                visitedVertices.Add(currentVertex.Key);
                foreach (var edge in currentVertex.Edges)
                {
                    if (!visitedEdges.ContainsKey(currentVertex.Key) || !visitedEdges[currentVertex.Key].Contains(edge.TargetVertexKey))
                    {
                        //kenar ekeleme
                        edges.Add(new MSTEdge<T, TW>(currentVertex.Key, edge.TargetVertexKey, edge.Weight<TW>()));

                        //kenar güncelleme (visitedEdges) - source
                        if (!visitedEdges.ContainsKey(currentVertex.Key))
                        {
                            visitedEdges.Add(currentVertex.Key, new HashSet<T>());
                        }

                        visitedEdges[currentVertex.Key].Add(edge.TargetVertexKey);

                        //kenar güncelleme (visitedEdges) - destination

                        if (!visitedEdges.ContainsKey(edge.TargetVertexKey))
                        {
                            visitedEdges.Add(edge.TargetVertexKey, new HashSet<T>());
                        }

                        visitedEdges[edge.TargetVertexKey].Add(currentVertex.Key);

                        dfs(edge.TargetVertex, visitedVertices, visitedEdges, edges);
                    }
                }
            }
        }
    }
}
