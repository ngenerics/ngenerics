'  
' Copyright 2007-2009 The NGenerics Team
' (http://code.google.com/p/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports NGenerics.DataStructures.Trees
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Public Class BinarySearchTreeBaseExamples

#Region "Accept"
  <Test()> _
  Public Sub AcceptVisitorExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' There should be 3 items in the tree.
    Assert.AreEqual(tree.Count, 3)

    ' Create a visitor that will simply count the items in the tree.
    Dim visitor As CountingVisitor(Of KeyValuePair(Of String, Integer)) = _
        New CountingVisitor(Of KeyValuePair(Of String, Integer))()

    ' Make the tree call IVisitor<T>.Visit on all items contained.
    tree.AcceptVisitor(visitor)

    ' The counting visitor would have visited 3 items.
    Assert.AreEqual(visitor.Count, 3)
  End Sub
#End Region

#Region "Add"
  <Test()> _
  Public Sub AddExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' There should be 3 items in the tree.
    Assert.AreEqual(tree.Count, 3)
  End Sub
#End Region

#Region "AddKeyValuePair"
  <Test()> _
  Public Sub AddKeyValuePairExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' There should be 3 items in the tree.
    Assert.AreEqual(tree.Count, 3)

    ' The tree should contain all three keys
    Assert.AreEqual(tree.ContainsKey("cat"), True)
    Assert.AreEqual(tree.ContainsKey("dog"), True)
    Assert.AreEqual(tree.ContainsKey("canary"), True)

    ' The value of the item with key "dog" must be 2.
    Assert.AreEqual(tree.Item("dog"), 2)
  End Sub
#End Region

#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' There should be 3 items in the tree.
    Assert.AreEqual(tree.Count, 3)

    ' Clear the tree
    tree.Clear()

    ' The tree should be empty.
    Assert.AreEqual(tree.Count, 0)

    ' No cat here..
    Assert.AreEqual(tree.ContainsKey("cat"), False)
  End Sub
#End Region

#Region "Contains"
  <Test()> _
  Public Sub ContainsExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' The tree should contain 1 cat and 2 dogs...
    Assert.AreEqual( _
        tree.Contains(New KeyValuePair(Of String, Integer)("cat", 1)), _
        True _
    )

    Assert.AreEqual( _
        tree.Contains(New KeyValuePair(Of String, Integer)("dog", 2)), _
        True _
    )

    ' But not 3 cats and 1 dog
    Assert.AreEqual( _
        tree.Contains(New KeyValuePair(Of String, Integer)("cat", 3)), _
        False _
    )

    Assert.AreEqual( _
        tree.Contains(New KeyValuePair(Of String, Integer)("dog", 1)), _
        False _
    )
  End Sub
#End Region

#Region "ContainsKey"
  <Test()> _
  Public Sub ContainsKeyExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' The tree should contain a cat and a dog...
    Assert.AreEqual(tree.ContainsKey("cat"), True)
    Assert.AreEqual(tree.ContainsKey("dog"), True)

    ' But definitely not an ostrich.
    Assert.AreEqual(tree.ContainsKey("ostrich"), False)
  End Sub
#End Region

#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' Create a new array of length 3 to copy the elements into.
    Dim values(3) As KeyValuePair(Of String, Integer)
    tree.CopyTo(values, 0)
  End Sub
#End Region

#Region "Count"
  <Test()> _
  Public Sub CountExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)

    ' Tree count is 0.
    Assert.AreEqual(tree.Count, 0)

    ' Add a cat.
    tree.Add(New KeyValuePair(Of String, Integer)("cat", 1))

    ' Tree count is 1.
    Assert.AreEqual(tree.Count, 1)

    ' Add a dog
    tree.Add(New KeyValuePair(Of String, Integer)("dog", 2))

    ' Tree count is 2.
    Assert.AreEqual(tree.Count, 2)

    ' Clear the tree - thereby removing all items contained.
    tree.Clear()

    ' Tree is empty again with 0 count.
    Assert.AreEqual(tree.Count, 0)
  End Sub
#End Region

#Region "DepthFirstTraversal"
  <Test()> _
  Public Sub DepthFirstTraversalExample()
    ' Create a simple tree
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add(New KeyValuePair(Of String, Integer)("horse", 4))
    tree.Add(New KeyValuePair(Of String, Integer)("cat", 1))
    tree.Add(New KeyValuePair(Of String, Integer)("dog", 2))
    tree.Add(New KeyValuePair(Of String, Integer)("canary", 3))

    ' Create a tracking visitor which will track the items
    ' the tree calls visit on.
    Dim visitor As New TrackingVisitor(Of KeyValuePair(Of String, Integer))

    ' We'll wrap the tracking visitor in an ordered visitor and visit
    ' the items in in-order order.  Effectively the visitor would visit
    ' the items in sorted order.
    Dim inOrderVisitor As New  _
    InOrderVisitor(Of KeyValuePair(Of String, Integer))(visitor)

    ' Perform a depth-first traversal of the tree.
    tree.DepthFirstTraversal(inOrderVisitor)

    ' The tracking list has the items in sorted order.
    Assert.AreEqual(visitor.TrackingList(0).Key, "canary")
    Assert.AreEqual(visitor.TrackingList(1).Key, "cat")
    Assert.AreEqual(visitor.TrackingList(2).Key, "dog")
    Assert.AreEqual(visitor.TrackingList(3).Key, "horse")
  End Sub
#End Region

#Region "GetEnumerator"
  Public Sub GetEnumeratorExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    Dim enumerator As IEnumerator(Of KeyValuePair(Of String, Integer)) = tree.GetEnumerator()

    ' Enumerate through the items in the tree, and write the contents
    ' to the standard output.
    While enumerator.MoveNext()
      System.Console.Write("Key : ")
      System.Console.WriteLine(enumerator.Current.Key)
      System.Console.Write("Value : ")
      System.Console.WriteLine(enumerator.Current.Value)
    End While
  End Sub
#End Region

#Region "GetOrderedEnumerator"
  Public Sub GetSortedEnumeratorExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("horse", 4)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    Dim enumerator As IEnumerator(Of KeyValuePair(Of String, Integer)) = tree.GetOrderedEnumerator()

    ' Enumerate through the items in the tree, and write the contents
    ' to the standard output.  The enumerator will supply items in a sorted order.
    While enumerator.MoveNext()
      System.Console.Write("Key : ")
      System.Console.WriteLine(enumerator.Current.Key)
      System.Console.Write("Value : ")
      System.Console.WriteLine(enumerator.Current.Value)
    End While
  End Sub
#End Region

#Region "IsEmpty"
  <Test()> _
  Public Sub IsEmptyExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)

    ' Tree is empty.
    Assert.AreEqual(tree.IsEmpty, True)

    ' Add a cat.
    tree.Add(New KeyValuePair(Of String, Integer)("cat", 1))

    ' Tree is not empty.
    Assert.AreEqual(tree.IsEmpty, False)

    ' Clear the tree - thereby removing all items contained.
    tree.Clear()

    ' Tree is empty again with count = 0.
    Assert.AreEqual(tree.IsEmpty, True)
  End Sub
#End Region


#Region "IsReadOnly"
  <Test()> _
  Public Sub IsReadOnlyExample()
    ' The IsReadOnly property will always return false - the 
    ' Search Tree is not a read-only data structure.
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)

    Assert.AreEqual(tree.IsReadOnly, False)
  End Sub
#End Region

#Region "Keys"
  <Test()> _
  Public Sub ValuesExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' Retrieve the keys from the tree.
    Dim keys As ICollection(Of String) = tree.Keys

    ' The keys collection contains three items : 
    ' "cat", "dog", and "canary".
    Assert.AreEqual(keys.Count, 3)

    Assert.AreEqual(keys.Contains("cat"), True)
    Assert.AreEqual(keys.Contains("dog"), True)
    Assert.AreEqual(keys.Contains("canary"), True)
  End Sub
#End Region

#Region "Maximum"
  <Test()> _
 Public Sub MaxExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    Dim maximum As KeyValuePair(Of String, Integer) = tree.Maximum

    ' The "maximum" key would be "dog" since it occurs 
    ' last when sorted alphabetically
    Assert.AreEqual(maximum.Key, "dog")
    Assert.AreEqual(maximum.Value, 2)
  End Sub
#End Region

#Region "Minimum"
  <Test()> _
  Public Sub MinExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    Dim minimum As KeyValuePair(Of String, Integer) = tree.Minimum

    ' The "minimum" key would be "canary" since it occurs 
    ' last when sorted alphabetically
    Assert.AreEqual(minimum.Key, "canary")
    Assert.AreEqual(minimum.Value, 3)
  End Sub
#End Region

#Region "Remove"
  <Test()> _
  Public Sub RemoveExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' There are three items in the tree
    Assert.AreEqual(tree.Count, 3)

    ' Let's remove the dog
    tree.Remove("dog")

    ' Now the tree contains only two items, and dog isn't 
    ' in the tree.
    Assert.AreEqual(tree.Count, 2)
    Assert.AreEqual(tree.ContainsKey("dog"), False)
  End Sub
#End Region

#Region "TryGetValue"
  <Test()> _
  Public Sub TryGetValueExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    Dim value As Integer

    ' We'll get the value for cat successful.
    Assert.AreEqual( _
        tree.TryGetValue("cat", value), _
        True _
    )

    ' And the value should be 1.
    Assert.AreEqual(value, 1)

    ' But we won't get a horse
    Assert.AreEqual( _
        tree.TryGetValue("horse", value), _
        False _
    )
  End Sub
#End Region

#Region "Values"
  <Test()> _
  Public Sub KeysExample()
    Dim tree As BinarySearchTreeBase(Of String, Integer) = New BinarySearchTree(Of String, Integer)
    tree.Add("cat", 1)
    tree.Add("dog", 2)
    tree.Add("canary", 3)

    ' Retrieve the values from the tree.
    Dim values As ICollection(Of Integer) = tree.Values

    ' The keys collection contains three items : 
    ' 1, 2, and 3.
    Assert.AreEqual(values.Count, 3)

    Assert.AreEqual(values.Contains(1), True)
    Assert.AreEqual(values.Contains(2), True)
    Assert.AreEqual(values.Contains(3), True)
  End Sub
#End Region

End Class
