using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Edge<T, TW> : IEdge<T> where TW : IComparable
    {
        private object weight;
        public T TargetVertexKey => TargetVertex.Key;

        public IGraphVertex<T> TargetVertex { get; private set; }

        public Edge(IGraphVertex<T> target, TW weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }

        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }

    public class DiEdge<T, TW> : IDiEdge<T> where TW : IComparable
    {
        private object weight;
        public IDiGraphVertex<T> TargetVertex { get; private set; }

        public T TargetVertexKey => TargetVertex.Key;

        IGraphVertex<T> IEdge<T>.TargetVertex => (IGraphVertex<T>)TargetVertex;

        public DiEdge(IDiGraphVertex<T> target, TW weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }

        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }
}
