/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class Clear
    {

        [Test]
        public void Simple()
        {
            var values = new[] { 20, 30, 40 };
            var pascalSet = new PascalSet(0, 50, values);

            Assert.AreEqual(pascalSet.Count, 3);

            pascalSet.Clear();

            for (var i = 0; i <= 50; i++)
            {
                Assert.IsFalse(pascalSet[i]);
            }

            Assert.AreEqual(pascalSet.Count, 0);
        }

    }
}