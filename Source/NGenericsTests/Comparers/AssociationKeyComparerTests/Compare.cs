/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.Comparers;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.AssociationKeyComparerTests
{
    [TestFixture]
    public class Compare
    {
        [Test]
        public void Simple()
        {
            var associationKeyComparer = new AssociationKeyComparer<int, string>();

            var association1 = new Association<int, string>(5, "5");
            var association2 = new Association<int, string>(5, "6");
            var association3 = new Association<int, string>(3, "5");
            var association4 = new Association<int, string>(5, "5");

            Assert.AreEqual(associationKeyComparer.Compare(association1, association2), 0);
            Assert.AreEqual(associationKeyComparer.Compare(association1, association3), 1);
            Assert.AreEqual(associationKeyComparer.Compare(association1, association4), 0);

            Assert.AreEqual(associationKeyComparer.Compare(association2, association1), 0);
            Assert.AreEqual(associationKeyComparer.Compare(association3, association1), -1);
            Assert.AreEqual(associationKeyComparer.Compare(association4, association1), 0);
        }
    }
}
