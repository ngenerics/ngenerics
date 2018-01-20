/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class ConvertAll
    {
        [Test]
        public void Simple()
        {
            var intListBase = new ListBase<int> {4};

            var longListBase = intListBase.ConvertAll(IntToLong);

            Assert.IsTrue(longListBase.Contains(4));
        }

        public static long IntToLong(int x)
        {
            return x;
        }
    }
}