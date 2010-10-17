/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.Tests.Util;
using NUnit.Framework;
using NGenerics.DataStructures.Mathematical;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests

{
    [TestFixture]
        public class Serializable
        {

            [Test]
            public void Simple()
            {
                var originalComplexNumber = new ComplexNumber(2, 3);
                var newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(5, -1);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(-4, 5);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(0, 0);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(0, 5);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(5, 0);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(-3, -2);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);
            }

        }
    }
