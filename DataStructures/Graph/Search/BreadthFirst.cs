using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Queue'mun dizini
using DataStructures.Queue;

namespace DataStructures.Graph.Search
{
    public class BreadthFirst<T>
    {
        public bool Find(IGraph<T> graph, T vertexKey)
        {
            return bfs(graph.ReferenceVertex, new HashSet<T>(), vertexKey);
        }

        private bool bfs(IGraphVertex<T> referenceVertex, HashSet<T> visited, T searchVertexKey)
        {
            var Q = new Queue_<IGraphVertex<T>>();
            Q.EnQueue(referenceVertex);
            visited.Add(referenceVertex.Key);

            while (Q.Count > 0)
            {
                var current = Q.DeQueue();
                Console.WriteLine(current.Key);
                if (current.Key.Equals(searchVertexKey)) return true;

                foreach (var edge in current.Edges)
                {
                    if (visited.Contains(edge.TargetVertexKey)) continue;
                    visited.Add(edge.TargetVertexKey);
                    Q.EnQueue(edge.TargetVertex);
                }
            }

            return false;
        }
    }
}
