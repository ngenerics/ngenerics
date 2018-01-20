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
    public class AssignConstructWith : SingletonTest
    {
        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<float>.ConstructWith = () => 7;
            Singleton<float>.ConstructWith = () => 15;
        }

        [Test]
        public void ConstructWith_Assigned_Once()
        {
            Assert.AreEqual(Singleton<float>.Instance, 7);
        }
    }
}