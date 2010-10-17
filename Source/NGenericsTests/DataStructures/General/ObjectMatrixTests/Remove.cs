/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Remove:ObjectMatrixTest
    {
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ExceptionInterfaceNotSupported()
        {
            var matrix = GetTestMatrix();
            ((ICollection<int>) matrix).Remove(5);
        }
    }
}