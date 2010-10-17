/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

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
    public class Add
    {
        [Test]
        [ExpectedException(typeof(NotImplementedException), ExpectedMessage = "AddSafe")]
        public void Exception1()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            vector1.Add(vector2);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(4);
            vector1.Add(vector2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector()
        {
            new VectorBaseTestObject(2)
                {
                    null
                };
        }

    }
}