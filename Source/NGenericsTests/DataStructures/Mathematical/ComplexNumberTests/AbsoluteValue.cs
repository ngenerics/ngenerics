/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class AbsoluteValue
    {

        [Test]
        public void Simple()
        {
            var complexNumber1 = new ComplexNumber(-3, -4);
            var complexNumber2 = new ComplexNumber(-3, 4);
            var complexNumber3 = new ComplexNumber(3, -4);
            var complexNumber4 = new ComplexNumber(3, 4);

            Assert.AreEqual(5, complexNumber1.AbsoluteValue);
            Assert.AreEqual(5, complexNumber2.AbsoluteValue);
            Assert.AreEqual(5, complexNumber3.AbsoluteValue);
            Assert.AreEqual(5, complexNumber4.AbsoluteValue);
        }

    }
}