/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.QRDecompositionTests
{
    [TestFixture]
    public class IsFullRank
    {

        [Test]
        public void Simple()
        {
            var a = new Matrix(2, 2);
            a[0, 0] = 0;
            a[0, 1] = 0;
            a[1, 0] = 1;
            a[1, 1] = 0;

            var b = new Matrix(2, 2);
            b[0, 0] = 0;
            b[0, 1] = 0;
            b[1, 0] = 0;
            b[1, 1] = 1;

            var qrDecomposition = new QRDecomposition(a);
            Assert.IsFalse(qrDecomposition.IsFullRank);

            qrDecomposition = new QRDecomposition(b);
            Assert.IsFalse(qrDecomposition.IsFullRank);

            qrDecomposition = new QRDecomposition(a * b);
            Assert.IsFalse(qrDecomposition.IsFullRank);
        }

    }
}