/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Reflection;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.PriorityQueueTests
{

    [TestFixture]
    public class Construction
    {

        private static readonly Type priorityQueueType = typeof(PriorityQueue<int, int>);
        private static readonly Type priorityQueueTypeType = typeof(PriorityQueueType);


        [Test]
        public void Construction1InvalidPriorityQueueType()
        {
            Exception argException = null;
            try
            {
                var constructor = priorityQueueType.GetConstructor(new[] { priorityQueueTypeType });
                constructor.Invoke(new object[] { -1 });
            }
            catch (TargetInvocationException e)
            {
                argException = e.InnerException;
            }
            Assert.IsNotNull(argException);
        }
    }






}
