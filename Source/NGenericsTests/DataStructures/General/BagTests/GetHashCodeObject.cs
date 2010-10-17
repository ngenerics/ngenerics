/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class GetHashCodeObject : BagTest
    {

        [Test]
        public void Simple()
        {
            var dictionary = new Dictionary<Bag<string>, string>();

            for (var i = 0; i < dictionary.Count; i++)
            {
                var bag = GetTestBag();

                bag.GetHashCode();

                Assert.IsFalse(dictionary.ContainsKey(bag));

                dictionary.Add(bag, null);
            }
        }

    }
}