/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Trees;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.Observable
{
    [TestFixture]
    public class ObservableBinaryTreeTest
    {

        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableBinaryTree<int>(4));
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableBinaryTree<int>(4));
            }
            [Test]
            public void Monitor2()
            {
                var left = new BinaryTree<int>(2);
                var right = new BinaryTree<int>(2);
                ObservableCollectionTester.CheckMonitor(new ObservableBinaryTree<int>(4, left, right));
            }
            [Test]
            public void Monitor3()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableBinaryTree<int>(4, 5, 6));
            }
        }
        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
                var binaryTree = new ObservableBinaryTree<string>("root");
                ObservableCollectionTester.ExpectEvents(binaryTree, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var binaryTree = new ObservableBinaryTree<string>("root");
                new ReentracyTester<ObservableBinaryTree<string>>(binaryTree, obj => obj.Add("foo"));
            }
            [Test]
            public void BinaryTree()
            {
                var rootBinaryTree = new ObservableBinaryTree<string>("root");
                var childBinaryTree = new BinaryTree<string>("child");
                ObservableCollectionTester.ExpectEvents(rootBinaryTree, obj => obj.Add(childBinaryTree), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionBinaryTreeReentrancy()
            {
                var rootBinaryTree = new ObservableBinaryTree<string>("root");
                var childBinaryTree = new BinaryTree<string>("child");
                new ReentracyTester<ObservableBinaryTree<string>>(rootBinaryTree, obj => obj.Add(childBinaryTree));
            }

        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
                var binaryTree = new ObservableBinaryTree<string>("root")
                                     {
                                         "foo"
                                     };
                ObservableCollectionTester.ExpectEvents(binaryTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var binaryTree = new ObservableBinaryTree<string>("root");
                new ReentracyTester<ObservableBinaryTree<string>>(binaryTree, obj => obj.Add("foo"));
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var binaryTree = new ObservableBinaryTree<string>("root")
                                     {
                                         "foo"
                                     };
                ObservableCollectionTester.ExpectEvents(binaryTree, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var binaryTree = new ObservableBinaryTree<string>("root")
                                     {
                                         "foo",
                                         "bar"
                                     };
                new ReentracyTester<ObservableBinaryTree<string>>(binaryTree, obj => obj.Remove("foo"), obj => obj.Remove("bar"));
            }
            [Test]
            public void BinaryTree()
            {
                var rootBinaryTree = new ObservableBinaryTree<string>("root");
                var childBinaryTree = new BinaryTree<string>("child");
                rootBinaryTree.Add(childBinaryTree);
                ObservableCollectionTester.ExpectEvents(rootBinaryTree, obj => obj.Remove(childBinaryTree), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionBinaryTreeReentrancy()
            {
                var rootBinaryTree = new ObservableBinaryTree<string>("root");
                var childBinaryTree = new BinaryTree<string>("child");
                rootBinaryTree.Add(childBinaryTree);
                new ReentracyTester<ObservableBinaryTree<string>>(rootBinaryTree, obj => obj.Add(childBinaryTree));
            }
    
        }
        [TestFixture]
        public class RemoveLeft
        {
            [Test]
            public void Simple()
            {
                var rootBinaryTree = new ObservableBinaryTree<string>("root")
                                         {
                                             "foo"
                                         };
                ObservableCollectionTester.ExpectEvents(rootBinaryTree, obj => obj.RemoveLeft(), "Count", "Item[]", "IsEmpty");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var rootBinaryTree = new ObservableBinaryTree<string>("root")
                                         {
                                             "foo"
                                         };
                new ReentracyTester<ObservableBinaryTree<string>>(rootBinaryTree, obj => obj.RemoveLeft());
            }
        }
        [TestFixture]
        public class RemoveRight
        {
            [Test]
            public void Simple()
            {
                var rootBinaryTree = new ObservableBinaryTree<string>("root")
                                         {
                                             "foo",
                                             "bar"
                                         };
                ObservableCollectionTester.ExpectEvents(rootBinaryTree, obj => obj.RemoveRight(), "Count", "Item[]", "IsEmpty");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var rootBinaryTree = new ObservableBinaryTree<string>("root")
                                         {
                                             "foo",
                                             "bar"
                                         };
                new ReentracyTester<ObservableBinaryTree<string>>(rootBinaryTree, obj => obj.RemoveRight());
            }
        }

    }
}