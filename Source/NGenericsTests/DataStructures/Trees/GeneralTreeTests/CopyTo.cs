/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArray()
        {
            var generalTree = GetTestTree();
            generalTree.CopyTo(null, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalid1()
        {
            var generalTree = GetTestTree();
            var array = new int[6];
            generalTree.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalid2()
        {
            var generalTree = GetTestTree();
            var array = new int[7];
            generalTree.CopyTo(array, 1);
        }

    }
}