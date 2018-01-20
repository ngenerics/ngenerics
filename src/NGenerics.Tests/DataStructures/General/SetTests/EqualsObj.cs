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
    public class EqualsObj
    {

        [Test]
        public void Null()
        {
            var pascalSet = new PascalSet(20);
            Assert.IsFalse(pascalSet.Equals(null));
        }

        [Test]
        public void Simple()
        {
            var pascalSet1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var pascalSet2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });
            var pascalSet3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var pascalSet4 = new PascalSet(10, 50, new[] { 15, 20, 30, 40, 34 });

            Assert.IsTrue(pascalSet1.Equals(pascalSet3));
            Assert.IsFalse(pascalSet1.Equals(pascalSet2));
            Assert.IsFalse(pascalSet1.Equals(pascalSet4));
        }

    }
}