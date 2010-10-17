/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using System.Threading;
using NGenerics.DataStructures.General;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class ConstructWith : SingletonTest
    {
        public interface ISimpleFactory<T>
        {
            T Construct();
        }

        [Test]
        public void Construction_Delegate_Should_Only_Be_Called_Once()
        {
            var mocks = new MockRepository();
            var factory = mocks.StrictMock<ISimpleFactory<int>>();
            Expect.Call(factory.Construct()).Return(43);

            mocks.ReplayAll();

            Singleton<int>.ConstructWith = factory.Construct;

            var threads = new List<Thread>();

            for (var i = 0; i < 20; i++)
            {
                var thread = new Thread(() => Assert.IsTrue(Singleton<int>.Instance == 43));
                threads.Add(thread);
                thread.Start();
            }

            for (var i = 0; i < 20; i++)
            {
                threads[i].Join();
            }

            mocks.VerifyAll();
        }
    }
}