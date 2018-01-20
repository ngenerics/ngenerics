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
    public class PrivateConstruction : SingletonTest
    {

        private class InstanceWithPrivateConstructor
        {
            public int val;

            private InstanceWithPrivateConstructor()
            {
                val = 15;
            }
        }


        [OneTimeSetUp]
        public void SetupSingleton()
        {
            var type = typeof(InstanceWithPrivateConstructor);
            var ctor = TypeExtensions.New<InstanceWithPrivateConstructor>(type);
            Singleton<InstanceWithPrivateConstructor>.ConstructWith = () => ctor();
        }

        [Test]
        public void Call_Private_Generic_New_Constructor()
        {
            Assert.AreEqual(Singleton<InstanceWithPrivateConstructor>.Instance.val, 15);
        }
    }
}