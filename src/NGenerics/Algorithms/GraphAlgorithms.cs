/*  
 Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
 *   
 *  Notes :
 *      - Kruskal's Algorithm was contributed by Brandon Turner (turnerb7@msu.edu).  Thanks Brandon!
*/

using System;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.General;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Util;

namespace NGenerics.Algorithms
{
    /// <summary>
    /// Several algorithms for use on graphs
    /// </summary>
    public static class GraphAlgorithms
    {
        #region Public Methods

        /// <summary>
        /// Finds the shortest paths to all other vertices from the specified source vertex using Dijkstra's Algorithm.
        /// </summary>
        /// <typeparam name="T">The graph node type.</typeparam>
        /// <param name="weightedGraph">The weighted graph.</param>
        /// <param name="fromVertex">The source vertex.</param>
        /// <returns>
        /// A graph representing the shortest paths from the source node to all other nodes in the graph.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="weightedGraph"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fromVertex"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="fromVertex"/> could not be found in <paramref name="weightedGraph"/>.</exception>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static Graph<T> DijkstrasAlgorithm<T>(Graph<T> weightedGraph, Vertex<T> fromVertex)
        {
            #region Parameter Checks

            Guard.ArgumentNotNull(weightedGraph, "weightedGraph");
            Guard.ArgumentNotNull(fromVertex, "fromVertex");

            if (!weightedGraph.ContainsVertex(fromVertex))
            {
                throw new ArgumentException(Graph<T>.couldNotBeFoundInTheGraph, "fromVertex");
            }

            #endregion

            var heap =
                new Heap<Association<double, Vertex<T>>>(
                    HeapType.Minimum,
                    new AssociationKeyComparer<double, Vertex<T>>());

            var vertexStatus = new Dictionary<Vertex<T>, VertexInfo<T>>();

            // Initialise the vertex distances to the maximum possible.

            foreach (var vertex in weightedGraph.Vertices)
            {
                vertexStatus.Add(vertex, new VertexInfo<T>(double.MaxValue, null, false));
            }

            vertexStatus[fromVertex].Distance = 0;

            // Add the source vertex to the heap - we'll be branching out from it.		
            heap.Add(new Association<double, Vertex<T>>(0, fromVertex));

            while (heap.Count > 0)
            {
                var item = heap.RemoveRoot();

                var vertexInfo = vertexStatus[item.Value];

                if (!vertexInfo.IsFinalised)
                {
                    var edges = item.Value.EmanatingEdges;

                    vertexStatus[item.Value].IsFinalised = true;

                    // Enumerate through all the edges emanating from this node					
                    for (var i = 0; i < edges.Count; i++)
                    {
                        var edge = edges[i];
                        var partnerVertex = edge.GetPartnerVertex(item.Value);

                        // Calculate the new distance to this distance
                        var distance = vertexInfo.Distance + edge.Weight;

                        var newVertexInfo = vertexStatus[partnerVertex];

                        // Found a better path, update the vertex status and add the 
                        // vertex to the heap for further analysis
                        if (distance < newVertexInfo.Distance)
                        {
                            newVertexInfo.EdgeFollowed = edge;
                            newVertexInfo.Distance = distance;
                            heap.Add(new Association<double, Vertex<T>>(distance, partnerVertex));
                        }
                    }
                }
            }

            return BuildGraphDijkstra(weightedGraph, fromVertex, vertexStatus);
        }

        /// <summary>
        /// Finds the minimal spanning tree of the graph supplied using Prim's algorithm.
        /// </summary>
        /// <typeparam name="T">The graph node type.</typeparam>
        /// <param name="weightedGraph">The weighted graph.</param>
        /// <param name="fromVertex">The vertex to start from.</param>
        /// <returns>
        /// A graph representing the minimal spanning tree of the graph supplied.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="weightedGraph"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fromVertex"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="fromVertex"/> could not be found in <paramref name="weightedGraph"/>.</exception>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static Graph<T> PrimsAlgorithm<T>(Graph<T> weightedGraph, Vertex<T> fromVertex)
        {
            #region Parameter Checks

            Guard.ArgumentNotNull(weightedGraph, "weightedGraph");
            Guard.ArgumentNotNull(fromVertex, "fromVertex");

            if (!weightedGraph.ContainsVertex(fromVertex))
            {
                throw new ArgumentException(Graph<T>.couldNotBeFoundInTheGraph, "fromVertex");
            }

            #endregion

            var heap =
                new Heap<Association<double, Vertex<T>>>(
                    HeapType.Minimum,
                    new AssociationKeyComparer<double, Vertex<T>>());

            var vertexStatus = new Dictionary<Vertex<T>, VertexInfo<T>>();

            // Initialise the vertex distances to 

            foreach (var vertex in weightedGraph.Vertices)
            {
                vertexStatus.Add(vertex, new VertexInfo<T>(double.MaxValue, null, false));
            }

            vertexStatus[fromVertex].Distance = 0;

            // Add the source vertex to the heap - we'll be branching out from it.		
            heap.Add(new Association<double, Vertex<T>>(0, fromVertex));

            while (heap.Count > 0)
            {
                var item = heap.RemoveRoot();

                var edges = item.Value.IncidentEdges;

                vertexStatus[item.Value].IsFinalised = true;

                // Enumerate through all the edges emanating from this node					
                for (var i = 0; i < edges.Count; i++)
                {
                    var edge = edges[i];

                    var partnerVertex = edge.GetPartnerVertex(item.Value);

                    var newVertexInfo = vertexStatus[partnerVertex];

                    if (!newVertexInfo.IsFinalised)
                    {
                        if (edge.Weight < newVertexInfo.Distance)
                        {
                            newVertexInfo.EdgeFollowed = edge;
                            newVertexInfo.Distance = edge.Weight;

                            heap.Add(new Association<double, Vertex<T>>(edge.Weight, partnerVertex));
                        }
                    }
                }
            }

            return BuildGraphPrim(weightedGraph, vertexStatus);
        }

        /// <summary>
        /// Finds the minimal spanning tree of the graph supplied.
        /// </summary>
        /// <typeparam name="T">The type of vertex, edge and graph.</typeparam>
        /// <param name="weightedGraph">The weighted graph.</param>
        /// <returns>
        /// A graph representing the minimal spanning tree of the graph supplied.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static Graph<T> KruskalsAlgorithm<T>(Graph<T> weightedGraph)
        {

            Guard.ArgumentNotNull(weightedGraph, "weightedGraph");

            // There is going be Vertices - 1 edges when we finish
            var edgeCount = weightedGraph.Vertices.Count - 1;


            var vertexToParent = new Dictionary<Vertex<T>, Vertex<T>>();
            var oldToNew = new Dictionary<Vertex<T>, Vertex<T>>();

            var edgeQueue =
                new Heap<Association<double, Edge<T>>>(
                HeapType.Minimum,
                new AssociationKeyComparer<double, Edge<T>>());


            // Now build the return graph, always return non directed.
            var returnGraph = new Graph<T>(false);

            // As we mew the new vertices for the new graph from the old
            // one, we also map the old ones to the new ones, and set up
            // our dictionary used to track forests of vertices.
            foreach (var vertex in weightedGraph.Vertices)
            {
                var vertex2 = new Vertex<T>(vertex.Data);
                oldToNew.Add(vertex, vertex2);
                returnGraph.AddVertex(vertex2);

                vertexToParent.Add(vertex, null);
            }

            // We need to move the edges into a priority queue
            // and use the weight in the association to sort them.
            foreach (var e in weightedGraph.Edges)
            {
                edgeQueue.Add(new Association<double, Edge<T>>(e.Weight, e));
            }

            // We know when we are done, when we hit the number of edges
            // or when there is no more edges.
            while ((edgeQueue.Count > 0) && (edgeCount > 0))
            {
                // Pull off the least weight edge that hasn't been added or discarded yet.
                var association = edgeQueue.RemoveRoot();

                // Save the value of the association to the proper type, an edge
                var edge = association.Value;

                // Here is the start of search to make find the heads
                // of the forest, because if they are the same heads, 
                // there is a cycle.
                var fromVertexHead = edge.FromVertex;
                var toVertexHead = edge.ToVertex;

                // Find the head vertex of the forest the fromVertex is in
                while (vertexToParent[fromVertexHead] != null)
                {
                    fromVertexHead = vertexToParent[fromVertexHead];
                }

                // Find the head vertex of the forest the toVertex is in
                while (vertexToParent[toVertexHead] != null)
                {
                       toVertexHead = vertexToParent[toVertexHead];
                }

                // Check to see if the heads are the same
                // if are equal, it is a cycle, and we cannot 
                // include the edge in the new graph.
                if (fromVertexHead != toVertexHead)
                {
                    // Join the FromVertex forest to the ToVertex
                    vertexToParent[fromVertexHead] = edge.ToVertex;

                    // We have one less edge we need to find
                    edgeCount--;

                    // Add the edge to the new new graph, map the old vertices to the new ones
                    returnGraph.AddEdge(oldToNew[edge.FromVertex], oldToNew[edge.ToVertex], edge.Weight);
                }

            }

            // All done :)
            return returnGraph;
        }

        #endregion		

        #region Private Members

        /// <summary>
        /// Builds a new graph from the edges followed.
        /// </summary>
        /// <param name="weightedGraph">The weighted graph.</param>
        /// <param name="vertexStatus">The vertex status.</param>
        /// <returns>A new graph from the edges followed.</returns>
        private static Graph<T> BuildGraphPrim<T>(Graph<T> weightedGraph, ICollection<KeyValuePair<Vertex<T>, VertexInfo<T>>> vertexStatus)
        {
            // Now build the new graph
            var newGraph = new Graph<T>(weightedGraph.IsDirected);
            
            // This dictionary is used for mapping between the old vertices and the new vertices put into the graph
            var vertexMap = new Dictionary<Vertex<T>, Vertex<T>>(vertexStatus.Count);

            foreach (var current in vertexStatus) {
                
                var newVertex = new Vertex<T>(
                    current.Key.Data,
                    current.Key.Weight
                );

                vertexMap.Add(current.Key, newVertex);

                newGraph.AddVertex(newVertex);
            }

            foreach (var current in vertexStatus) {
                var info = current.Value;

                // Check if an edge has been included to this vertex
                if ((info.EdgeFollowed != null))
                {
                    newGraph.AddEdge(
                        vertexMap[info.EdgeFollowed.GetPartnerVertex(current.Key)],
                        vertexMap[current.Key], info.Distance);
                }
            }


            return newGraph;
        }

        /// <summary>
        /// Builds the graph for Dijkstra's algorithm with the edges followed.
        /// </summary>
        /// <param name="weightedGraph">The weighted graph.</param>
        /// <param name="fromVertex">The from vertex.</param>
        /// <param name="vertexStatus">The vertex status.</param>
        /// <returns>The graph for Dijkstra's algorithm with the edges followed.</returns>
        private static Graph<T> BuildGraphDijkstra<T>(Graph<T> weightedGraph, Vertex<T> fromVertex, ICollection<KeyValuePair<Vertex<T>, VertexInfo<T>>> vertexStatus)
        {
            // Now build the new graph
            var newGraph = new Graph<T>(weightedGraph.IsDirected);
            
            // This dictionary is used for mapping between the old vertices and the new vertices put into the graph
            var vertexMap = new Dictionary<Vertex<T>, Vertex<T>>(vertexStatus.Count);

            foreach (var current in vertexStatus)
            {
                var newVertex = new Vertex<T>(
                    current.Key.Data,
                    current.Value.Distance
                );

                vertexMap.Add(current.Key, newVertex);

                newGraph.AddVertex(newVertex);
            }
            

            foreach (var current in vertexStatus) {
                var info = current.Value;

                // Check if an edge has been included to this vertex
                if ((info.EdgeFollowed != null) && (current.Key != fromVertex))
                {
                    newGraph.AddEdge(
                        vertexMap[info.EdgeFollowed.GetPartnerVertex(current.Key)],
                        vertexMap[current.Key],
                        info.EdgeFollowed.Weight);
                }
            }

            return newGraph;
        }

        #endregion
    }
}
