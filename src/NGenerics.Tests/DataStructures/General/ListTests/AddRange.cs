/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class AddRange : ListBase<int>
    {
        [Test]
        public void Simple()
        {

            var listBase = new ListBase<int>(); 
            listBase.AddRange(new []{3});
            Assert.IsTrue(listBase.Contains(3));
        }
        [Test]
        public void SimpleEnsureInsertItemCall()
        {
            var collection = new[] { 3 };
            var mockRepository = new MockRepository();
            var listBase = mockRepository.StrictMock<AddRange>();
            listBase.AddRangeItems(collection);
            mockRepository.ReplayAll();
            listBase.AddRange(collection);
            mockRepository.VerifyAll();
        }

    }
}