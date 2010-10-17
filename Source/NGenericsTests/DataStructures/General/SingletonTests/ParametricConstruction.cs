/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class ParametricConstruction : SingletonTest
    {

        private class InstanceWithParametricConstructor
        {
            public int val;

            private InstanceWithParametricConstructor(int value)
            {
                val = value;
            }
        }

        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            var type = typeof(InstanceWithParametricConstructor);
            var ctor = TypeExtensions.New<int, InstanceWithParametricConstructor>(type);
            Singleton<InstanceWithParametricConstructor>.ConstructWith = () => ctor(7);
        }

        [Test]
        public void Call_Generic_Parametric_New_Constructor()
        {
            Assert.AreEqual(Singleton<InstanceWithParametricConstructor>.Instance.val, 7);
        }
    }
}