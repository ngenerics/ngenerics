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
    public class NewConstruction : SingletonTest
    {

        private class InstanceWithDefaultConstructor
        {
            public int val;

            public InstanceWithDefaultConstructor()
            {
                val = 15;
            }
        }


        private static T Construct<T>()
            where T : new()
        {
            // new T() is equal to Activator.CreateInstance<T>
            return new T();
        }


        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<InstanceWithDefaultConstructor>.ConstructWith =
                () =>
                    {
                        var instance = Construct<InstanceWithDefaultConstructor>();
                        if (instance != null)
                            instance.val = 99;
                        return instance;
                    };
        }

        [Test]
        public void Call_New_Constructor()
        {
            Assert.AreEqual(Singleton<InstanceWithDefaultConstructor>.Instance.val, 99);
        }
    }
}