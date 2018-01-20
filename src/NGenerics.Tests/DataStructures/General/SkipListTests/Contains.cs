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

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Contains
    {

        [Test]
        public void KeyValuePair()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(i, i.ToString());
            }

            Assert.IsTrue(skipList.Contains(new KeyValuePair<int, string>(5, "5")));
            Assert.IsTrue(skipList.Contains(new KeyValuePair<int, string>(6, "6")));

            Assert.IsFalse(skipList.Contains(new KeyValuePair<int, string>(5, "6")));
            Assert.IsFalse(skipList.Contains(new KeyValuePair<int, string>(100, "100")));
        }

    }
}