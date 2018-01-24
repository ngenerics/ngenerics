/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Clear : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = GetTestBag();

            bag.Clear();
            Assert.AreEqual(0, bag.Count);
            Assert.IsTrue(bag.IsEmpty());

            bag.Add("aa");
            bag.Clear();

            Assert.AreEqual(0, bag.Count);
            Assert.IsTrue(bag.IsEmpty());
        }
    }
}