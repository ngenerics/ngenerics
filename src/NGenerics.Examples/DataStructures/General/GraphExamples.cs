/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/




using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Examples.DataStructures.General
{
    [TestFixture]
    public class GraphExamples
    {

        #region Accept
        [Test]
        public void AcceptExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            // Create a counting visitor.  The counting
            // visitor will keep track of the number of
            // items on which Accept was called.
            var visitor = new CountingVisitor<int>();

            // Let the visitor in the door
            graph.AcceptVisitor(visitor);

            // The visitor will have visited three vertices.
            Assert.AreEqual(visitor.Count, 3);
        }
        #endregion

        #region AddEdge
        [Test]
        public void AddEdgeExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add two vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);

            // Create an edge between the two vertices
            var edge = new Edge<int>(vertex1, vertex2, true);

            // Add the edge to the graph
            graph.AddEdge(edge);

            // The edge will be accessible though the edges collection
            Assert.AreEqual(graph.Edges.Count, 1);
        }
        #endregion

        #region AddEdgeFromVertices
        [Test]
        public void AddEdgeFromVerticesExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add two vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);

            // Add the edge to the graph
            var edge = graph.AddEdge(vertex1, vertex2);

            // The from vertex will be vertex1
            Assert.AreEqual(edge.FromVertex, vertex1);

            // The to vertex will be vertex2
            Assert.AreEqual(edge.ToVertex, vertex2);

            // Since the graph is directed, the edge will
            // be directed as well
            Assert.AreEqual(edge.IsDirected, true);

            // The edge will be accessible though the edges collection
            Assert.AreEqual(graph.Edges.Count, 1);
        }
        #endregion

        #region AddWeightedEdgeFromVertices
        [Test]
        public void AddWeightedEdgeFromVerticesExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add two vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);

            // Add the edge to the graph, with a weight of 34.5
            var edge = graph.AddEdge(vertex1, vertex2, 34.5);

            // The from vertex will be vertex1
            Assert.AreEqual(edge.FromVertex, vertex1);

            // The to vertex will be vertex2
            Assert.AreEqual(edge.ToVertex, vertex2);

            // Since the graph is directed, the edge will
            // be directed as well
            Assert.AreEqual(edge.IsDirected, true);

            // The edge will be accessible though the edges collection
            Assert.AreEqual(graph.Edges.Count, 1);

            // And finally, the weight of the edge will be 34.5
            Assert.AreEqual(edge.Weight, 34.5);
        }
        #endregion

        #region AddVertex
        [Test]
        public void AddVertexExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Create a new vertex
            var vertex1 = new Vertex<int>(5);

            // Add a vertex to the graph
            graph.AddVertex(vertex1);

            // The vertex will be accessible though the
            // vertices collection
            Assert.AreEqual(graph.Vertices.Count, 1);
        }
        #endregion

        #region AddVertexFromValue
        [Test]
        public void AddVertexFromValueExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add a vertex to the graph with the value 5
            var vertex1 = graph.AddVertex(5);

            // The vertex will be accessible though the
            // vertices collection
            Assert.AreEqual(graph.Vertices.Count, 1);

            // And the vertex's value will be 5
            Assert.AreEqual(vertex1.Data, 5);
        }
        #endregion

        #region BreadthFirstTraversal
        [Test]
        public void BreadthFirstTraversalExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex1, vertex3);

            // Create a counting visitor.  The counting
            // visitor will keep track of the number of
            // items on which Accept was called.
            var visitor = new CountingVisitor<Vertex<int>>();

            // Perform a breadth first traversal of the graph,
            // starting at vertex vertex1.
            graph.BreadthFirstTraversal(visitor, vertex1);

            // The visitor will have visited three vertices.
            Assert.AreEqual(visitor.Count, 3);
        }
        #endregion

        #region Clear
        [Test]
        public void ClearExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);

            // There will be 2 edges and 3 vertices in the graph
            Assert.AreEqual(graph.Edges.Count, 2);
            Assert.AreEqual(graph.Vertices.Count, 3);

            // Clear the graph - thereby removing all vertices
            // and edges in the graph.
            graph.Clear();

            // The graph will be empty
            Assert.AreEqual(graph.Edges.Count, 0);
            Assert.AreEqual(graph.Vertices.Count, 0);
        }
        #endregion

        #region Constructor
        [Test]
        public void ConstructorExample()
        {
            // Create a new directed graph
            var graph = new Graph<int>(true);

            // Initially, the graph will be empty
            Assert.IsTrue(graph.IsEmpty);

            // To create an undirected graph, specify it in the constructor :
            graph = new Graph<int>(false);

            // Initially, the graph will be empty
            Assert.IsTrue(graph.IsEmpty);
        }

        #endregion

        #region ContainsEdge
        [Test]
        public void ContainsEdgeExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices
            var edge1 = graph.AddEdge(vertex1, vertex2);
            var edge2 = graph.AddEdge(vertex2, vertex3);

            // Add another edge that's not part of the graph
            var edge3 = new Edge<int>(vertex1, vertex3, true);

            // edge1 and edge2 is contained in the graph
            Assert.IsTrue(graph.ContainsEdge(edge1));
            Assert.IsTrue(graph.ContainsEdge(edge2));

            // edge3 is not
            Assert.IsFalse(graph.ContainsEdge(edge3));
        }
        #endregion

        #region ContainsEdgeFromVertices
        [Test]
        public void ContainsEdgeFromVerticesExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);

            // There will be edges between vertex1 and vertex2, and vertex2 and vertex3
            Assert.IsTrue(graph.ContainsEdge(vertex1, vertex2));
            Assert.IsTrue(graph.ContainsEdge(vertex2, vertex3));

            // But not between vertex1 and vertex3
            Assert.IsFalse(graph.ContainsEdge(vertex1, vertex3));
        }
        #endregion

        #region ContainsEdgeFromVerticeValues
        [Test]
        public void ContainsEdgeFromVerticeValuesExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);

            // There will be edges between vertex1 and vertex2, and vertex2 and vertex3
            Assert.IsTrue(graph.ContainsEdge(1, 2));
            Assert.IsTrue(graph.ContainsEdge(2, 3));

            // But not between vertex1 and vertex3
            Assert.IsFalse(graph.ContainsEdge(1, 3));
        }
        #endregion

        #region ContainsVertex
        [Test]
        public void ContainsVertexExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add two vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);

            // Create a vertex that doesn't form part of the graph
            var vertex3 = new Vertex<int>(3);

            // The graph will contain vertices vertex1 and vertex2
            Assert.IsTrue(graph.ContainsVertex(vertex1));
            Assert.IsTrue(graph.ContainsVertex(vertex2));

            // But not vertex vertex3
            Assert.IsFalse(graph.ContainsVertex(vertex3));
        }
        #endregion

        #region ContainsVertexValue
        [Test]
        public void ContainsVertexValueExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add two vertices to the graph
            graph.AddVertex(1);
            graph.AddVertex(2);

            // The graph will contain vertex values 1 and 2
            Assert.IsTrue(graph.ContainsVertex(1));
            Assert.IsTrue(graph.ContainsVertex(2));

            // But not vertex value 3
            Assert.IsFalse(graph.ContainsVertex(3));
        }
        #endregion

        #region CopyTo
        [Test]
        public void CopyToExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            // Create the array to store the vertex values in
            var values = new int[3];

            // Use the copy to command to copy the vertex
            // values to a user provided array, from index 0
            graph.CopyTo(values, 0);

            // If all the values are summed up, the total would
            // come to 1 + 2+ 3 = 6.
            var sum = 0;

            for (var i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }

            Assert.AreEqual(sum, 6);
        }
        #endregion

        #region DepthFirstTraversal
        [Test]
        public void DepthFirstTraversalExample()
        {
            // Initialize a new graph instance.
            var graph = new Graph<int>(true);

            // Add three vertices to the graph.
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices.
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);

            // Create a new counting visitor, which will keep track
            // of the number of objects that are visited.
            var countingVisitor = new CountingVisitor<Vertex<int>>();

            // Define in which order the objects should be visited - 
            // we choose to do a pre-order traversal, however, you can
            // also choose to visit post-order.  Note that In-Order is
            // only available on Binary Trees, and not defined on graphs.
            var orderedVisitor = new PreOrderVisitor<Vertex<int>>(countingVisitor);

            // Perform a depth first traversal on the graph with
            // the ordered visitor, starting from node vertex1.
            graph.DepthFirstTraversal(orderedVisitor, vertex1);

            // The visitor will have visited 3 items.
            Assert.AreEqual(countingVisitor.Count, 3);
        }
        #endregion

        #region Edges
        [Test]
        public void EdgesExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex1, vertex3);

            // Retrieve the edges collection from the graph
            var edges = graph.Edges;

            // There will be three edges in the collection
            Assert.AreEqual(edges.Count, 3);
        }
        #endregion

        #region FindVertices
        [Test]
        public void FindVerticesExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            graph.AddVertex(1);
            graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);


            // Find vertices with value 3
            var vertexList =
                graph.FindVertices(value => value == 3);

            // Only one vertex was found
            Assert.AreEqual(vertexList.Count, 1);

            // And that vertex was vertex3
            Assert.AreSame(vertexList[0], vertex3);
        }
        #endregion

        #region GetEdge
        [Test]
        public void GetEdgeExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices
            var edge1 = graph.AddEdge(vertex1, vertex2);
            var edge2 = graph.AddEdge(vertex2, vertex3);

            // A GetEdge operation on vertex1 and vertex2 will return edge edge1
            Assert.AreSame(graph.GetEdge(vertex1, vertex2), edge1);

            // A GetEdge operation on vertex2 and vertex3 will return edge2
            Assert.AreSame(graph.GetEdge(vertex2, vertex3), edge2);

            // A GetEdge operation on vertex1 and vertex3 will return null -
            // no such edge exists in the graph.
            Assert.IsNull(graph.GetEdge(vertex1, vertex3));
        }
        #endregion

        #region GetEdgeFromVertexValue
        [Test]
        public void GetEdgeFromVertexValueExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices
            var edge1 = graph.AddEdge(vertex1, vertex2);
            var edge2 = graph.AddEdge(vertex2, vertex3);

            // A GetEdge operation with values 1 and 2 will return edge edge1
            Assert.AreSame(graph.GetEdge(1, 2), edge1);

            // A GetEdge operation with values 2 and 3 will return edge2
            Assert.AreSame(graph.GetEdge(2, 3), edge2);

            // A GetEdge operation with values 1 and 3 will return null -
            // no such edge exists in the graph.
            Assert.IsNull(graph.GetEdge(1, 3));
        }
        #endregion

        #region GetEnumerator
        [Test]
        public void GetEnumeratorExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            // Add edges between the vertices
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);

            // Get an enumerator to enumerate though all
            // the vertices contained in the graph, and
            // print the contents to the standard output
            using (var enumerator = graph.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    System.Console.WriteLine(enumerator.Current);
                }
            }
        }
        #endregion

        #region GetVertex
        [Test]
        public void GetVertexExample()
        {
            // Initialize a new graph instance
            var graph = new Graph<int>(true);

            // Add three vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);

            // Retrieving a vertex with value 1 will produce vertex vertex1
            Assert.AreEqual(graph.GetVertex(1), vertex1);

            // Retrieving a vertex with value 2 will produce vertex vertex2
            Assert.AreEqual(graph.GetVertex(2), vertex2);

            // Retrieving a vertex with a value not present in the graph
            // will produce a null result.
            Assert.IsNull(graph.GetVertex(3));
        }
        #endregion

        #region IsCyclic

        [Test]
        public void IsCyclicExample()
        {
            // Create a new directed graph
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            // Add some edges
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex2, vertex4);
            graph.AddEdge(vertex3, vertex4);

            // The graph does not contain a cycle
            Assert.IsFalse(graph.IsCyclic());

            // Add a cycle to the graph, by adding an edge from vertex4 to vertex1
            graph.AddEdge(vertex4, vertex1);

            // Now the graph contains a cycle
            Assert.IsTrue(graph.IsCyclic());
        }

        #endregion

        #region IsDirected
        [Test]
        public void IsDirectedExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(true);

            // The graph will be directed
            Assert.IsTrue(graph.IsDirected);

            // Create a new undirected graph
            graph = new Graph<int>(false);

            // The graph will be undirected
            Assert.IsFalse(graph.IsDirected);
        }
        #endregion

        #region IsEmpty
        [Test]
        public void IsEmptyExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(true);

            // The graph will be empty
            Assert.IsTrue(graph.IsEmpty);

            // Add a vertex to the graph
            graph.AddVertex(3);

            // The graph will have one vertex in it (non-empty)
            Assert.IsFalse(graph.IsEmpty);

            // Clear the graph, thereby making it empty again
            graph.Clear();
            Assert.IsTrue(graph.IsEmpty);
        }
        #endregion

 

      

        #region IsReadOnly
        [Test]
        public void IsReadOnlyExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(true);

            // IsReadOnly will always false on a graph
            Assert.IsFalse(graph.IsReadOnly);
        }
        #endregion

        #region IsStronglyConnected
        [Test]
        public void IsStronglyConnectedExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(false);

            // Add 4 vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            // Add edges to the vertices
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            // The graph will not be strongly connected, since
            // vertex vertex4 is not reachable from every other vertex
            Assert.IsFalse(graph.IsStronglyConnected());

            // Add an edge from vertex vertex2 to vertex vertex4
            graph.AddEdge(vertex2, vertex4);

            // Now the graph is strongly connected
            Assert.IsTrue(graph.IsStronglyConnected());
        }
        #endregion

        #region IsWeaklyConnected
        [Test]
        public void IsWeaklyConnectedExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(true);

            // Add 4 vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            // Add edges to the vertices
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            // The graph will not be strongly connected, since
            // vertex vertex4 is not reachable from every other vertex
            Assert.IsFalse(graph.IsWeaklyConnected());

            // Add an edge from vertex vertex2 to vertex vertex4
            graph.AddEdge(vertex2, vertex4);

            // Now the graph is strongly connected
            Assert.IsTrue(graph.IsWeaklyConnected());
        }
        #endregion

        #region RemoveEdge
        [Test]
        public void RemoveEdgeExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(true);

            // Add 4 vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            // Add edges to the vertices
            var edge1 = graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            // Create an edge not present in the graph
            var edge4 = new Edge<int>(vertex2, vertex4, true);

            // The graph contains 3 edges
            Assert.AreEqual(graph.Edges.Count, 3);

            // Remove edge edge1 from the graph
            var success = graph.RemoveEdge(edge1);

            // Successfully removed it!
            Assert.IsTrue(success);

            // The graph contains 2 edges
            Assert.AreEqual(graph.Edges.Count, 2);

            // Trying to remove an edge not present in
            // the graph will return the value false
            Assert.IsFalse(graph.RemoveEdge(edge4));
        }
        #endregion

        #region RemoveEdgeFromVertices
        [Test]
        public void RemoveEdgeFromVerticesExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(true);

            // Add 4 vertices to the graph
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            // Add edges to the vertices
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            // The graph contains 3 edges
            Assert.AreEqual(graph.Edges.Count, 3);

            // Remove the edge between vertex1 and vertex2 from the graph
            var success = graph.RemoveEdge(vertex1, vertex2);

            // Successfully removed it!
            Assert.IsTrue(success);

            // The graph contains 2 edges
            Assert.AreEqual(graph.Edges.Count, 2);

            // Trying to remove an edge not present in the
            // graph will return the value false
            Assert.IsFalse(graph.RemoveEdge(vertex2, vertex4));
        }
        #endregion

        #region RemoveVertex
        [Test]
        public void RemoveVertexExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(true);

            // Add 2 vertices to the graph
            var vertex1 = graph.AddVertex(1);
            graph.AddVertex(2);

            // The graph contains 2 vertices
            Assert.AreEqual(graph.Vertices.Count, 2);

            // Remove vertex vertex1
            var removeResult = graph.RemoveVertex(vertex1);

            // The vertex was found in the graph
            Assert.IsTrue(removeResult);

            // The graph now contains only one vertex
            Assert.AreEqual(graph.Vertices.Count, 1);
        }
        #endregion

        #region RemoveVertexFromValue
        [Test]
        public void RemoveVertexFromValueExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(true);

            // Add 2 vertices to the graph
            graph.AddVertex(1);
            graph.AddVertex(2);

            // The graph contains 2 vertices
            Assert.AreEqual(graph.Vertices.Count, 2);

            // Remove vertex vertex1
            var removeResult = graph.RemoveVertex(1);

            // The vertex was found in the graph
            Assert.IsTrue(removeResult);

            // The graph now contains only one vertex
            Assert.AreEqual(graph.Vertices.Count, 1);
        }
        #endregion

        #region TopologicalSort

        [Test]
        public void TopologicalSortExample()
        {
            // Create a new directed graph
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            // Add some edges
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex2, vertex4);
            graph.AddEdge(vertex3, vertex4);

            // Retrieve the vertices from the graph in topological order
            var vertices = graph.TopologicalSort();

            // There will be 4 items in the list
            Assert.AreEqual(vertices.Count, 4);

            // And the topological order of the sample graph is vertex1, vertex2, vertex3, and vertex4.
            Assert.AreSame(vertices[0], vertex1);
            Assert.AreSame(vertices[1], vertex2);
            Assert.AreSame(vertices[2], vertex3);
            Assert.AreSame(vertices[3], vertex4);
        }

        #endregion

        #region TopologicalSortTraversal

        [Test]
        public void TopologicalSortTraversalExample()
        {
            // Create a new directed graph
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            // Add some edges
            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex2, vertex4);
            graph.AddEdge(vertex3, vertex4);

            // Create a new tracking visitor to keep track of the vertices visited.
            var trackingVisitor = new TrackingVisitor<Vertex<int>>();

            // Visit each vertex in the graph in topological order.
            graph.TopologicalSortTraversal(trackingVisitor);

            // Retrieve the tracking list from the visitor
            var vertices = trackingVisitor.TrackingList;

            // There will be 4 items in the list
            Assert.AreEqual(vertices.Count, 4);

            // And the topological order of the sample graph is vertex1, vertex2, vertex3, and vertex4.
            Assert.AreSame(vertices[0], vertex1);
            Assert.AreSame(vertices[1], vertex2);
            Assert.AreSame(vertices[2], vertex3);
            Assert.AreSame(vertices[3], vertex4);
        }

        #endregion

        #region Vertices
        [Test]
        public void VerticesExample()
        {
            // Initialize a new directed graph instance
            var graph = new Graph<int>(true);

            // Add 2 vertices to the graph
            graph.AddVertex(1);
            graph.AddVertex(2);

            // The vertices collection can be access through
            // the Vertices property
            var vertices = graph.Vertices;

            // The graph contains 2 vertices
            Assert.AreEqual(vertices.Count, 2);
        }
        #endregion
    }
}