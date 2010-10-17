/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class GetHashcode
    {

        [Test]
        public void Simple()
        {
            var d = new Dictionary<Matrix, string>();

            for (var i = 0; i < 10; i++)
            {
                var test = MatrixTest.GetTestMatrix();
                Assert.IsFalse(d.ContainsKey(test));
                d.Add(test, null);
            }
        }

    }
}