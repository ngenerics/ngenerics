/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.Observable
{
    [TestFixture]
    public class ObservableGeneralTreeTest
    {


        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableGeneralTree<int>(4));
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableGeneralTree<int>(4));
            }
        }
			
        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
                var generalTree = new ObservableGeneralTree<string>("root");
                ObservableCollectionTester.ExpectEvents(generalTree, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var generalTree = new ObservableGeneralTree<string>("root");
                new ReentracyTester<ObservableGeneralTree<string>>(generalTree, obj => obj.Add("foo"));
            }

        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
                var generalTree = new ObservableGeneralTree<string>("root")
                                      {
                                          "foo"
                                      };
                ObservableCollectionTester.ExpectEvents(generalTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var generalTree = new ObservableGeneralTree<string>("root")
                                      {
                                          "foo"
                                      };
                new ReentracyTester<ObservableGeneralTree<string>>(generalTree, obj => obj.Clear());
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var generalTree = new ObservableGeneralTree<string>("root")
                                      {
                                          "foo"
                                      };
                ObservableCollectionTester.ExpectEvents(generalTree, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var generalTree = new ObservableGeneralTree<string>("root")
                                      {
                                          "foo", 
                                          "bar"
                                      };
                new ReentracyTester<ObservableGeneralTree<string>>(generalTree, obj => obj.Remove("foo"), obj => obj.Remove("bar"));
            }

        }

        [TestFixture]
        public class RemoveAt
        {
            [Test]
            public void Simple()
            {
                var generalTree = new ObservableGeneralTree<string>("root")
                                      {
                                          "foo"
                                      };
                ObservableCollectionTester.ExpectEvents(generalTree, obj => obj.RemoveAt(0), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var generalTree = new ObservableGeneralTree<string>("root")
                                      {
                                          "foo", 
                                          "bar"
                                      };
                new ReentracyTester<ObservableGeneralTree<string>>(generalTree, obj => obj.RemoveAt(0));
            }

        }

    }
}