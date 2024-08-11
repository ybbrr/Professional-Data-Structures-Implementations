using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjencencySet
{
    public class WeightedGraph<T, TW> : IGraph<T> where TW : IComparable
    {
        private Dictionary<T, WeightedGraphVertex<T, TW>> vertices;
        public bool isWeightedGraph => true;

        public int Count => vertices.Count;

        public IGraphVertex<T> ReferenceVertex => vertices[this.First()];

        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable => vertices.Select(x => x.Value);

        public WeightedGraph()
        {
            vertices = new Dictionary<T, WeightedGraphVertex<T, TW>>();
        }

        public WeightedGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, WeightedGraphVertex<T, TW>>();
            foreach (var item in collection)
            {
                AddVertex(item);
            }
        }

        public void AddVertex(T key)
        {
            if (key == null) throw new ArgumentNullException("key");

            var newVertex = new WeightedGraphVertex<T, TW>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public WeightedGraph<T, TW> Clone()
        {
            var graph = new WeightedGraph<T, TW>();

            foreach (var vertex in vertices)
            {
                graph.AddVertex(vertex.Key);
            }

            foreach (var vertex in vertices)
            {
                foreach (var edge in vertex.Value.Edges)
                {
                    graph.AddEdge(vertex.Value.Key, edge.Key.Key, edge.Value);
                }
            }

            return graph;
        }

        public bool ContainVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            if (key == null) throw new ArgumentNullException("key is null");

            return vertices[key].Edges.Select(x => x.Key.Key);
        }

        public IGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null) throw new ArgumentNullException("source or dest is null");

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("Source or destination is not in the graph");

            return vertices[source].Edges.ContainsKey(vertices[dest]) && vertices[dest].Edges.ContainsKey(vertices[source]);
        }

        public void AddEdge(T source, T dest, TW weight)
        {
            if (source == null || dest == null) throw new ArgumentNullException("source or dest is null");

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("Source or destination is not in the graph");

            if (vertices[source].Edges.ContainsKey(vertices[dest]) ||
                vertices[dest].Edges.ContainsKey(vertices[source])) throw new Exception("The edge has been already defined.");

            vertices[source].Edges.Add(vertices[dest], weight);
            vertices[dest].Edges.Add(vertices[source], weight);
            //Yönlü graph olmadığı için iki düğüm arasında birbirine gidiş var.
        }

        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null) throw new ArgumentNullException("source or dest is null");

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("Source or destination is not in the graph");

            if (vertices[source].Edges.ContainsKey(vertices[dest]) ||
                vertices[dest].Edges.ContainsKey(vertices[source])) throw new Exception("The edge does not exist.");

            vertices[source].Edges.Remove(vertices[dest]);
            vertices[dest].Edges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null) throw new ArgumentNullException("key is null");

            if (!vertices.ContainsKey(key)) throw new ArgumentException("The vertex is not in this graph.");

            foreach (var vertex in vertices[key].Edges)
            {
                vertex.Key.Edges.Remove(vertices[key]);
            }

            vertices.Remove(key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class WeightedGraphVertex<T, TW> : IGraphVertex<T> where TW : IComparable
        {
            public T Key { get; set; }

            public Dictionary<WeightedGraphVertex<T, TW>, TW> Edges;

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges => Edges.Select(x => new Edge<T, TW>(x.Key, x.Value));

            public WeightedGraphVertex(T key)
            {
                Key = key;
                Edges = new Dictionary<WeightedGraphVertex<T, TW>, TW>();
            }

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                return new Edge<T, TW>(targetVertex, Edges[(WeightedGraphVertex<T, TW>)targetVertex]);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return Edges.Select(x => x.Key.Key).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
