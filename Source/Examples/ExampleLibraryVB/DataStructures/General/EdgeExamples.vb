'  
' Copyright 2007-2013 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports NGenerics.DataStructures.General
Imports NUnit.Framework

<TestFixture()> _
Public Class EdgeExamples

#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    ' Create the graph to add the edge to.
    Dim graph As New Graph(Of Integer)(True)

    ' Create the two vertices that would make 
    ' up the edge
        Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(5)
        Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Create an edge between the two vertices
        Dim edge As New Edge(Of Integer)(vertex1, vertex2, True)

        ' The from vertex would be vertex1
        Assert.AreEqual(edge.FromVertex, vertex1)

        ' The to vertex would be vertex2
        Assert.AreEqual(edge.ToVertex, vertex2)

    ' The weight of the vertex will default to 0.
    Assert.AreEqual(edge.Weight, 0)
  End Sub
#End Region
            

#Region "WeightedConstructor"
  <Test()> _
  Public Sub WeightedConstructorExample()
    ' Create the graph to add the edge to.
    Dim graph As New Graph(Of Integer)(True)

    ' Create the two vertices that would make 
    ' up the edge
        Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(5)
        Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Create an edge between the two vertices with a
    ' weight of 34.5
        Dim edge As New Edge(Of Integer)(vertex1, vertex2, 34.5, True)

        ' The from vertex would be vertex1
        Assert.AreEqual(edge.FromVertex, vertex1)

        ' The to vertex would be vertex2
        Assert.AreEqual(edge.ToVertex, vertex2)

    ' The weight of the vertex will be 34.5.
    Assert.AreEqual(edge.Weight, 34.5)
  End Sub
#End Region

#Region "FromVertex"
  <Test()> _
  Public Sub FromVertexExample()
    ' Create the graph to add the edge to.
    Dim graph As New Graph(Of Integer)(True)

    ' Create the two vertices that would make 
    ' up the edge
        Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(5)
        Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add an edge between the two vertice
        Dim edge As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2)

        ' The from vertex will be vertex1
        Assert.AreSame(edge.FromVertex, vertex1)
  End Sub
#End Region



#Region "ToVertex"
  <Test()> _
  Public Sub ToVertexExample()
    ' Create the graph to add the edge to.
    Dim graph As New Graph(Of Integer)(True)

    ' Create the two vertices that would make 
    ' up the edge
        Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(5)
        Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add an edge between the two vertice
        Dim edge As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2)

        ' The to vertex will be vertex2
        Assert.AreSame(edge.ToVertex, vertex2)
  End Sub

#End Region

#Region "GetPartnerVertex"
  <Test()> _
  Public Sub GetPartnerVertexExample()
    ' Create the graph to add the edge to.
    Dim graph As New Graph(Of Integer)(True)

    ' Create the two vertices that would make 
    ' up the edge
        Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(5)
        Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add an edge between the two vertice
        Dim edge As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2)

        ' The partner of vertex1 will be vertex2
        Assert.AreSame(edge.GetPartnerVertex(vertex1), vertex2)

        ' The partner of vertex2 will be vertex1
        Assert.AreSame(edge.GetPartnerVertex(vertex2), vertex1)
  End Sub
#End Region


#Region "IsDirected"
  <Test()> _
  Public Sub IsDirectedExample()
    ' Create the graph to add the edge to.
    Dim graph As New Graph(Of Integer)(True)

    ' Create the two vertices that would make 
    ' up the edge
        Dim vertex1 As Vertex(Of Integer) = graph.AddVertex(5)
        Dim vertex2 As Vertex(Of Integer) = graph.AddVertex(3)

    ' Add an edge between the two vertice
        Dim edge As Edge(Of Integer) = graph.AddEdge(vertex1, vertex2)

        ' The partner of vertex1 will be vertex2
        Assert.AreSame(edge.GetPartnerVertex(vertex1), vertex2)

    ' The edge will be directed, since the
    ' graph only accepts directed edges.
    Assert.IsTrue(edge.IsDirected)
  End Sub
#End Region


#Region "Tag"
  <Test()> _
  Public Sub TagExample()
    ' Create the graph to add the edge to.
    Dim graph As New Graph(Of Integer)(True)

    ' Create the two vertices that would make 
    ' up the edge
        Dim vertex1 As New Vertex(Of Integer)(5)
        Dim vertex2 As New Vertex(Of Integer)(3)

    ' Add an edge between the two vertice
        Dim edge As New Edge(Of Integer)(vertex1, vertex2, False)

    ' Add a tag object to the edge
    edge.Tag = 20

    ' The tag on the edge will be equal to 20.
    Assert.AreEqual(edge.Tag, 20)
  End Sub

#End Region


#Region "Weight"
  <Test()> _
  Public Sub WeightExample()
    ' Create the graph to add the edge to.
    Dim graph As New Graph(Of Integer)(True)

    ' Create the two vertices that would make 
    ' up the edge
        Dim vertex1 As New Vertex(Of Integer)(5)
        Dim vertex2 As New Vertex(Of Integer)(3)

    ' Add an edge between the two vertice
        Dim edge As New Edge(Of Integer)(vertex1, vertex2, 32.4, False)

    ' The weight on the edge, set in the constructor
    ' is equal to 32.4.  
    Assert.AreEqual(edge.Weight, 32.4)

    ' The weight can also be set with the property
    edge.Weight = 3.67

    Assert.AreEqual(edge.Weight, 3.67)
  End Sub

#End Region

End Class


