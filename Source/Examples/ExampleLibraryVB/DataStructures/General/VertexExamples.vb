'  
' Copyright 2007-2010 The NGenerics Team
' (http://code.google.com/p/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports NGenerics.DataStructures.General
Imports NUnit.Framework

<TestFixture()> _
  Public Class VertexExamples

#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    ' Construct a new vertex with value 5
        Dim vertex As New Vertex(Of Integer)(5)

        ' The data property's value will be 5
        Assert.AreEqual(vertex.Data, 5)
  End Sub
#End Region

#Region "ConstructorWithWeight"
  <Test()> _
  Public Sub ConstructorWithWeightExample()
    ' Construct a new vertex with value 5 and
    ' a weight of 3.34
    Dim vertex As New Vertex(Of Integer)(5, 3.32)

    ' The data property's value will be 5
    Assert.AreEqual(vertex.Data, 5)

    ' And the weight 3.34
    Assert.AreEqual(vertex.Weight, 3.32)
  End Sub
#End Region

#Region "Data"
  <Test()> _
  Public Sub DataExample()
    ' Create a new vertex with data item 2
    Dim vertex As New Vertex(Of Integer)(2)

    ' Which you can retrieve from the property
        Assert.AreEqual(vertex.Data, 2)

        ' And also set with the property
        vertex.Data = 3
        Assert.AreEqual(vertex.Data, 3)
  End Sub
#End Region

#Region "Degree"
  <Test()> _
  Public Sub DegreeExample()
    ' Create two new vertices
        Dim vertex1 As New Vertex(Of Integer)(2)
        Dim vertex2 As New Vertex(Of Integer)(4)

    ' The degree of the vertex is the number
    ' of edges emanating from the vertex.  Thus,
    ' a newly created vertex will have a degree
    ' of 0.
        Assert.AreEqual(vertex1.Degree, 0)
        Assert.AreEqual(vertex2.Degree, 0)

    ' Create a graph, and add the vertices to 
    ' the graph
    Dim graph As New Graph(Of Integer)(True)
        graph.AddVertex(vertex1)
        graph.AddVertex(vertex2)

        ' Add an edge from vertex1 to vertex vertex2
        graph.AddEdge(vertex1, vertex2)

        ' Since the edge is emanating from vertex1
        ' (and the graph is directed), vertex1's
        ' degree will be 1 and vertex2's degree 0.
        Assert.AreEqual(vertex1.Degree, 1)
        Assert.AreEqual(vertex2.Degree, 0)
  End Sub
#End Region

#Region "EmanatingEdges"
  <Test()> _
  Public Sub EmanatingEdgesExample()
    ' Create two new vertices
        Dim vertex1 As New Vertex(Of Integer)(2)
        Dim vertex2 As New Vertex(Of Integer)(4)

    ' Create a graph, and add the vertices to 
    ' the graph
    Dim graph As New Graph(Of Integer)(True)
        graph.AddVertex(vertex1)
        graph.AddVertex(vertex2)

        ' Add an edge from vertex1 to vertex vertex2
        graph.AddEdge(vertex1, vertex2)

        ' Since the edge is emanating from vertex1
        ' (and the graph is directed), vertex1's
        ' degree will be 1 and vertex2's degree 0.
        Assert.AreEqual(vertex1.EmanatingEdges.Count, 1)
        Assert.AreEqual(vertex2.EmanatingEdges.Count, 0)
  End Sub
#End Region

#Region "GetEmanatingEdgeTo"
  <Test()> _
  Public Sub GetEmanatingEdgeToExample()
    ' Create two new vertices
        Dim vertex1 As New Vertex(Of Integer)(2)
        Dim vertex2 As New Vertex(Of Integer)(4)

    ' Create a graph, and add the vertices to 
    ' the graph
    Dim graph As New Graph(Of Integer)(True)
        graph.AddVertex(vertex1)
        graph.AddVertex(vertex2)

        ' Add an edge from vertex1 to vertex vertex2
        graph.AddEdge(vertex1, vertex2)

        ' Retrieve the emanating edge from vertex1 to vertex2
        Dim edge As Edge(Of Integer) = vertex1.GetEmanatingEdgeTo(vertex2)

    ' Which will be a valid edge
    Assert.IsNotNull(edge)

        ' Requesting the emanating edge from vertex2 to vertex1
    ' will result in a null being returned - the
        ' edge is directed from vertex1 to vertex2.
        edge = vertex2.GetEmanatingEdgeTo(vertex1)
    Assert.IsNull(edge)
  End Sub
#End Region

#Region "GetIncidentEdgeWith"
  <Test()> _
  Public Sub GetIncidentEdgeWithExample()
    ' Create two new vertices
        Dim vertex1 As New Vertex(Of Integer)(2)
        Dim vertex2 As New Vertex(Of Integer)(4)

    ' Create a graph, and add the vertices to 
    ' the graph
    Dim graph As New Graph(Of Integer)(True)
        graph.AddVertex(vertex1)
        graph.AddVertex(vertex2)

        ' Add an edge from vertex1 to vertex vertex2
        graph.AddEdge(vertex1, vertex2)

        ' Retrieve the incident edge from vertex1 to vertex2
        Dim edge As Edge(Of Integer) = vertex1.GetIncidentEdgeWith(vertex2)

    ' Which will be a valid edge
    Assert.IsNotNull(edge)

    ' Incident edges are edges "touching" the 
    ' vertex, irrespective of direction
        edge = vertex2.GetIncidentEdgeWith(vertex1)

    ' Will also be a valid edge
    Assert.IsNotNull(edge)
  End Sub
#End Region

#Region "HasEmanatingEdgeTo"
  <Test()> _
  Public Sub HasEmanatingEdgeToExample()
    ' Create two new vertices
        Dim vertex1 As New Vertex(Of Integer)(2)
        Dim vertex2 As New Vertex(Of Integer)(4)

    ' Create a graph, and add the vertices to 
    ' the graph
    Dim graph As New Graph(Of Integer)(True)
        graph.AddVertex(vertex1)
        graph.AddVertex(vertex2)

        ' Add an edge from vertex1 to vertex vertex2
        graph.AddEdge(vertex1, vertex2)

        ' vertex1 has an emanating edge to vertex2
        Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex2))

        ' But vertex2 does not have an emanating edge to vertex1
        Assert.IsFalse(vertex2.HasEmanatingEdgeTo(vertex1))
  End Sub
#End Region

#Region "HasIncidentEdgeWith"
  <Test()> _
  Public Sub HasIncidentEdgeWithExample()
    ' Create two new vertices
        Dim vertex1 As New Vertex(Of Integer)(2)
        Dim vertex2 As New Vertex(Of Integer)(4)

    ' Create a graph, and add the vertices to 
    ' the graph
    Dim graph As New Graph(Of Integer)(True)
        graph.AddVertex(vertex1)
        graph.AddVertex(vertex2)

        ' Add an edge from vertex1 to vertex vertex2
        graph.AddEdge(vertex1, vertex2)

        ' The edge will be incident on vertex1, and connected
        ' to vertex vertex2.
        Assert.IsTrue(vertex1.HasIncidentEdgeWith(vertex2))

    ' And also the other way around.
        Assert.IsTrue(vertex2.HasIncidentEdgeWith(vertex1))
  End Sub
#End Region

#Region "IncidentEdges"
  <Test()> _
  Public Sub IncidentEdgesExample()
    ' Create two new vertices
        Dim vertex1 As New Vertex(Of Integer)(2)
        Dim vertex2 As New Vertex(Of Integer)(4)

    ' Create a graph, and add the vertices to 
    ' the graph
    Dim graph As New Graph(Of Integer)(True)
        graph.AddVertex(vertex1)
        graph.AddVertex(vertex2)

        ' Add an edge from vertex1 to vertex vertex2
        graph.AddEdge(vertex1, vertex2)

        ' The edge will be incident on vertex1, and connected
        ' to vertex vertex2.
        Assert.IsTrue(vertex1.HasIncidentEdgeWith(vertex2))

    ' To get the list of incident edges, use the 
    ' IncidentEdges property
        Assert.AreEqual(vertex1.IncidentEdges.Count, 1)

    ' And also the other way around.
        Assert.IsTrue(vertex2.HasIncidentEdgeWith(vertex1))
        Assert.AreEqual(vertex2.IncidentEdges.Count, 1)
  End Sub
#End Region

#Region "Weight"
  <Test()> _
  Public Sub WeightExample()
    ' Construct a new vertex with value 5 and
    ' a weight of 3.34
    Dim vertex As New Vertex(Of Integer)(5, 3.32)

    ' The data property's value will be 5
        Assert.AreEqual(vertex.Data, 5)

        ' And the weight 3.34
        Assert.AreEqual(vertex.Weight, 3.32)
  End Sub
#End Region
End Class
