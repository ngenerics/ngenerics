/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using NGenerics.DataStructures.General;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{
	[TestFixture]
	public class AssociationTest
    {
        [TestFixture]
        public class Construction
        {

            [Test]
			public void Simple()
            {
                var assoc = new Association<int, string>(5, "aa");

                Assert.AreEqual(assoc.Key, 5);
                Assert.AreEqual(assoc.Value, "aa");
            }

        }

        [TestFixture]
        public class Value
        {

            [Test]
			public void Simple()
            {
                var assoc = new Association<int, string>(5, "aa");

                Assert.AreEqual(assoc.Value, "aa");

                assoc.Value = "bla";

                Assert.AreEqual(assoc.Value, "bla");
            }

        }
           
        [TestFixture]
        public class Key
        {
            [Test]
			public void Simple()
            {
                var assoc = new Association<int, string>(5, "aa");

                Assert.AreEqual(assoc.Key, 5);

                assoc.Key = 2;

                Assert.AreEqual(assoc.Key, 2);
            }

        }

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
                Assert.AreNotEqual(assoc, newAssoc);
            }

        }
    }
}
