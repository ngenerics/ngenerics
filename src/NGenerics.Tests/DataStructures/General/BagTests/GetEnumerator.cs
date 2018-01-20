/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class GetEnumerator : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = GetTestBag();
            var enumerator = bag.GetEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;

            }

            Assert.AreEqual(counter, 20);
        }

        [Test]
        public void GenericInterface()
        {
            IEnumerable<string> bag = GetTestBag();
            var enumerator = bag.GetEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;

            }

            Assert.AreEqual(counter, 20);
        }

        [Test]
        public void Interface()
        {
            IEnumerable bag = GetTestBag();
            var enumerator = bag.GetEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;
            }

            Assert.AreEqual(counter, 20);
        }

    }
}