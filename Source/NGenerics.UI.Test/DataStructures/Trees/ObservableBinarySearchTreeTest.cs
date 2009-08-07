/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Collections.Generic;
using NGenerics.Tests.Util;
using NGenerics.UI.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.UI.Test.DataStructures.Trees
{
    [TestFixture]
    public class ObservableBinarySearchTreeTest
    {
		[TestFixture]
		public class Contruction
		{

			[Test]
			public void Serialization()
			{
				var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableBinarySearchTree<int, int>());
				ObservableCollectionTester.CheckMonitor(deserialize);
			}
			[Test]
			public void Monitor1()
			{
				ObservableCollectionTester.CheckMonitor(new ObservableBinarySearchTree<int, int>());
			}
			[Test]
			public void Monitor2()
			{
				ObservableCollectionTester.CheckMonitor(new ObservableBinarySearchTree<int, int>(Comparer<int>.Default));
			}
		}
        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
                var binarySearchTree = new ObservableBinarySearchTree<string, string>();
                ObservableCollectionTester.ExpectEvents(binarySearchTree, obj => obj.Add("foo", "bar"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var binarySearchTree = new ObservableBinarySearchTree<string, string>();

                new ReentracyTester<ObservableBinarySearchTree<string, string>>(binarySearchTree, obj => obj.Add("foo", "bar"));
            }
            [Test]
            public void KeyValue()
            {
                var binarySearchTree = new ObservableBinarySearchTree<string, string>();
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                ObservableCollectionTester.ExpectEvents(binarySearchTree, obj => obj.Add(keyValuePair), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionKeyValueReentrancy()
            {
                var binarySearchTree = new ObservableBinarySearchTree<string, string>();
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                new ReentracyTester<ObservableBinarySearchTree<string, string>>(binarySearchTree, obj => obj.Add(keyValuePair));
            }

        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
                var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                                                                  {
                                                                                      new KeyValuePair<string, string>("foo", "bar")
                                                                                  };
                ObservableCollectionTester.ExpectEvents(binarySearchTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                                                                  {
                                                                                      new KeyValuePair<string, string>("foo", "bar")
                                                                                  };
                new ReentracyTester<ObservableBinarySearchTree<string, string>>(binarySearchTree, obj => obj.Clear());
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                                                                  {
                                                                                      new KeyValuePair<string, string>("foo", "bar")
                                                                                  };
                ObservableCollectionTester.ExpectEvents(binarySearchTree, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                                                                  {
                                                                                      new KeyValuePair<string, string>("foo", "bar")
                                                                                  };
                new ReentracyTester<ObservableBinarySearchTree<string, string>>(binarySearchTree, obj => obj.Remove("foo"));
            }
            [Test]
            public void KeyValue()
            {
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                                                                  {
                                                                                      keyValuePair
                                                                                  };
                ObservableCollectionTester.ExpectEvents(binarySearchTree, obj => obj.Remove(keyValuePair), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionKeyValueReentrancy()
            {
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                                                                  {
                                                                                      keyValuePair
                                                                                  };
                new ReentracyTester<ObservableBinarySearchTree<string, string>>(binarySearchTree, obj => obj.Remove(keyValuePair));
            }

        }

    }
}