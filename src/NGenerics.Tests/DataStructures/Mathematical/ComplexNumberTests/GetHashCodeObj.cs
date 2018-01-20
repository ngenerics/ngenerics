/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class GetHashCodeObj
    {

        [Test]
        public void Simple()
        {
            var dictionary = new Dictionary<ComplexNumber, string>();

            for (var i = -100; i < 100; i++)
            {
                for (var j = -100; j < 100; j++)
                {
                    // Test uniqueness of hash code
                    var complexNumber = new ComplexNumber(i, j);
                    Assert.IsFalse(dictionary.ContainsKey(complexNumber));

                    dictionary.Add(complexNumber, null);
                }
            }
        }

    }
}