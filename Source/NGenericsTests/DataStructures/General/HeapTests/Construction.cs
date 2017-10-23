/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Collections.Generic;
using System.Reflection;
using NGenerics.DataStructures.General;
using NUnit.Framework;
using NGenerics.Tests.Util;

namespace NGenerics.Tests.DataStructures.General.HeapTests
{



    [TestFixture]
    public class Construction
    {
        private static readonly Type heapType = typeof(Heap<int>);
        private static readonly Type heapTypeType = typeof(HeapType);


        [Test]
        public void InvalidHeapType1()
        {
            Exception argException = null;
            try
            {
                var constructor = heapType.GetConstructor(new[] { heapTypeType, typeof(IComparer<int>) });
                constructor.Invoke(new object[] { -1, Comparer<int>.Default });
            }
            catch (TargetInvocationException e)
            {
                argException = e.InnerException;
            }
            Assert.IsNotNull(argException);
        }


        [Test]
        public void InvalidHeapType2()
        {
            Exception argException = null;
            try
            {
                var constructor = heapType.GetConstructor(new[] { heapTypeType, typeof(int), typeof(IComparer<int>) });
                constructor.Invoke(new object[] { -1, 5, Comparer<int>.Default });
            }
            catch (TargetInvocationException e)
            {
                argException = e.InnerException;
            }
            Assert.IsNotNull(argException);
        }

        [Test]
        public void ComparerDelegate1()
        {
            var heap = new Heap<SimpleClass>(HeapType.Maximum, (x, y) => x.TestProperty.CompareTo(y.TestProperty))
                           {
                               new SimpleClass("5")
                           };

            Assert.AreEqual(heap.Count, 1);
            Assert.AreEqual(heap.Root.TestProperty, "5");

            heap.Add(new SimpleClass("2"));
            Assert.AreEqual(heap.Count, 2);
            Assert.AreEqual(heap.Root.TestProperty, "5");

            heap.Add(new SimpleClass("3"));
            Assert.AreEqual(heap.Count, 3);
            Assert.AreEqual(heap.Root.TestProperty, "5");

            Assert.AreEqual(heap.RemoveRoot().TestProperty, "5");

            heap.Add(new SimpleClass("1"));
            Assert.AreEqual(heap.Count, 3);
            Assert.AreEqual(heap.Root.TestProperty, "3");
        }

        [Test]
        public void ComparerDelegateWithIntialSize()
        {
            var heap = new Heap<SimpleClass>(HeapType.Maximum, 10, (x, y) => x.TestProperty.CompareTo(y.TestProperty))
                           {
                               new SimpleClass("5")
                           };

            Assert.AreEqual(heap.Count, 1);
            Assert.AreEqual(heap.Root.TestProperty, "5");

            heap.Add(new SimpleClass("2"));
            Assert.AreEqual(heap.Count, 2);
            Assert.AreEqual(heap.Root.TestProperty, "5");

            heap.Add(new SimpleClass("3"));
            Assert.AreEqual(heap.Count, 3);
            Assert.AreEqual(heap.Root.TestProperty, "5");

            Assert.AreEqual(heap.RemoveRoot().TestProperty, "5");

            heap.Add(new SimpleClass("1"));
            Assert.AreEqual(heap.Count, 3);
            Assert.AreEqual(heap.Root.TestProperty, "3");
        }
    }





}
