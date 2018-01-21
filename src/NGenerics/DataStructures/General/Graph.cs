/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


/*
 * Contributions : 
 *  - Topological sort contributed by David Larson.
 *  - FindCycles (Tarjan's algorithm) by Andre van der Merwe : http://andrevdm.blogspot.com/.
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NGenerics.Patterns.Visitor;
using NGenerics.Util;
// ReSharper disable RedundantUsingDirective
using NGenerics.DataStructures.Queues;
// ReSharper restore RedundantUsingDirective
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// An implementation of a Graph data structure.  The graph can be either
    /// directed or undirected.
    /// </summary>
	/// <typeparam name="T">The type of elements in the graph.</typeparam>
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    public class Graph<T> : ICollection<T>
    {
        #region Globals

        internal const string couldNotBeFoundInTheGraph = "The vertex specified could not be found in the graph.";
        const string graphIsEmpty = "The graph is empty.";
        private readonly Dictionary<Vertex<T>, object> graphVertices;
        private readonly Dictionary<Edge<T>, object> graphEdges;
        private readonly bool graphIsDirected;

        #endregion

        #region Construction

        /// <param name="isDirected">if set to <c>true</c> [is directed].</param>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the Constructor method."/>
        /// </example>
        public Graph(bool isDirected)
        {
            graphIsDirected = isDirected;
            graphVertices = new Dictionary<Vertex<T>, object>();
            graphEdges = new Dictionary<Edge<T>, object>();
        }

        #endregion

        #region ICollection<T> Members

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="IsEmpty" lang="cs" title="The following example shows how to use the IsEmpty property."/>
        /// </example>
        public bool IsEmpty
        {
            get
            {
                return graphVertices.Count == 0;
            }
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="Count" lang="cs" title="The following example shows how to use the Count property."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        int ICollection<T>.Count
        {
            get
            {
                return graphVertices.Count;
            }
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="AddVertex" lang="cs" title="The following example shows how to use the AddVertex method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void ICollection<T>.Add(T item)
        {
            AddVertex(new Vertex<T>(item));
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="Contains" lang="cs" title="The following example shows how to use the Contains method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        bool ICollection<T>.Contains(T item)
        {
            return ContainsVertex(item);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="CopyTo" lang="cs" title="The following example shows how to use the CopyTo method."/>
        /// </example>
        public void CopyTo(T[] array, int arrayIndex)
        {
            #region Validation

            Guard.ArgumentNotNull(array, "array");
            if ((array.Length - arrayIndex) < graphVertices.Count)
            {
                throw new ArgumentException(Constants.NotEnoughSpaceInTheTargetArray, "array");
            }

            #endregion

            var counter = arrayIndex;

            foreach (var vertex in graphVertices.Keys)
            {
                array.SetValue(vertex.Data, counter);
                counter++;
            }
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="Remove" lang="cs" title="The following example shows how to use the Remove method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        bool ICollection<T>.Remove(T item)
        {
            return RemoveVertex(item);
        }



        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <example>
        /// 	<code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="GetEnumerator" lang="cs" title="The following example shows how to use the GetEnumerator method."/>
        /// </example>
        public IEnumerator<T> GetEnumerator()
        {
            var vertexList = new List<Vertex<T>>(graphVertices.Count);
            vertexList.AddRange(graphVertices.Keys);

            for (var i = 0; i < vertexList.Count; i++)
            {
                yield return vertexList[i].Data;
            }
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
        /// </example>
        public void Clear()
        {
            graphVertices.Clear();
            graphEdges.Clear();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Performs a depth-first traversal, starting at the specified vertex.
        /// </summary>
        /// <param name="visitor">The visitor to use.  In-order traversal is not applicable in a graph.</param>
        /// <param name="startVertex">The vertex to start from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="visitor"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="startVertex"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="DepthFirstTraversal" lang="cs" title="The following example shows how to use the DepthFirstTraversal method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void DepthFirstTraversal(OrderedVisitor<Vertex<T>> visitor, Vertex<T> startVertex)
        {
            Guard.ArgumentNotNull(visitor, "visitor");
            Guard.ArgumentNotNull(startVertex, "startVertex");

            var visitedVertices = new List<Vertex<T>>(graphVertices.Count);

            DepthFirstTraversal(visitor, startVertex, ref visitedVertices);
        }

        /// <summary>
        /// Determines whether this graph is cyclic (contains cycles).
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance contains cycles; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>The topological sort algorithm is only valid for a directed, acyclic (cycle free) graph.</remarks>
        /// <remarks>In order to detect cycles, a topological sort of the graph is computed.</remarks>
        /// <exception cref="InvalidOperationException">The graph contains cycles.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="IsCyclic" lang="cs" title="The following example shows how to use the IsCyclic method."/>
        /// </example>
        public bool IsCyclic()
        {
            var visitor = new DummyVisitor<Vertex<T>>();

            var count = TopologicalSortTraversalInternal(visitor);

            // If the visitor has not visited each and every vertex in the 
            // graph, it has cycles in it.
            return count < graphVertices.Count;
        }

        /// <summary>
        /// Computes the topological sort of the graph.
        /// </summary>
        /// <remarks>This operation is only defined on a directed graph.</remarks>
        /// <remarks>The topological sort algorithm is only valid for a directed, acyclic (cycle free) graph.</remarks>
        /// <returns>A list of vertices in topological order.</returns>
        /// <exception cref="InvalidOperationException">The graph contains cycles.</exception>
        /// <exception cref="ArgumentException">The graph is not directed.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="TopologicalSort" lang="cs" title="The following example shows how to use the TopologicalSort method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IList<Vertex<T>> TopologicalSort()
        {
            var visitor = new TrackingVisitor<Vertex<T>>();
            TopologicalSortTraversal(visitor);

            return visitor.TrackingList;
        }

        /// <summary>
        /// Visits very vertex in the graph (provided it doesn't have cycles) in topological order.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <exception cref="ArgumentException">The graph is not directed.</exception>
        /// <remarks>The topological sort algorithm is only valid for a directed, acyclic (cycle free) graph.</remarks>
        /// <exception cref="InvalidOperationException">The graph contains cycles.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="TopologicalSortTraversal" lang="cs" title="The following example shows how to use the TopologicalSortTraversal method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void TopologicalSortTraversal(IVisitor<Vertex<T>> visitor)
        {
            var count = TopologicalSortTraversalInternal(visitor);

            if (count < graphVertices.Count)
            {
                throw new InvalidOperationException("A cycle was found in the graph.");
            }
        }
        

        /// <summary>
        /// Performs a breadth-first traversal from the specified vertex.
        /// </summary>
        /// <param name="visitor">The visitor to use.</param>
        /// <param name="startVertex">The vertex to start from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="visitor"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="startVertex"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="BreadthFirstTraversal" lang="cs" title="The following example shows how to use the BreadthFirstTraversal method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void BreadthFirstTraversal(IVisitor<Vertex<T>> visitor, Vertex<T> startVertex)
        {
            Guard.ArgumentNotNull(visitor, "visitor");
            Guard.ArgumentNotNull(startVertex, "startVertex");

            var visitedVertices = new List<Vertex<T>>(graphVertices.Count);

            var visitableQueue = new Queue<Vertex<T>>();

            visitableQueue.Enqueue(startVertex);
            visitedVertices.Add(startVertex);

            while (!((visitableQueue.Count == 0) || (visitor.HasCompleted)))
            {
                var vertex = visitableQueue.Dequeue();

                visitor.Visit(vertex);

                var edges = vertex.EmanatingEdges;

                for (var i = 0; i < edges.Count; i++)
                {
                    var vertexToVisit = edges[i].GetPartnerVertex(vertex);

                    if (!visitedVertices.Contains(vertexToVisit))
                    {
                        visitableQueue.Enqueue(vertexToVisit);
                        visitedVertices.Add(vertexToVisit);
                    }
                }
            }
        }

        /// <summary>
        /// Removes the specified vertex from the graph.
        /// </summary>
        /// <param name="vertex">The vertex to be removed.</param>
        /// <returns>A value indicating whether the vertex was found (and removed) in the graph.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vertex"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="RemoveVertex" lang="cs" title="The following example shows how to use the RemoveVertex method."/>
        /// </example>
        public bool RemoveVertex(Vertex<T> vertex)
        {
            //no need to check vertex for null as graphVertices.Remove will do this
            if (!graphVertices.Remove(vertex))
            {
                return false;
            }
            
            // Delete all the edges in which this vertex forms part of
            var list = vertex.IncidentEdges;

            while (list.Count > 0)
            {
                RemoveEdge(list[0]);
            }

            return true;
        }

        /// <summary>
        /// Removes the vertex with the specified value from the graph.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if a vertex with the value specified was found (and removed) in the graph; otherwise <c>false</c>.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="RemoveVertexFromValue" lang="cs" title="The following example shows how to use the RemoveVertex method."/>
        /// </example>
        public bool RemoveVertex(T item)
        {
            foreach (var vertex in graphVertices.Keys)
            {
                if (vertex.Data.Equals(item))
                {
                    RemoveVertex(vertex);
                    return true;
                }
            }

            return false;
        }
        

        /// <summary>
        /// Determines whether this graph contains the specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex.</param>
        /// <returns>
        /// 	<c>true</c> if this instance contains the specified vertex; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="ContainsVertex" lang="cs" title="The following example shows how to use the ContainsVertex method."/>
        /// </example>
        public bool ContainsVertex(Vertex<T> vertex)
        {
            return graphVertices.ContainsKey(vertex);
        }

        /// <summary>
        /// Determines whether the specified item is contained in the graph.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if the specified item contains vertex; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="ContainsVertexValue" lang="cs" title="The following example shows how to use the ContainsVertex method."/>
        /// </example>
        public bool ContainsVertex(T item)
        {
            foreach (var vertex in graphVertices.Keys)
            {
                if (vertex.Data.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
                
        /// <summary>
        /// Gets a value indicating whether this instance is directed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is directed; otherwise, <c>false</c>.
        /// </value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="IsDirected" lang="cs" title="The following example shows how to use the IsDirected property."/>
        /// </example>
        public bool IsDirected
        {
            get
            {
                return graphIsDirected;
            }
        }

        /// <summary>
        /// Removes the edge specified from the graph.
        /// </summary>
        /// <param name="edge">The edge to be removed.</param>
		/// <returns>A value indicating whether the edge specified was found (and removed) from the graph.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="edge"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="RemoveEdge" lang="cs" title="The following example shows how to use the RemoveEdge method."/>
        /// </example>
        public bool RemoveEdge(Edge<T> edge)
        {
            #region Validation

            CheckEdgeNotNull(edge);

            #endregion

            if (!graphEdges.Remove(edge))
            {
                return false;
            }

            edge.FromVertex.RemoveEdge(edge);
            edge.ToVertex.RemoveEdge(edge);

            return true;
        }



        /// <summary>
        /// Removes the edge specified from the graph.
        /// </summary>
        /// <param name="from">The from vertex.</param>
        /// <param name="to">The to vertex.</param>
        /// <returns>A value indicating whether the edge between the two vertices supplied was found (and removed) from the graph.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="RemoveEdgeFromVertices" lang="cs" title="The following example shows how to use the RemoveEdge method."/>
        /// </example>
        public bool RemoveEdge(Vertex<T> from, Vertex<T> to)
        {
            Guard.ArgumentNotNull(from, "from");
            Guard.ArgumentNotNull(to, "to");
            if (graphIsDirected)
            {
                foreach (var edge in graphEdges.Keys)
                {
                    if ((edge.FromVertex == from) && (edge.ToVertex == to))
                    {
                        RemoveEdge(edge);
                        return true;
                    }
                }
            }
            else
            {
                foreach (var edge in graphEdges.Keys)
                {
                    if (((edge.FromVertex == from) && (edge.ToVertex == to)) ||
                        ((edge.FromVertex == to) && (edge.ToVertex == from)))
                    {
                        RemoveEdge(edge);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Adds the specified edge to the graph.
        /// </summary>
		/// <param name="edge">The edge to add.</param>
		/// <exception cref="ArgumentNullException"><paramref name="edge"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><see cref="Edge{T}.IsDirected"/> of <paramref name="edge"/> doe not equal <see cref="Edge{T}.IsDirected"/> of the current instance.</exception>
        /// <exception cref="ArgumentException">Either <see cref="Edge{T}.FromVertex"/> or <see cref="Edge{T}.ToVertex"/> of <paramref name="edge"/> cannot be found the current instance.</exception>
        /// <exception cref="ArgumentException"><see cref="Edge{T}.ToVertex"/> of <paramref name="edge"/> already exists on the current instance.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="AddEdge" lang="cs" title="The following example shows how to use the AddEdge method."/>
        /// </example>
        public void AddEdge(Edge<T> edge)
        {
            #region Validation

            CheckEdgeNotNull(edge);

            if (edge.IsDirected != graphIsDirected)
            {
                throw new ArgumentException("The type of edge must be the same as the type of graph (Undirected / Directed)", "edge");
            }

            if ((!graphVertices.ContainsKey(edge.FromVertex)) || (!graphVertices.ContainsKey(edge.ToVertex)))
            {
                throw new ArgumentException(couldNotBeFoundInTheGraph, "edge");
            }

            if (edge.FromVertex.HasEmanatingEdgeTo(edge.ToVertex))
            {
                throw new ArgumentException("The edge between the vertices specified already exists.", "edge");
            }

            #endregion

            graphEdges.Add(edge, null);
            AddEdgeToVertices(edge);
        }

        /// <summary>
        /// Adds the vertex specified to the graph.
        /// </summary>
        /// <param name="vertex">The vertex to add.</param>
        /// <exception cref="ArgumentException"><paramref name="vertex"/> already exists in the current instance.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="vertex"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="AddVertex" lang="cs" title="The following example shows how to use the AddVertex method."/>
        /// </example>
        public void AddVertex(Vertex<T> vertex)
        {
            #region Validation

			Guard.ArgumentNotNull(vertex,"vertex");
            
			if (graphVertices.ContainsKey(vertex))
            {
                throw new ArgumentException("The vertex already exists in the graph.", "vertex");
            }

            #endregion

            graphVertices.Add(vertex, null);
        }

        /// <summary>
        /// Adds a vertex to the graph with the specified data item.
        /// </summary>
        /// <param name="item">The item to store in the vertex.</param>
        /// <returns>The <see cref="Vertex{T}"/> created and added to the graph.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="AddVertexFromValue" lang="cs" title="The following example shows how to use the AddVertex method."/>
        /// </example>
        public Vertex<T> AddVertex(T item)
        {
            var vertex = new Vertex<T>(item);
            graphVertices.Add(vertex, null);
            return vertex;
        }

        /// <summary>
        /// Adds the edge to the graph.
        /// </summary>
        /// <param name="from">The from vertex.</param>
        /// <param name="to">The to vertex.</param>
        /// <returns>The newly created <see cref="Edge{T}"/>.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="AddEdgeFromVertices" lang="cs" title="The following example shows how to use the AddEdge method."/>
        /// </example>
        public Edge<T> AddEdge(Vertex<T> from, Vertex<T> to)
        {
            var edge = new Edge<T>(from, to, graphIsDirected);
            AddEdge(edge);
            return edge;
        }

        /// <summary>
        /// Adds the edge to the graph.
        /// </summary>
        /// <param name="from">The from vertex.</param>
        /// <param name="to">The to vertex.</param>
        /// <param name="weight">The weight of this edge.</param>
        /// <returns>The newly created <see cref="Edge{T}"/>.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="AddWeightedEdgeFromVertices" lang="cs" title="The following example shows how to use the AddEdge method."/>
        /// </example>
        public Edge<T> AddEdge(Vertex<T> from, Vertex<T> to, double weight)
        {
            var edge = new Edge<T>(from, to, weight, graphIsDirected);
            AddEdge(edge);
            return edge;
        }

        /// <summary>
        /// Gets the vertices contained in this graph.
        /// </summary>
        /// <value>The vertices contained in this graph.</value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="Vertices" lang="cs" title="The following example shows how to use the Vertices property."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public ICollection<Vertex<T>> Vertices
        {
            get
            {
                return graphVertices.Keys;
            }
        }

        /// <summary>
        /// Gets the edges contained in this graph.
        /// </summary>
        /// <value>The edges contained in this graph.</value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="Edges" lang="cs" title="The following example shows how to use the Edges property."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public ICollection<Edge<T>> Edges
        {
            get
            {
                return graphEdges.Keys;
            }
        }


        /// <summary>
        /// Gets a value indicating whether this graph is weakly connected.
        /// </summary>
        /// <returns><c>true</c> if this graph is weakly connected; otherwise, <c>false</c>.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="Graph{T}"/> is empty.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="IsWeaklyConnected" lang="cs" title="The following example shows how to use the IsWeaklyConnected method."/>
        /// </example>
        public bool IsWeaklyConnected()
        {
            if (graphVertices.Count == 0)
            {
                throw new InvalidOperationException(graphIsEmpty);
            }

            var countingVisitor = new CountingVisitor<Vertex<T>>();

            BreadthFirstTraversal(countingVisitor, GetAnyVertex());

            return (countingVisitor.Count == graphVertices.Count);
        }

        /// <summary>
        /// Gets a value indicating whether this graph is weakly connected.
        /// </summary>
        /// <returns><c>true</c> if this graph is weakly connected; otherwise, <c>false</c>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="IsDirected"/> is <c>true</c>.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="Graph{T}"/> is empty.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="IsStronglyConnected" lang="cs" title="The following example shows how to use the IsStronglyConnected method."/>
        /// </example>
        public bool IsStronglyConnected()
        {
            #region Validation

            if (graphIsDirected)
            {
                throw new InvalidOperationException("This operation is only valid on a directed graph. For undirected graphs, rather test for weak connectedness.");
            }

            if (graphVertices.Count == 0)
            {
                throw new InvalidOperationException(graphIsEmpty);
            }

            #endregion

            var countingVisitor = new CountingVisitor<Vertex<T>>();

            foreach (var vertex in graphVertices.Keys)
            {
                BreadthFirstTraversal(countingVisitor, vertex);

                if (countingVisitor.Count != graphVertices.Count)
                {
                    return false;
                }

                countingVisitor.ResetCount();
            }

            return true;
        }

        /// <summary>
        /// Determines whether the vertex with the specified from value has an edge to a vertex with the specified to value.
        /// </summary>
        /// <param name="fromValue">The from vertex value.</param>
        /// <param name="toValue">The to vertex value.</param>
        /// <returns>
        /// 	<c>true</c> if the vertex with the specified from value has an edge to a vertex with the specified to value; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="ContainsEdgeFromVerticeValues" lang="cs" title="The following example shows how to use the ContainsEdge method."/>
        /// </example>
        public bool ContainsEdge(T fromValue, T toValue)
        {
            if (graphIsDirected)
            {
                foreach (var edge in graphEdges.Keys)
                {
                    if ((edge.FromVertex.Data.Equals(fromValue) &&
                        (edge.ToVertex.Data.Equals(toValue))))
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (var edge in graphEdges.Keys)
                {
                    if (((edge.FromVertex.Data.Equals(fromValue) &&
                        (edge.ToVertex.Data.Equals(toValue)))) ||
                        ((edge.FromVertex.Data.Equals(toValue) &&
                        (edge.ToVertex.Data.Equals(fromValue)))))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified vertex has a edge to the to vertex.
        /// </summary>
        /// <param name="from">The from vertex.</param>
        /// <param name="to">The to vertex.</param>
        /// <returns>
        /// 	<c>true</c> if the specified from vertex has an edge to the to vertex; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="ContainsEdgeFromVertices" lang="cs" title="The following example shows how to use the ContainsEdge method."/>
        /// </example>
        public bool ContainsEdge(Vertex<T> from, Vertex<T> to)
        {
            return graphIsDirected ? from.HasEmanatingEdgeTo(to) : from.HasIncidentEdgeWith(to);
        }

        /// <summary>
        /// Determines whether the specified edge is contained in this graph.
        /// </summary>
        /// <param name="edge">The edge to look for.</param>
        /// <returns>
        /// 	<c>true</c> if the specified edge is contained in the graph; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="ContainsEdge" lang="cs" title="The following example shows how to use the ContainsEdge method."/>
        /// </example>
        public bool ContainsEdge(Edge<T> edge)
        {
            return graphEdges.ContainsKey(edge);
        }

        /// <summary>
        /// Gets the edge specified by the two vertices.
        /// </summary>
        /// <param name="from">The from vertex.</param>
        /// <param name="to">The two vertex.</param>
        /// <returns>The <see cref="Edge{T}"/> between the two specified vertices if found; otherwise a null reference.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="GetEdge" lang="cs" title="The following example shows how to use the GetEdge method."/>
        /// </example>
        public Edge<T> GetEdge(Vertex<T> from, Vertex<T> to)
        {
            return from.GetEmanatingEdgeTo(to);
        }

        /// <summary>
        /// Gets the edge specified by the two vertices.
        /// </summary>
        /// <param name="fromVertexValue">The from vertex value.</param>
        /// <param name="toVertexValue">The to vertex value.</param>
		/// <returns>The <see cref="Edge{T}"/> formed by vertices with the specified values if found, otherwise a null reference.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="GetEdgeFromVertexValue" lang="cs" title="The following example shows how to use the GetEdge method."/>
        /// </example>
        public Edge<T> GetEdge(T fromVertexValue, T toVertexValue)
        {
            foreach (var vertex in graphVertices.Keys)
            {
                if (vertex.Data.Equals(fromVertexValue))
                {
                    for (var i = 0; i < vertex.EmanatingEdges.Count; i++)
                    {
                        var edge = vertex.EmanatingEdges[i];
                        var partner = edge.GetPartnerVertex(vertex);

                        if (partner.Data.Equals(toVertexValue))
                        {
                            return edge;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the vertex with the specified value.
        /// </summary>
        /// <param name="vertexValue">The vertex value to look for.</param>
        /// <returns>The <see cref="Vertex{T}"/> with the specified value.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="GetVertex" lang="cs" title="The following example shows how to use the GetVertex method."/>
        /// </example>
        public Vertex<T> GetVertex(T vertexValue)
        {
            foreach (var vertex in graphVertices.Keys)
            {
                if (vertex.Data.Equals(vertexValue))
                {
                    return vertex;
                }
            }

            return null;
        }

        /// <summary>
        /// Find all vertices matching the predicate supplied.
        /// </summary>
        /// <returns>All vertices matching <paramref name="predicate"/>.</returns>
        /// <param name="predicate">The predicate (condition) to use.</param>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="FindVertices" lang="cs" title="The following example shows how to use the FindVertices method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IList<Vertex<T>> FindVertices(Predicate<T> predicate)
        {
            Guard.ArgumentNotNull(predicate, "predicate");
            
            var list = new List<Vertex<T>>();

            foreach (var vertex in graphVertices.Keys)
            {
                if (predicate(vertex.Data))
                {
                    list.Add(vertex);
                }
            }

            return list;
        }

        /// <summary>
        /// Finds cycles in a graph using Tarjan's strongly connected components algorithm.
        /// See http://en.wikipedia.org/wiki/Tarjan's_strongly_connected_components_algorithm
        /// </summary>
        /// <returns>A list of of vertice arrays (paths) that form cycles in the graph.</returns>
        public IList<Vertex<T>[]> FindCycles()
        {
            return FindCycles( true );
        }

        /// <summary>
        /// Finds cycles in a graph using Tarjan's strongly connected components algorithm.
        /// See http://en.wikipedia.org/wiki/Tarjan's_strongly_connected_components_algorithm
        /// </summary>
        /// <param name="excludeSingleItems">if set to <c>true</c> nodes with no edges are excluded.</param>
        /// <returns>A list of of vertice arrays (paths) that form cycles in the graph.</returns>
        public IList<Vertex<T>[]> FindCycles( bool excludeSingleItems )
        {
            var indices = new Dictionary<Vertex<T>, int>();
            var lowlinks = new Dictionary<Vertex<T>, int>();
            var connected = new List<Vertex<T>[]>();
            var stack = new Stack<Vertex<T>>();
            

            foreach( var vertex in Vertices )
            {
                if( !indices.ContainsKey( vertex ) )
                {
                    TarjansStronglyConnectedComponentsAlgorithm( excludeSingleItems, vertex, indices, lowlinks, connected, stack, 0 );
                }
            }

            return connected;
        }
        #endregion

        #region Private Members

        /// <summary>
        /// Allows a visitor to visit each vertex in topological order.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>The number of items visited.</returns>
        private int TopologicalSortTraversalInternal(IVisitor<Vertex<T>> visitor)
        {
            #region Validation

            Guard.ArgumentNotNull(visitor, "visitor");

            if (!IsDirected)
            {
                throw new ArgumentException("The current operation is only valid for a directed graph.");
            }

            #endregion

            var visitCount = 0;

            if (!IsEmpty)
            {
                var depth = new Dictionary<Vertex<T>, int>(graphVertices.Count);

                // Create a new queue to store the vertices to visit.
                var queue = new Queue<Vertex<T>>();

                foreach (var vertex in Vertices)
                {
                    var incomingCount = vertex.IncomingEdgeCount;
                    depth.Add(vertex, incomingCount);

                    // Enqueue those with depth 0
                    if (incomingCount == 0)
                    {
                        queue.Enqueue(vertex);
                    }
                }

                // If no vertices are found with incoming edge count 0, the graph is cyclic,
                // and we don't visit any vertices
                if (queue.Count > 0)
                {
                    while ((queue.Count > 0) && (!visitor.HasCompleted))
                    {
                        var vertex = queue.Dequeue();
                        depth.Remove(vertex);

                        // Visit the vertex in the topological sort order
                        visitor.Visit(vertex);

                        // Keep track of the amount of vertices we visit,
                        // so we can know if the graph has cycles in it or not.
                        visitCount++;

                        // Enumerate through all the edges emanating from this node,
                        // decreasing the depth of the vertex (thereby "removing" it
                        // from the graph, and enqueue all those with depth 0.  The
                        // effect is an ordering by incoming edge counts.
                        foreach (var edge in vertex.EmanatingEdges)
                        {
                            var partnerVertex = edge.ToVertex;

                            depth[partnerVertex]--;

                            if (depth[partnerVertex] == 0)
                            {
                                queue.Enqueue(partnerVertex);
                            }
                        }
                    }
                }
            }

            return visitCount;
        }

        /// <summary>
        /// Performs a depth-first traversal.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="startVertex">The start vertex.</param>
        /// <param name="visitedVertices">The visited vertices.</param>
        private static void DepthFirstTraversal(OrderedVisitor<Vertex<T>> visitor, Vertex<T> startVertex, ref List<Vertex<T>> visitedVertices)
        {
            if (visitor.HasCompleted)
            {
                return;
            }

            // Add the vertex to the "visited" list
            visitedVertices.Add(startVertex);

            // Visit the vertex in pre-order
            visitor.VisitPreOrder(startVertex);

            // Get the list of emanating edges from the vertex
            var edges = startVertex.EmanatingEdges;

            for (var i = 0; i < edges.Count; i++)
            {
                // Get the partner vertex of the start vertex
                var vertexToVisit = edges[i].GetPartnerVertex(startVertex);

                // If the vertex hasn't been visited before, do a depth-first
                // traversal starting at that vertex
                if (!visitedVertices.Contains(vertexToVisit))
                {
                    DepthFirstTraversal(visitor, vertexToVisit, ref visitedVertices);
                }
            }

            // Visit the vertex in post order
            visitor.VisitPostOrder(startVertex);
        }

        /// <summary>
        /// Adds the edge to the vertices in the edge.
        /// </summary>
        /// <param name="edge">The edge to add.</param>
        private static void AddEdgeToVertices(Edge<T> edge)
        {
            #region Asserts

            Debug.Assert(edge != null);
            Debug.Assert(edge.FromVertex != null);
            Debug.Assert(edge.ToVertex != null);

            #endregion

            edge.FromVertex.AddEdge(edge);

            if (edge.FromVertex != edge.ToVertex)
            {
                edge.ToVertex.AddEdge(edge);
            }
        }

        /// <summary>
        /// Checks that the edge is not null.
        /// </summary>
        /// <param name="edge">The edge to check.</param>
        /// <exception cref="ArgumentNullException"><paramref name="edge"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        private static void CheckEdgeNotNull(Edge<T> edge)
        {
            Guard.ArgumentNotNull(edge, "edge");

            #region Asserts

            // Since the edge constructor doesn't allow null vertices,
            // is shouldn't be necessary to check for those here.
            // Rather, substitute the exceptions with Asserts.

            Debug.Assert(edge.FromVertex != null);
            Debug.Assert(edge.ToVertex != null);

            #endregion
        }

        /// <summary>
        /// Gets any vertex.
        /// </summary>
        /// <returns>Any vertex.</returns>
        private Vertex<T> GetAnyVertex()
        {
            #region Asserts

            Debug.Assert(graphVertices.Count > 0);

            #endregion

			foreach (var key in graphVertices.Keys)
        	{
				return key;
        	}
        	return default(Vertex<T>);
        }

        /// <summary>
        /// Executes Tarjan's algorithm on the graph.
        /// </summary>
        /// <param name="excludeSinlgeItems">if set to <c>true</c> [exclude sinlge items].</param>
        /// <param name="vertex">The vertex to start with.</param>
        /// <param name="indices">The current indices.</param>
        /// <param name="lowlinks">The current lowlinks.</param>
        /// <param name="connected">The connected components.</param>
        /// <param name="stack">The stack.</param>
        /// <param name="index">The current index.</param>
        private static void TarjansStronglyConnectedComponentsAlgorithm( 
            bool excludeSinlgeItems, 
            Vertex<T> vertex,
            IDictionary<Vertex<T>, int> indices,
            IDictionary<Vertex<T>, int> lowlinks,
            ICollection<Vertex<T>[]> connected,
            Stack<Vertex<T>> stack,
            int index )
        {
            indices[vertex] = index;
            lowlinks[vertex] = index;
            index++;

            stack.Push( vertex );

            foreach( var edge in vertex.EmanatingEdges )
            {
                var next = edge.ToVertex;

                if( !indices.ContainsKey( next ) )
                {
                    TarjansStronglyConnectedComponentsAlgorithm(excludeSinlgeItems, next, indices, lowlinks, connected, stack, index);
                    lowlinks[vertex] = Math.Min( lowlinks[vertex], lowlinks[ next ] );
                }
                else if( stack.Contains( next ) )
                {
                    lowlinks[vertex] = Math.Min( lowlinks[vertex], lowlinks[ next ] );
                }
            }

            if( lowlinks[vertex] == indices[vertex] )
            {
                Vertex<T> next;
                var component = new List<Vertex<T>>();

                do
                {
                    next = stack.Pop();
                    component.Add( next );

                } while( next != vertex );

                if( !excludeSinlgeItems || (component.Count > 1) )
                {
                    connected.Add( component.ToArray());
                }
            }
        }
        #endregion

        #region ICollection<T> Members


		/// <inheritdoc />
        /// <value>
        /// 	Always <c>false</c>.
        /// </value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="IsReadOnly" lang="cs" title="The following example shows how to use the IsReadOnly property."/>
        /// </example>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region IEnumerable Members


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\GraphExamples.cs" region="GetEnumerator" lang="cs" title="The following example shows how to use the GetEnumerator method."/>
        /// </example>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
