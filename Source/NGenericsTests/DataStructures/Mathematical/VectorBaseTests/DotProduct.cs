/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.Tests.DataStructures.Mathematical.VectorBaseTestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTests
{
    [TestFixture]
    public class DotProduct
    {

        [Test]
        [ExpectedException(typeof(NotImplementedException), ExpectedMessage = "DotProductSafe")]
        public void Exception1()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            vector1.DotProduct(vector2);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector()
        {
            var vector1 = new VectorBaseTestObject(2);
            vector1.DotProduct(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void EceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            vector1.DotProduct(vector2);
        }

    }
}