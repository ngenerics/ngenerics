/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System;
using System.Reflection;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues
{
	[TestFixture]
    public class PriorityQueueTest
    {
        #region Globals

        private static readonly Type priorityQueueType = typeof(PriorityQueue<int, int>);
        private static readonly Type priorityQueueTypeType = typeof(PriorityQueueType);

        #endregion

        #region Tests

        [TestFixture]
        public class Construction
        {
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

        #endregion

    }
}
