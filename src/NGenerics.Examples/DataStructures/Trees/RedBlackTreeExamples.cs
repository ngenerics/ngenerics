/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;
using NGenerics.DataStructures.Trees;

namespace NGenerics.Examples.DataStructures.Trees
{
    [TestFixture]
    public class RedBlackTreeExamples
    {
        #region Accept
        [Test]
        public void AcceptVisitorExample()
        {
            var tree = new RedBlackTree<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // There should be 3 items in the tree.
            Assert.AreEqual(3, tree.Count);

            // Create a visitor that will simply count the items in the tree.
            var visitor = 
                new CountingVisitor<KeyValuePair<string, int>>();
            
            // Make the tree call IVisitor<T>.Visit on all items contained.
            tree.AcceptVisitor(visitor);

            // The counting visitor would have visited 3 items.
            Assert.AreEqual(3, visitor.Count);
        }
        #endregion

        #region Add
        [Test]
        public void AddExample()
        {
            // Create a simple tree
            var tree = new RedBlackTree<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // There should be 3 items in the tree.
            Assert.AreEqual(3, tree.Count);
        }
        #endregion

        #region AddKeyValuePair
        [Test]
        public void AddKeyValuePairExample()
        {
            // Create a simple tree
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            // There should be 3 items in the tree.
            Assert.AreEqual(3, tree.Count);

            // The tree should contain all three keys
            Assert.IsTrue(tree.ContainsKey("cat"));
            Assert.IsTrue(tree.ContainsKey("dog"));
            Assert.IsTrue(tree.ContainsKey("canary"));

            // The value of the item with key "dog" must be 2.
            Assert.AreEqual(2, tree["dog"]);
        }
        #endregion

        #region Clear
        [Test]
        public void ClearExample()
        {
            // Create a simple tree
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            // There should be 3 items in the tree.
            Assert.AreEqual(3, tree.Count);

            // Clear the tree
            tree.Clear();

            // The tree should be empty.
            Assert.AreEqual(0, tree.Count);

            // No cat here..
            Assert.IsFalse(tree.ContainsKey("cat"));
        }
        #endregion

        #region Contains
        [Test]
        public void ContainsExample()
        {
            // Create a simple tree
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            // The tree should contain 1 cat and 2 dogs...
            Assert.IsTrue(tree.Contains(new KeyValuePair<string, int>("cat", 1)));

            Assert.IsTrue(tree.Contains(new KeyValuePair<string, int>("dog", 2)));

            // But not 3 cats and 1 dog
            Assert.IsFalse(tree.Contains(new KeyValuePair<string, int>("cat", 3)));

            Assert.IsFalse(tree.Contains(new KeyValuePair<string, int>("dog", 1)));
        }
        #endregion

        #region ContainsKey
        [Test]
        public void ContainsKeyExample()
        {
            // Create a simple tree
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            // The tree should contain a cat and a dog...
            Assert.IsTrue(tree.ContainsKey("cat"));
            Assert.IsTrue(tree.ContainsKey("dog"));

            // But definitely not an ostrich.
            Assert.IsFalse(tree.ContainsKey("ostrich"));
        }
        #endregion

        #region CopyTo
        [Test]
        public void CopyToExample()
        {
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            // Create a new array of length 3 to copy the elements into.
            var values = new KeyValuePair<string, int>[3];
            tree.CopyTo(values, 0);
        }
        #endregion

        #region Count
        [Test]
        public void CountExample()
        {
            var tree = new RedBlackTree<string, int>();

            // Tree count is 0.
            Assert.AreEqual(0, tree.Count);
                        
            // Add a cat.
            tree.Add(new KeyValuePair<string, int>("cat", 1));
            
            // Tree count is 1.
            Assert.AreEqual(1, tree.Count);

            // Add a dog
            tree.Add(new KeyValuePair<string, int>("dog", 2));
            
            // Tree count is 2.
            Assert.AreEqual(2, tree.Count);

            // Clear the tree - thereby removing all items contained.
            tree.Clear();
            
            // Tree is empty again with 0 count.
            Assert.AreEqual(0, tree.Count);
        }
        #endregion

        #region DepthFirstTraversal
        [Test]
        public void DepthFirstTraversalExample()
        {
            // Create a simple tree
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("horse", 4),
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            // Create a tracking visitor which will track the items
            // the tree calls visit on.
            var visitor = new TrackingVisitor<KeyValuePair<string, int>>();
            
            // We'll wrap the tracking visitor in an ordered visitor and visit
            // the items in in-order order.  Effectively the visitor would visit
            // the items in sorted order.
            var inOrderVisitor = 
                new InOrderVisitor<KeyValuePair<string,int>>(visitor);

            // Perform a depth-first traversal of the tree.
            tree.DepthFirstTraversal(inOrderVisitor);

            // The tracking list has the items in sorted order.
            Assert.AreEqual("canary", visitor.TrackingList[0].Key);
            Assert.AreEqual("cat", visitor.TrackingList[1].Key);
            Assert.AreEqual("dog", visitor.TrackingList[2].Key);
            Assert.AreEqual("horse", visitor.TrackingList[3].Key);
        }
        #endregion

        #region GetEnumerator
        public void GetEnumeratorExample()
        {
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            var enumerator = tree.GetEnumerator();
        
            // Enumerate through the items in the tree, and write the contents
            // to the standard output.
            while (enumerator.MoveNext())
            {
                System.Console.Write("Key : ");
                System.Console.WriteLine(enumerator.Current.Key);
                System.Console.Write("Value : ");
                System.Console.WriteLine(enumerator.Current.Value);
            }
        }
        #endregion

        #region IsEmpty
        [Test]
        public void IsEmptyExample()
        {
            var tree = new RedBlackTree<string, int>();

            // Tree is empty.
            Assert.IsTrue(tree.IsEmpty);

            // Add a cat.
            tree.Add(new KeyValuePair<string, int>("cat", 1));

            // Tree is not empty.
            Assert.IsFalse(tree.IsEmpty);

            // Clear the tree - thereby removing all items contained.
            tree.Clear();

            // Tree is empty again with count = 0.
            Assert.IsTrue(tree.IsEmpty);
        }
        #endregion

        #region IsReadOnly
        [Test]
        public void IsReadOnlyExample()
        {
            // The IsReadOnly property will always return false - the 
            // Red Black Tree is not a read-only data structure.
            var tree = new RedBlackTree<string, int>();

            Assert.IsFalse(tree.IsReadOnly);
        }
        #endregion

        #region Keys
        [Test]
        public void KeysExample()
        {
            // Build a simple tree.
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            // Retrieve the keys from the tree.
            var keys = tree.Keys;
            
            // The keys collection contains three items : 
            // "cat", "dog", and "canary".
            Assert.AreEqual(3, keys.Count);

            Assert.IsTrue(keys.Contains("cat"));
            Assert.IsTrue(keys.Contains("dog"));
            Assert.IsTrue(keys.Contains("canary"));
        }
        #endregion

        #region Maximum
        [Test]
        public void MaxExample()
        {
            // Build a simple tree.
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            var maximum = tree.Maximum;

            // The "maximum" key would be "dog" since it occurs 
            // last when sorted alphabetically
            Assert.AreEqual("dog", maximum.Key);
            Assert.AreEqual(2, maximum.Value);
        }
        #endregion

        #region Minimum
        [Test]
        public void MinExample()
        {
            // Build a simple tree.
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            var minimum = tree.Minimum;

            // The "maximum" key would be "canary" since it occurs 
            // first when sorted alphabetically
            Assert.AreEqual("canary", minimum.Key);
            Assert.AreEqual(3, minimum.Value);
        }
        #endregion

        #region Remove
        [Test]
        public void RemoveExample()
        {
            // Build a simple tree.
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            // There are three items in the tree
            Assert.AreEqual(3, tree.Count);

            // Let's remove the dog
            tree.Remove("dog");

            // Now the tree contains only two items, and dog isn't 
            // in the tree.
            Assert.AreEqual(2, tree.Count);
            Assert.IsFalse(tree.ContainsKey("dog"));
        }

        #endregion

        #region TryGetValue
        [Test]
        public void TryGetValueExample()
        {
            // Build a simple tree.
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            int value;

            // We'll get the value for cat successfully.
            Assert.IsTrue(tree.TryGetValue("cat", out value));

            // And the value should be 1.
            Assert.AreEqual(1, value);

            // But we won't get a horse
            Assert.IsFalse(tree.TryGetValue("horse", out value));
        }
        #endregion

        #region Values
        [Test]
        public void ValuesExample()
        {
            // Build a simple tree.
            var tree = new RedBlackTree<string, int>
                                                 {
                                                     new KeyValuePair<string, int>("cat", 1),
                                                     new KeyValuePair<string, int>("dog", 2),
                                                     new KeyValuePair<string, int>("canary", 3)
                                                 };

            // Retrieve the values from the tree.
            var values = tree.Values;

            // The keys collection contains three items : 
            // 1, 2, and 3.
            Assert.AreEqual(3, values.Count);

            Assert.IsTrue(values.Contains(1));
            Assert.IsTrue(values.Contains(2));
            Assert.IsTrue(values.Contains(3));
        }
        #endregion
    }
}
