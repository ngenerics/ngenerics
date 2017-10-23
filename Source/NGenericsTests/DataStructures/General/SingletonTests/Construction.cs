/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class Construction : SingletonTest
    {
        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<TestInstance>.Instance.val = 5;
        }

        [Test]
        public void Simple()
        {
            Assert.AreEqual(Singleton<TestInstance>.Instance.val, 5);
        }
    }
}