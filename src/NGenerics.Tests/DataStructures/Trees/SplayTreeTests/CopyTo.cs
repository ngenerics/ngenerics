/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class CopyTo : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = GetTestTree();

            var array = new KeyValuePair<int, string>[6];
            splayTree.CopyTo(array, 0);

            var list = new List<KeyValuePair<int, string>>(array);

            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(4, "4")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(6, "6")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(2, "2")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(5, "5")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(19, "19")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(1, "1")));

            Assert.AreEqual(list.Count, 6);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArray()
        {
            var splayTree = GetTestTree();
            splayTree.CopyTo(null, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExeptionNotEnoughSpaceInTargetArray1()
        {
            var splayTree = GetTestTree();
            var array = new KeyValuePair<int, string>[5];
            splayTree.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExeptionNotEnoughSpaceInTargetArray2()
        {
            var splayTree = GetTestTree();
            var array = new KeyValuePair<int, string>[6];
            splayTree.CopyTo(array, 1);
        }

    }
}