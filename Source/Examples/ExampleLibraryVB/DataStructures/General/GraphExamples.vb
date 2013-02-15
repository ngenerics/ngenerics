'  
' Copyright 2007-2013 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports System.Collections.Generic
Imports NGenerics.DataStructures.General
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Public Class GraphExamples

#Region "Accept"
  <Test()> _
  Public Sub AcceptExample()
    ' Initialize a new graph instance_\
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    graph.AddVertex(1)
    graph.AddVertex(2)
    graph.AddVertex(3)

    ' Create a counting visitor.  The counting
    ' visitor will keep track of the number of
    ' items on which Accept was called.
    Dim visitor As New CountingVisitor(Of Integer)()

    ' Let the visitor in the door
    graph.AcceptVisitor(visitor)

    ' The visitor will have visited three vertices.
    Assert.AreEqual(visitor.Count, 3)
  End Sub
#End Region

#Region "AddEdge"
  <Test()> _
  Public Sub AddEdgeExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add two vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)

    ' Create an edge between the two vertices
    Dim edge As New Edge(Of Integer)(vertex1, vertex2, True)

    ' Add the edge to the graph
    graph.AddEdge(edge)

    ' The edge will be accessible though the edges collection
    Assert.AreEqual(graph.Edges.Count, 1)
  End Sub
#End Region

#Region "AddEdgeFromVertices"
  <Test()> _
  Public Sub AddEdgeFromVerticesExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add two vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)

    ' Add the edge to the graph
    Dim edge As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2)

    ' The from vertex will be vertex1
    Assert.AreEqual(edge.FromVertex, vertex1)

    ' The to vertex will be vertex2
    Assert.AreEqual(edge.ToVertex, vertex2)

    ' Since the graph is directed, the edge will
    ' be directed as well
    Assert.AreEqual(edge.IsDirected, True)

    ' The edge will be accessible though the edges collection
    Assert.AreEqual(graph.Edges.Count, 1)
  End Sub
#End Region

#Region "AddWeightedEdgeFromVertices"
  <Test()> _
  Public Sub AddWeightedEdgeFromVerticesExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add two vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)

    ' Add the edge to the graph, with a weight of 34.5
    Dim edge As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2, 34.5)

    ' The from vertex will be vertex1
    Assert.AreEqual(edge.FromVertex, vertex1)

    ' The to vertex will be vertex2
    Assert.AreEqual(edge.ToVertex, vertex2)

    ' Since the graph is directed, the edge will
    ' be directed as well
    Assert.AreEqual(edge.IsDirected, True)

    ' The edge will be accessible though the edges collection
    Assert.AreEqual(graph.Edges.Count, 1)

    ' And finally, the weight of the edge will be 34.5
    Assert.AreEqual(edge.Weight, 34.5)
  End Sub
#End Region

#Region "AddVertex"
  <Test()> _
  Public Sub AddVertexExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Create a new vertex
    Dim vertex As New Vertex(Of Integer)(5)

    ' Add a vertex to the graph
    graph.AddVertex(vertex)

    ' The vertex will be accessible though the
    ' vertices collection
    Assert.AreEqual(graph.Vertices.Count, 1)
  End Sub
#End Region

#Region "AddVertexFromValue"
  <Test()> _
  Public Sub AddVertexFromValueExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add a vertex to the graph with the value 5
    Dim vertex As Vertex(Of Integer) = graph.AddVertex(5)

    ' The vertex will be accessible though the
    ' vertices collection
    Assert.AreEqual(graph.Vertices.Count, 1)

    ' And the vertex's value will be 5
    Assert.AreEqual(vertex.Data, 5)
  End Sub
#End Region

#Region "BreadthFirstTraversal"
  <Test()> _
  Public Sub BreadthFirstTraversalExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)
    graph.AddEdge(vertex1, vertex3)

    ' Create a counting visitor.  The counting
    ' visitor will keep track of the number of
    ' items on which Accept was called.
    Dim visitor As New CountingVisitor(Of Vertex(Of Integer))()

    ' Perform a breadth first traversal of the graph,
    ' starting at vertex vertex1.
    graph.BreadthFirstTraversal(visitor, vertex1)

    ' The visitor will have visited three vertices.
    Assert.AreEqual(visitor.Count, 3)
  End Sub
#End Region

#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)

    ' There will be 2 edges and 3 vertices in the graph
    Assert.AreEqual(graph.Edges.Count, 2)
    Assert.AreEqual(graph.Vertices.Count, 3)

    ' Clear the graph - thereby removing all vertices
    ' and edges in the graph.
    graph.Clear()

    ' The graph will be empty
    Assert.AreEqual(graph.Edges.Count, 0)
    Assert.AreEqual(graph.Vertices.Count, 0)
  End Sub
#End Region

#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    ' Create a new directed graph
    Dim graph As New Graph(Of Integer)(True)

    ' Initially, the graph will be empty
    Assert.IsTrue(graph.IsEmpty)

    ' To create an undirected graph, specify it in the constructor :
    graph = New Graph(Of Integer)(False)

    ' Initially, the graph will be empty
    Assert.IsTrue(graph.IsEmpty)
  End Sub

#End Region

#Region "ContainsEdge"
  <Test()> _
  Public Sub ContainsEdgeExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices
    Dim edge1 As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2)
    Dim edge2 As Edge(Of Integer) = graph.AddEdge(vertex2, vertex3)

    ' Add another edge that's not part of the graph
    Dim edge3 As New Edge(Of Integer)(vertex1, vertex3, True)

    ' edge1 and edge2 is contained in the graph
    Assert.IsTrue(graph.ContainsEdge(edge1))
    Assert.IsTrue(graph.ContainsEdge(edge2))

    ' edge3 is not
    Assert.IsFalse(graph.ContainsEdge(edge3))
  End Sub
#End Region

#Region "ContainsEdgeFromVertices"
  <Test()> _
  Public Sub ContainsEdgeFromVerticesExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)

    ' There will be edges between vertex1 and vertex2, and vertex2 and vertex3
    Assert.IsTrue(graph.ContainsEdge(vertex1, vertex2))
    Assert.IsTrue(graph.ContainsEdge(vertex2, vertex3))

    ' But not between vertex1 and vertex3
    Assert.IsFalse(graph.ContainsEdge(vertex1, vertex3))
  End Sub
#End Region

#Region "ContainsEdgeFromVerticeValues"
  <Test()> _
  Public Sub ContainsEdgeFromVerticeValuesExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)

    ' There will be edges between vertex1 and vertex2, and vertex2 and vertex3
    Assert.IsTrue(graph.ContainsEdge(1, 2))
    Assert.IsTrue(graph.ContainsEdge(2, 3))

    ' But not between vertex1 and vertex3
    Assert.IsFalse(graph.ContainsEdge(1, 3))
  End Sub
#End Region

#Region "ContainsVertex"
  <Test()> _
  Public Sub ContainsVertexExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add two vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)

    ' Create a vertex that doesn't form part of the graph
    Dim vertex3 As New Vertex(Of Integer)(3)

    ' The graph will contain vertices vertex1 and vertex2
    Assert.IsTrue(graph.ContainsVertex(vertex1))
    Assert.IsTrue(graph.ContainsVertex(vertex2))

    ' But not vertex vertex3
    Assert.IsFalse(graph.ContainsVertex(vertex3))
  End Sub
#End Region

#Region "ContainsVertexValue"
  <Test()> _
  Public Sub ContainsVertexValueExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add two vertices to the graph
    graph.AddVertex(1)
    graph.AddVertex(2)

    ' The graph will contain vertex values 1 and 2
    Assert.IsTrue(graph.ContainsVertex(1))
    Assert.IsTrue(graph.ContainsVertex(2))

    ' But not vertex value 3
    Assert.IsFalse(graph.ContainsVertex(3))
  End Sub
#End Region

#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    graph.AddVertex(1)
    graph.AddVertex(2)
    graph.AddVertex(3)

    ' Create the array to store the vertex values in
    Dim values As Integer() = New Integer(2) {}

    ' Use the copy to command to copy the vertex
    ' values to a user provided array, from index 0
    graph.CopyTo(values, 0)

    ' If all the values are summed up, the total would
    ' come to 1 + 2+ 3 = 6.
    Dim sum As Integer = 0
    For i As Integer = 0 To values.Length - 1
      sum += values(i)
    Next

    Assert.AreEqual(sum, 6)
  End Sub
#End Region

#Region "DepthFirstTraversal"
  <Test()> _
  Public Sub DepthFirstTraversalExample()
    ' Initialize a new graph instance.
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph.
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices.
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)

    ' Create a new counting visitor, which will keep track
    ' of the number of objects that are visited.
    Dim visitor As New CountingVisitor(Of Vertex(Of Integer))()

    ' Define in which order the objects should be visited - 
    ' we choose to do a pre-order traversal, however, you can
    ' also choose to visit post-order.  Note that In-Order is
    ' only available on Binary Trees, and not defined on graphs.
    Dim orderedVisitor As New PreOrderVisitor(Of Vertex(Of Integer))(visitor)

    ' Perform a depth first traversal on the graph with
    ' the ordered visitor, starting from node vertex1.
    graph.DepthFirstTraversal(orderedVisitor, vertex1)

    ' The visitor will have visited 3 items.
    Assert.AreEqual(visitor.Count, 3)
  End Sub
#End Region

#Region "Edges"
  <Test()> _
  Public Sub EdgesExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)
    graph.AddEdge(vertex1, vertex3)

    ' Retrieve the edges collection from the graph
    Dim edges As ICollection(Of Edge(Of Integer)) = graph.Edges

    ' There will be three edges in the collection
    Assert.AreEqual(edges.Count, 3)
  End Sub
#End Region

#Region "FindVertices"
  <Test()> _
  Public Sub FindVerticesExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    graph.AddVertex(1)
    graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)


    ' Find vertices with value 3
    Dim vertices As IList(Of Vertex(Of Integer)) = graph.FindVertices(AddressOf FindVerticeWithValue3)

    ' Only one vertex was found
    Assert.AreEqual(vertices.Count, 1)

    ' And that vertex was vertex3
    Assert.AreSame(vertices(0), vertex3)
  End Sub

  Public Function FindVerticeWithValue3(ByVal value As Integer) As Boolean
    Return value = 3
  End Function
#End Region

#Region "GetEdge"
  <Test()> _
  Public Sub GetEdgeExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices
    Dim edge1 As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2)
    Dim edge2 As Edge(Of Integer) = graph.AddEdge(vertex2, vertex3)

    ' A GetEdge operation on vertex1 and vertex2 will return edge edge1
    Assert.AreSame(graph.GetEdge(vertex1, vertex2), edge1)

    ' A GetEdge operation on vertex2 and vertex3 will return edge edge2
    Assert.AreSame(graph.GetEdge(vertex2, vertex3), edge2)

    ' A GetEdge operation on vertex1 and vertex3 will return null -
    ' no such edge exists in the graph.
    Assert.IsNull(graph.GetEdge(vertex1, vertex3))
  End Sub
#End Region

#Region "GetEdgeFromVertexValue"
  <Test()> _
  Public Sub GetEdgeFromVertexValueExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices
    Dim edge1 As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2)
    Dim edge2 As Edge(Of Integer) = graph.AddEdge(vertex2, vertex3)

    ' A GetEdge operation with values 1 and 2 will return edge edge1
    Assert.AreSame(graph.GetEdge(1, 2), edge1)

    ' A GetEdge operation with values 2 and 3 will return edge edge2
    Assert.AreSame(graph.GetEdge(2, 3), edge2)

    ' A GetEdge operation with values 1 and 3 will return null -
    ' no such edge exists in the graph.
    Assert.IsNull(graph.GetEdge(1, 3))
  End Sub
#End Region

#Region "GetEnumerator"
  <Test()> _
  Public Sub GetEnumeratorExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add edges between the vertices
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)

    ' Get an enumerator to enumerate though all
    ' the vertices contained in the graph, and
    ' print the contents to the standard output
    Using enumerator As IEnumerator(Of Integer) = graph.GetEnumerator()
      While enumerator.MoveNext()
        System.Console.WriteLine(enumerator.Current)
      End While
    End Using
  End Sub
#End Region

#Region "GetVertex"
  <Test()> _
  Public Sub GetVertexExample()
    ' Initialize a new graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add three vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)

    ' Retrieving a vertex with value 1 will produce vertex vertex1
    Assert.AreEqual(graph.GetVertex(1), vertex1)

    ' Retrieving a vertex with value 2 will produce vertex vertex2
    Assert.AreEqual(graph.GetVertex(2), vertex2)

    ' Retrieving a vertex with a value not present in the graph
    ' will produce a null result.
    Assert.IsNull(graph.GetVertex(3))
  End Sub
#End Region

#Region "IsCyclic"

  <Test()> _
  Public Sub IsCyclicExample()
    ' Create a new directed graph
    Dim graph As New Graph(Of Integer)(True)
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)
    Dim vertex4 As Vertex(Of Integer) = graph.AddVertex(4)

    ' Add some edges
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)
    graph.AddEdge(vertex2, vertex4)
    graph.AddEdge(vertex3, vertex4)

    ' The graph does not contain a cycle
    Assert.IsFalse(graph.IsCyclic())

    ' Add a cycle to the graph, by adding an edge from vertex4 to vertex1
    graph.AddEdge(vertex4, vertex1)

    ' Now the graph contains a cycle
    Assert.IsTrue(graph.IsCyclic())
  End Sub

#End Region

#Region "IsDirected"
  <Test()> _
  Public Sub IsDirectedExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' The graph will be directed
    Assert.IsTrue(graph.IsDirected)

    ' Create a new undirected graph
    graph = New Graph(Of Integer)(False)

    ' The graph will be undirected
    Assert.IsFalse(graph.IsDirected)
  End Sub
#End Region

#Region "IsEmpty"
  <Test()> _
  Public Sub IsEmptyExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' The graph will be empty
    Assert.IsTrue(graph.IsEmpty)

    ' Add a vertex to the graph
    graph.AddVertex(3)

    ' The graph will have one vertex in it (non-empty)
    Assert.IsFalse(graph.IsEmpty)

    ' Clear the graph, thereby making it empty again
    graph.Clear()
    Assert.IsTrue(graph.IsEmpty)
  End Sub
#End Region


#Region "IsReadOnly"
  <Test()> _
  Public Sub IsReadOnlyExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' IsReadOnly will always false on a graph
    Assert.IsFalse(graph.IsReadOnly)
  End Sub
#End Region

#Region "IsStronglyConnected"
  <Test()> _
  Public Sub IsStronglyConnectedExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(False)

    ' Add 4 vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)
    Dim vertex4 As Vertex(Of Integer) = graph.AddVertex(4)

    ' Add edges to the vertices
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex3, vertex2)
    graph.AddEdge(vertex1, vertex3)

    ' The graph will not be strongly connected, since
    ' vertex vertex4 is not reachable from every other vertex
    Assert.IsFalse(graph.IsStronglyConnected)

    ' Add an edge from vertex vertex2 to vertex vertex4
    graph.AddEdge(vertex2, vertex4)

    ' Now the graph is strongly connected
    Assert.IsTrue(graph.IsStronglyConnected)
  End Sub
#End Region

#Region "IsWeaklyConnected"
  <Test()> _
  Public Sub IsWeaklyConnectedExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add 4 vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)
    Dim vertex4 As Vertex(Of Integer) = graph.AddVertex(4)

    ' Add edges to the vertices
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex3, vertex2)
    graph.AddEdge(vertex1, vertex3)

    ' The graph will not be strongly connected, since
    ' vertex vertex4 is not reachable from every other vertex
    Assert.IsFalse(graph.IsWeaklyConnected)

    ' Add an edge from vertex vertex2 to vertex vertex4
    graph.AddEdge(vertex2, vertex4)

    ' Now the graph is strongly connected
    Assert.IsTrue(graph.IsWeaklyConnected)
  End Sub
#End Region

#Region "RemoveEdge"
  <Test()> _
  Public Sub RemoveEdgeExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add 4 vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)
    Dim vertex4 As Vertex(Of Integer) = graph.AddVertex(4)

    ' Add edges to the vertices
    Dim edge1 As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex3, vertex2)
    graph.AddEdge(vertex1, vertex3)

    ' Create an edge not present in the graph
    Dim edge4 As New Edge(Of Integer)(vertex2, vertex4, True)

    ' The graph contains 3 edges
    Assert.AreEqual(graph.Edges.Count, 3)

    ' Remove edge edge1 from the graph
    Dim success As Boolean = graph.RemoveEdge(edge1)

    ' Successfully removed it!
    Assert.IsTrue(success)

    ' The graph contains 2 edges
    Assert.AreEqual(graph.Edges.Count, 2)

    ' Trying to remove an edge not present in
    ' the graph will return the value false
    Assert.IsFalse(graph.RemoveEdge(edge4))
  End Sub
#End Region

#Region "RemoveEdgeFromVertices"
  <Test()> _
  Public Sub RemoveEdgeFromVerticesExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add 4 vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)
    Dim vertex4 As Vertex(Of Integer) = graph.AddVertex(4)

    ' Add edges to the vertices
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex3, vertex2)
    graph.AddEdge(vertex1, vertex3)

    ' The graph contains 3 edges
    Assert.AreEqual(graph.Edges.Count, 3)

    ' Remove the edge between vertex1 and vertex2 from the graph
    Dim success As Boolean = graph.RemoveEdge(vertex1, vertex2)

    ' Successfully removed it!
    Assert.IsTrue(success)

    ' The graph contains 2 edges
    Assert.AreEqual(graph.Edges.Count, 2)

    ' Trying to remove an edge not present in the
    ' graph will return the value false
    Assert.IsFalse(graph.RemoveEdge(vertex2, vertex4))
  End Sub
#End Region

#Region "RemoveVertex"
  <Test()> _
  Public Sub RemoveVertexExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add 2 vertices to the graph
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    graph.AddVertex(2)

    ' The graph contains 2 vertices
    Assert.AreEqual(graph.Vertices.Count, 2)

    ' Remove vertex vertex1
    Dim removeResult As Boolean = graph.RemoveVertex(vertex1)

    ' The vertex was found in the graph
    Assert.IsTrue(removeResult)

    ' The graph now contains only one vertex
    Assert.AreEqual(graph.Vertices.Count, 1)
  End Sub
#End Region

#Region "RemoveVertexFromValue"
  <Test()> _
  Public Sub RemoveVertexFromValueExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add 2 vertices to the graph
    graph.AddVertex(1)
    graph.AddVertex(2)

    ' The graph contains 2 vertices
    Assert.AreEqual(graph.Vertices.Count, 2)

    ' Remove vertex vertex1
    Dim removeResult As Boolean = graph.RemoveVertex(1)

    ' The vertex was found in the graph
    Assert.IsTrue(removeResult)

    ' The graph now contains only one vertex
    Assert.AreEqual(graph.Vertices.Count, 1)
  End Sub
#End Region

#Region "TopologicalSort"

  <Test()> _
  Public Sub TopologicalSortExample()
    ' Create a new directed graph
    Dim graph As New Graph(Of Integer)(True)
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)
    Dim vertex4 As Vertex(Of Integer) = graph.AddVertex(4)

    ' Add some edges
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)
    graph.AddEdge(vertex2, vertex4)
    graph.AddEdge(vertex3, vertex4)

    ' Retrieve the vertices from the graph in topological order
    Dim vertexList As IList(Of Vertex(Of Integer)) = graph.TopologicalSort()

    ' There will be 4 items in the list
    Assert.AreEqual(vertexList.Count, 4)

    ' And the topological order of the sample graph is vertex1, vertex2, vertex3, and vertex4.
    Assert.AreSame(vertexList(0), vertex1)
    Assert.AreSame(vertexList(1), vertex2)
    Assert.AreSame(vertexList(2), vertex3)
    Assert.AreSame(vertexList(3), vertex4)
  End Sub

#End Region

#Region "TopologicalSortTraversal"

  <Test()> _
  Public Sub TopologicalSortTraversalExample()
    ' Create a new directed graph
    Dim graph As New Graph(Of Integer)(True)
    Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(1)
    Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(2)
    Dim vertex3 As Vertex(Of Integer) = graph.AddVertex(3)
    Dim vertex4 As Vertex(Of Integer) = graph.AddVertex(4)

    ' Add some edges
    graph.AddEdge(vertex1, vertex2)
    graph.AddEdge(vertex2, vertex3)
    graph.AddEdge(vertex2, vertex4)
    graph.AddEdge(vertex3, vertex4)

    ' Create a new tracking visitor to keep track of the vertices visited.
    Dim visitor As New TrackingVisitor(Of Vertex(Of Integer))()

    ' Visit each vertex in the graph in topological order.
    graph.TopologicalSortTraversal(visitor)

    ' Retrieve the tracking list from the visitor
    Dim vertexList As IList(Of Vertex(Of Integer)) = visitor.TrackingList

    ' There will be 4 items in the list
    Assert.AreEqual(vertexList.Count, 4)

    ' And the topological order of the sample graph is vertex1, vertex2, vertex3, and vertex4.
    Assert.AreSame(vertexList(0), vertex1)
    Assert.AreSame(vertexList(1), vertex2)
    Assert.AreSame(vertexList(2), vertex3)
    Assert.AreSame(vertexList(3), vertex4)
  End Sub

#End Region

#Region "Vertices"
  <Test()> _
  Public Sub VerticesExample()
    ' Initialize a new directed graph instance
    Dim graph As New Graph(Of Integer)(True)

    ' Add 2 vertices to the graph
    graph.AddVertex(1)
    graph.AddVertex(2)

    ' The vertices collection can be access through
    ' the Vertices property
    Dim vertexList As ICollection(Of Vertex(Of Integer)) = graph.Vertices

    ' The graph contains 2 vertices
    Assert.AreEqual(vertexList.Count, 2)
  End Sub
#End Region
End Class
