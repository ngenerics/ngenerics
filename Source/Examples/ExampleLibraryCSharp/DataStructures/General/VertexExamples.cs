/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.General
{
    [TestFixture]
    public class VertexExamples
    {

        #region Constructor
        [Test]
        public void ConstructorExample()
        {
            // Construct a new vertex with value 5
            var vertex = new Vertex<int>(5);

            // The data property's value will be 5
            Assert.AreEqual(vertex.Data, 5);
        }
        #endregion

        #region ConstructorWithWeight
        [Test]
        public void ConstructorWithWeightExample()
        {
            // Construct a new vertex with value 5 and
            // a weight of 3.34
            var vertex = new Vertex<int>(5, 3.32);

            // The data property's value will be 5
            Assert.AreEqual(vertex.Data, 5);

            // And the weight 3.34
            Assert.AreEqual(vertex.Weight, 3.32);
        }
        #endregion

        #region Data
        [Test]
        public void DataExample()
        {
            // Create a new vertex with data item 2
            var vertex = new Vertex<int>(2);

            // Which you can retrieve from the property
            Assert.AreEqual(vertex.Data, 2);

            // And also set with the property
            vertex.Data = 3;
            Assert.AreEqual(vertex.Data, 3);
        }
        #endregion

        #region Degree
        [Test]
        public void DegreeExample()
        {
            // Create two new vertices
            var vertex1 = new Vertex<int>(2);
            var vertex2 = new Vertex<int>(4);

            // The degree of the vertex is the number
            // of edges emanating from the vertex.  Thus,
            // a newly created vertex will have a degree
            // of 0.
            Assert.AreEqual(vertex1.Degree, 0);
            Assert.AreEqual(vertex2.Degree, 0);

            // Create a graph, and add the vertices to 
            // the graph
            var graph = new Graph<int>(true);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);

            // Add an edge from vertex1 to vertex vertex2
            graph.AddEdge(vertex1, vertex2);

            // Since the edge is emanating from vertex1
            // (and the graph is directed), vertex1's
            // degree will be 1 and vertex2's degree 0.
            Assert.AreEqual(vertex1.Degree, 1);
            Assert.AreEqual(vertex2.Degree, 0);
        }
        #endregion

        #region EmanatingEdges
        [Test]
        public void EmanatingEdgesExample()
        {
            // Create two new vertices
            var vertex1 = new Vertex<int>(2);
            var vertex2 = new Vertex<int>(4);

            // Create a graph, and add the vertices to 
            // the graph
            var graph = new Graph<int>(true);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);

            // Add an edge from vertex1 to vertex vertex2
            graph.AddEdge(vertex1, vertex2);

            // Since the edge is emanating from vertex1
            // (and the graph is directed), vertex1's
            // degree will be 1 and vertex2's degree 0.
            Assert.AreEqual(vertex1.EmanatingEdges.Count, 1);
            Assert.AreEqual(vertex2.EmanatingEdges.Count, 0);
        }
        #endregion

        #region GetEmanatingEdgeTo
        [Test]
        public void GetEmanatingEdgeToExample()
        {
            // Create two new vertices
            var vertex1 = new Vertex<int>(2);
            var vertex2 = new Vertex<int>(4);

            // Create a graph, and add the vertices to 
            // the graph
            var graph = new Graph<int>(true);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);

            // Add an edge from vertex1 to vertex vertex2
            graph.AddEdge(vertex1, vertex2);

            // Retrieve the emanating edge from vertex1 to vertex2
            var edge = vertex1.GetEmanatingEdgeTo(vertex2);

            // Which will be a valid edge
            Assert.IsNotNull(edge);

            // Requesting the emanating edge from vertex2 to vertex1
            // will result in a null being returned - the
            // edge is directed from vertex1 to vertex2.
            edge = vertex2.GetEmanatingEdgeTo(vertex1);
            Assert.IsNull(edge);
        }
        #endregion

        #region GetIncidentEdgeWith
        [Test]
        public void GetIncidentEdgeWithExample()
        {
            // Create two new vertices
            var vertex1 = new Vertex<int>(2);
            var vertex2 = new Vertex<int>(4);

            // Create a graph, and add the vertices to 
            // the graph
            var graph = new Graph<int>(true);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);

            // Add an edge from vertex1 to vertex vertex2
            graph.AddEdge(vertex1, vertex2);

            // Retrieve the incident edge from vertex1 to vertex2
            var edge = vertex1.GetIncidentEdgeWith(vertex2);

            // Which will be a valid edge
            Assert.IsNotNull(edge);

            // Incident edges are edges "touching" the 
            // vertex, irrespective of direction
            edge = vertex2.GetIncidentEdgeWith(vertex1);

            // Will also be a valid edge
            Assert.IsNotNull(edge);
        }
        #endregion

        #region HasEmanatingEdgeTo
        [Test]
        public void HasEmanatingEdgeToExample()
        {
            // Create two new vertices
            var vertex1 = new Vertex<int>(2);
            var vertex2 = new Vertex<int>(4);

            // Create a graph, and add the vertices to 
            // the graph
            var graph = new Graph<int>(true);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);

            // Add an edge from vertex1 to vertex vertex2
            graph.AddEdge(vertex1, vertex2);

            // vertex1 has an emanating edge to vertex2
            Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex2));

            // But vertex2 does not have an emanating edge to vertex1
            Assert.IsFalse(vertex2.HasEmanatingEdgeTo(vertex1));
        }
        #endregion

        #region HasIncidentEdgeWith
        [Test]
        public void HasIncidentEdgeWithExample()
        {
            // Create two new vertices
            var vertex1 = new Vertex<int>(2);
            var vertex2 = new Vertex<int>(4);

            // Create a graph, and add the vertices to 
            // the graph
            var graph = new Graph<int>(true);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);

            // Add an edge from vertex1 to vertex vertex2
            graph.AddEdge(vertex1, vertex2);

            // The edge will be incident on vertex1, and connected
            // to vertex vertex2.
            Assert.IsTrue(vertex1.HasIncidentEdgeWith(vertex2));

            // And also the other way around.
            Assert.IsTrue(vertex2.HasIncidentEdgeWith(vertex1));
        }
        #endregion

        #region IncidentEdges
        [Test]
        public void IncidentEdgesExample()
        {
            // Create two new vertices
            var vertex1 = new Vertex<int>(2);
            var vertex2 = new Vertex<int>(4);

            // Create a graph, and add the vertices to 
            // the graph
            var graph = new Graph<int>(true);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);

            // Add an edge from vertex1 to vertex vertex2
            graph.AddEdge(vertex1, vertex2);

            // The edge will be incident on vertex1, and connected
            // to vertex vertex2.
            Assert.IsTrue(vertex1.HasIncidentEdgeWith(vertex2));

            // To get the list of incident edges, use the 
            // IncidentEdges property
            Assert.AreEqual(vertex1.IncidentEdges.Count, 1);

            // And also the other way around.
            Assert.IsTrue(vertex2.HasIncidentEdgeWith(vertex1));
            Assert.AreEqual(vertex2.IncidentEdges.Count, 1);
        }
        #endregion

        #region Weight
        [Test]
        public void WeightExample()
        {
            // Construct a new vertex with value 5 and
            // a weight of 3.34
            var vertex = new Vertex<int>(5, 3.32);

            // The data property's value will be 5
            Assert.AreEqual(vertex.Data, 5);

            // And the weight 3.34
            Assert.AreEqual(vertex.Weight, 3.32);
        }
        #endregion
    }
}