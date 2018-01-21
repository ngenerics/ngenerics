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

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class CopyTo : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();

            var array = new int[7];
            generalTree.CopyTo(array, 0);

            var list = new List<int>(array);
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(9));
            Assert.IsTrue(list.Contains(12));
            Assert.IsTrue(list.Contains(13));
        }

        [Test]
        public void ExceptionNullArray()
        {
            var generalTree = GetTestTree();
            Assert.Throws<ArgumentNullException>(() => generalTree.CopyTo(null, 1));
        }

        [Test]
        public void ExceptionInvalid1()
        {
            var generalTree = GetTestTree();
            var array = new int[6];
            Assert.Throws<ArgumentException>(() => generalTree.CopyTo(array, 0));
        }

        [Test]
        public void ExceptionInvalid2()
        {
            var generalTree = GetTestTree();
            var array = new int[7];
            Assert.Throws<ArgumentException>(() => generalTree.CopyTo(array, 1));
        }
    }
}