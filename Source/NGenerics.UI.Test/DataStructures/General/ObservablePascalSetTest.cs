/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.Tests.Util;
using NGenerics.UI.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.UI.Test.DataStructures.General
{
    [TestFixture]
    public class ObservablePascalSetTest
    {
        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservablePascalSet(0, 10));
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservablePascalSet(0,10));
            }
            [Test]
            public void Monitor2()
            {
                ObservableCollectionTester.CheckMonitor(new ObservablePascalSet(0,10,new []{1}));
            }
            [Test]
            public void Monitor3()
            {
                ObservableCollectionTester.CheckMonitor(new ObservablePascalSet(10));
            }
            [Test]
            public void Monitor4()
            {
                ObservableCollectionTester.CheckMonitor(new ObservablePascalSet(10, new[] { 1 }));
            }
        }

        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
                var pascalSet = new ObservablePascalSet(10);
                ObservableCollectionTester.ExpectEvents(pascalSet, obj => obj.Add(4), "Count", "LowerBound", "UpperBound", "Capacity", "IsFull", "Item[]");
                
            }


            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var pascalSet = new ObservablePascalSet(10);
                new ReentracyTester<ObservablePascalSet>(pascalSet, obj => obj.Add(4), obj => obj.Add(5));
            }
        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
                var pascalSet = new ObservablePascalSet(10){4};

                ObservableCollectionTester.ExpectEvents(pascalSet, obj => obj.Clear(), "Count", "LowerBound", "UpperBound", "Capacity", "IsFull", "Item[]");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var pascalSet = new ObservablePascalSet(10);
                new ReentracyTester<ObservablePascalSet>(pascalSet, obj => obj.Clear());
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var pascalSet = new ObservablePascalSet(10)
                                    {
                                        4
                                    };

                ObservableCollectionTester.ExpectEvents(pascalSet, obj => obj.Remove(4), "Count", "LowerBound", "UpperBound", "Capacity", "IsFull", "Item[]");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var pascalSet = new ObservablePascalSet(10)
                                    {
                                        4,
                                        5
                                    };
                new ReentracyTester<ObservablePascalSet>(pascalSet, obj => obj.Remove(4), obj => obj.Remove(5));
            }
        }

    }
}