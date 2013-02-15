/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Clear : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = GetTestBag();

            bag.Clear();
            Assert.AreEqual(bag.Count, 0);
            Assert.IsTrue(bag.IsEmpty);

            bag.Add("aa");
            bag.Clear();

            Assert.AreEqual(bag.Count, 0);
            Assert.IsTrue(bag.IsEmpty);
        }
    }
}