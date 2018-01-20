/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using Moq;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class RemoveAll : ListBase<string>
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<string> { "as", "bs", "c" };
            Assert.AreEqual(2, listBase.RemoveAll(EndsWiths));
            Assert.AreEqual("c", listBase[0]);
            Assert.AreEqual(1, listBase.Count);
        }


        [Test]
        public void EnsureRemoveItem()
        {
            var listBase = new Mock<RemoveAll>();

            listBase.Object.Add("as");
            listBase.Object.Add("bs");
            listBase.Object.Add("c");
            listBase.Object.RemoveAll(EndsWiths);

            listBase.Verify(x => x.RemoveItem(0, "as"));
            listBase.Verify(x => RemoveItem(0, "bs"));
        }

        private static bool EndsWiths(string s)
        {
            return s.EndsWith("s");
        }

    }
}