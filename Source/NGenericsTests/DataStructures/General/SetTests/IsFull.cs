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
    public class IsFull
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(0, 100);
            Assert.IsFalse(pascalSet.IsFull);

            for (var i = 0; i <= 100; i++)
            {
                pascalSet.Add(i);

                if (i < 100)
                {
                    Assert.IsFalse(pascalSet.IsFull);
                }
                else
                {
                    Assert.IsTrue(pascalSet.IsFull);
                }
            }

            pascalSet.Clear();

            Assert.IsFalse(pascalSet.IsFull);
        }

    }
}