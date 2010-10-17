/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class Index
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            Assert.AreEqual(2, vector.DimensionCount);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);

            vector[0] = 4;
            vector[1] = 5;

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(5, vector[1]);
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionTooLarge()
        {
            var vector = new VectorN(2);
            var d = vector[2];
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionTooSmall()
        {
            var vector = new VectorN(2);
            var d = vector[-1];
        }

    }
}