/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class OperatorDouble
    {

        [Test]
        public void Simple()
        {
            ComplexNumber complexNumber = 7;
            Assert.AreEqual(7, complexNumber.Real);
            Assert.AreEqual(0, complexNumber.Imaginary);

        }

    }
}