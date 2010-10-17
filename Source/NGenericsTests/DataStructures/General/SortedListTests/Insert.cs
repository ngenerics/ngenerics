using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class Insert
    {

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void Simple()
        {
            IList<int> sortedList = new SortedList<int>();
            sortedList.Insert(5, 2);
        }


    }
}