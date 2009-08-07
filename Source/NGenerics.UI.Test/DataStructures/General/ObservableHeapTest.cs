/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.Tests.Util;
using NGenerics.UI.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.UI.Test.DataStructures.General
{
    [TestFixture]
    public class ObservableHeapTest
    {


        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableHeap<int>(HeapType.Minimum));
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableHeap<int>(HeapType.Minimum));
            }
            [Test]
            public void Monitor2()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableHeap<int>(HeapType.Minimum, Comparer<int>.Default));
            }
            [Test]
            public void Monitor3()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableHeap<int>(HeapType.Minimum,2));
            }
            [Test]
            public void Monitor4()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableHeap<int>(HeapType.Minimum, 2, Comparer<int>.Default));
            }
        }

        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
                var heap = new ObservableHeap<string>(HeapType.Minimum);
                ObservableCollectionTester.ExpectEvents(heap, obj => obj.Add("foo"), "Count", "Root", "IsEmpty");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var heap = new ObservableHeap<string>(HeapType.Minimum);
                new ReentracyTester<ObservableHeap<string>>(heap, obj => obj.Add("foo"));
            }
        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
                var heap = new ObservableHeap<string>(HeapType.Minimum)
                               {
                                   "foo"
                               };

                ObservableCollectionTester.ExpectEvents(heap, obj => obj.Clear(), "Count", "Root", "IsEmpty");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var heap = new ObservableHeap<string>(HeapType.Minimum)
                               {
                                   "foo"
                               };
                new ReentracyTester<ObservableHeap<string>>(heap, obj => obj.Clear());
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var heap = new ObservableHeap<string>(HeapType.Minimum)
                               {
                                   "foo"
                               };

                ObservableCollectionTester.ExpectEvents(heap, obj => obj.RemoveRoot(), "Count", "Root", "IsEmpty");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var heap = new ObservableHeap<string>(HeapType.Minimum)
                               {
                                   "foo"
                               };
                new ReentracyTester<ObservableHeap<string>>(heap, obj => obj.RemoveRoot());
            }
        }

    }
}