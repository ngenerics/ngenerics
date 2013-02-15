/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class Construcion : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = new GeneralTree<int>(5);

            Assert.AreEqual(generalTree.Count, 0);
            Assert.AreEqual(generalTree.Degree, 0);
            Assert.AreEqual(generalTree.Height, 0);
            Assert.IsTrue(generalTree.IsEmpty);
            Assert.IsTrue(generalTree.IsLeafNode);
            Assert.IsNull(generalTree.Parent);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullData()
        {
            new GeneralTree<string>(null);
        }

    }
}