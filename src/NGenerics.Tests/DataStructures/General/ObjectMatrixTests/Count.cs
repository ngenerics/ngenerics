/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Count:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            ICollection<int> matrix = new ObjectMatrix<int>(10, 15);

            Assert.AreEqual(matrix.Count, 150);

            matrix = new ObjectMatrix<int>(3, 3);
            Assert.AreEqual(matrix.Count, 9);
        }
    }
}