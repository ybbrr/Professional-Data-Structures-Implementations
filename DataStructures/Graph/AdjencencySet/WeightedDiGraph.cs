using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjencencySet
{
    public class WeightedDiGraph<T, TW> : IDiGraph<T> where TW : IComparable
    {
        private Dictionary<T, WeightedDiGraphVertex<T, TW>> vertices;
        public IDiGraphVertex<T> ReferenceVertex => vertices[this.First()];

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable => vertices.Select(x => x.Value);

        public bool isWeightedGraph => true;

        public int Count => vertices.Count;

        IGraphVertex<T> IGraph<T>.ReferenceVertex => (IGraphVertex<T>)vertices[this.First()]; //Interface'ler zaten birbiri için tanımlı aslında burada cast'e gerek yok.

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable => vertices.Select(x => x.Value);

        public WeightedDiGraph()
        {
            vertices = new Dictionary<T, WeightedDiGraphVertex<T, TW>>();
        }

        public WeightedDiGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, WeightedDiGraphVertex<T, TW>>();
            foreach (var item in collection)
            {
                AddVertex(item);
            }
        }

        public void AddVertex(T key)
        {
            if (key == null) throw new ArgumentNullException("key");

            var newVertex = new WeightedDiGraphVertex<T, TW>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            throw new NotImplementedException();
        }

        public WeightedDiGraph<T, TW> Clone()
        {
            var graph = new WeightedDiGraph<T, TW>();

            foreach (var vertex in vertices)
            {
                graph.AddVertex(vertex.Key);
            }

            foreach (var vertex in vertices)
            {
                foreach (var node in vertex.Value.OutEdges)
                {
                    graph.AddEdge(vertex.Value.Key, node.Key.Key, node.Value);
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

            return vertices[key].Edges.Select(x => x.TargetVertexKey); //vertices[key].OutEdges.Select(x => x.Key.Key);
        }

        public IDiGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        IGraphVertex<T> IGraph<T>.GetVertex(T key)
        {
            return GetVertex(key);
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null) throw new ArgumentNullException("source or dest is null");

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("Source or destination is not in the graph");

            return vertices[source].OutEdges.ContainsKey(vertices[dest]) && vertices[dest].InEdges.ContainsKey(vertices[source]);
        }

        public void AddEdge(T source, T dest, TW weight)
        {
            if (source == null || dest == null) throw new ArgumentNullException("source or dest is null");

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("Source or destination is not in the graph");

            if (vertices[source].OutEdges.ContainsKey(vertices[dest]) ||
                vertices[dest].InEdges.ContainsKey(vertices[source])) throw new Exception("The edge has been already defined.");

            vertices[source].OutEdges.Add(vertices[dest], weight);
            vertices[dest].InEdges.Add(vertices[source], weight);
        }

        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null) throw new ArgumentNullException("source or dest is null");

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("Source or destination is not in the graph");

            if (vertices[source].OutEdges.ContainsKey(vertices[dest]) ||
                vertices[dest].InEdges.ContainsKey(vertices[source])) throw new Exception("The edge does not exist.");

            vertices[source].OutEdges.Remove(vertices[dest]);
            vertices[dest].InEdges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null) throw new ArgumentNullException("key is null");

            if (!vertices.ContainsKey(key)) throw new ArgumentException("The vertex is not in this graph.");

            foreach (var vertex in vertices[key].OutEdges)
            {
                vertex.Key.OutEdges.Remove(vertices[key]);
            }

            foreach (var vertex in vertices[key].InEdges)
            {
                vertex.Key.InEdges.Remove(vertices[key]);
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

        private class WeightedDiGraphVertex<T, TW> : IDiGraphVertex<T> where TW : IComparable
        {
            public Dictionary<WeightedDiGraphVertex<T, TW>, TW> OutEdges;
            public Dictionary<WeightedDiGraphVertex<T, TW>, TW> InEdges;
            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.OutEdges => OutEdges.Select(x => new DiEdge<T, TW>(x.Key, x.Value));
            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.InEdges => InEdges.Select(x => new DiEdge<T, TW>(x.Key, x.Value));

            public int OutEdgesCount => OutEdges.Count;

            public int InEdgesCount => InEdges.Count;

            public T Key { get; set; }

            public IEnumerable<IEdge<T>> Edges => OutEdges.Select(x => new Edge<T, TW>(x.Key, x.Value));

            public WeightedDiGraphVertex(T key)
            {
                Key = key;
                OutEdges = new Dictionary<WeightedDiGraphVertex<T,TW>, TW>();
                InEdges = new Dictionary<WeightedDiGraphVertex<T, TW>, TW>();
            }

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                var node = (WeightedDiGraphVertex<T, TW>)targetVertex;
                return new Edge<T, TW>(targetVertex, OutEdges[node]);
            }

            public IDiEdge<T> GetOuterEdge(IDiGraphVertex<T> targetVertex)
            {
                var node = (WeightedDiGraphVertex<T, TW>)targetVertex;
                return new DiEdge<T, TW>(targetVertex, OutEdges[node]);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return OutEdges.Select(x => x.Key.Key).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
