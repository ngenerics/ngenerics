/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Contains : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = new Bag<string> { "aa" };

            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 1);

            bag.Add("bb");
            Assert.IsTrue(bag.Contains("bb"));
            Assert.AreEqual(bag["aa"], 1);
            Assert.AreEqual(bag["bb"], 1);

            bag.Add("aa");
            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 2);
            Assert.AreEqual(bag["bb"], 1);

            bag.Add("cc", 3);
            Assert.IsTrue(bag.Contains("cc"));
            Assert.AreEqual(bag["aa"], 2);
            Assert.AreEqual(bag["bb"], 1);
            Assert.AreEqual(bag["cc"], 3);
        }
    }
}