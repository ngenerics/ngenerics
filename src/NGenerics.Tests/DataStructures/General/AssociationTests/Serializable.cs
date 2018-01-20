/*  
 Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.DataStructures.General;
using NGenerics.Extensions;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AssociationTests
{
    [TestFixture]
    public class Serializable
    {

        [Test]
        public void Simple()
        {
            var assoc = new Association<int, string>(5, "aa");
            var newAssoc = SerializeUtil.BinarySerializeDeserialize(assoc);

            Assert.AreEqual(assoc.Key, newAssoc.Key);
            Assert.AreEqual(assoc.Value, newAssoc.Value);
            Assert.AreNotSame(assoc, newAssoc);
        }

        [Test]
        public void XmlSimple()
        {
            var assoc = new Association<int, string>(5, "aa");
            var serialize = assoc.Serialize();
            var newAssoc = ObjectExtensions.Deserialize<Association<int, string>>(serialize);

            Assert.AreEqual(assoc.Key, newAssoc.Key);
            Assert.AreEqual(assoc.Value, newAssoc.Value);
            Assert.AreEqual(assoc, newAssoc);
        }
    }
}
