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
    public class TrimExcess
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<string>(5) { "as", "bs", "c" };
            listBase.TrimExcess();
            Assert.AreEqual(3, listBase.Capacity);
        }


    }
}