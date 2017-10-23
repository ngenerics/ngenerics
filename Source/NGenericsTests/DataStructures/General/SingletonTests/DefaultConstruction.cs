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
    public class DefaultConstruction : SingletonTest
    {
        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            var temp = Singleton<int>.Instance;
            Singleton<int>.ConstructWith = () => temp + 88;
        }

        [Test]
        public void ConstructWith_Should_Be_Called_Before_Instance_Get()
        {
            Assert.AreEqual(Singleton<long>.Instance, 0);
        }
    }
}