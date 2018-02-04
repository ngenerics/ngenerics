/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Util.GuardTests
{
    [TestFixture]
    public class ArgumentNotNull
    {
        [Test]
        public void ExceptionParameterNull()
        {
            try
            {
                const object tmp = null;
                Guard.ArgumentNotNull(tmp, nameof(tmp));
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("tmp", ex.ParamName);
            }
        }

        [Test]
        public void ParameterNotNull()
        {
            var tmp = new object();
            // Should not throw an exception
            Guard.ArgumentNotNull(tmp, "tmp");
        }
    }
}