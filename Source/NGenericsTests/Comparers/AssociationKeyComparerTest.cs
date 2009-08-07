/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using NGenerics.Comparers;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers
{
    [TestFixture]
    public class AssociationKeyComparerTest
    {
        [TestFixture]
        public class Construction
        {
            [Test]
			public void Simple()
            {
                new AssociationKeyComparer<int, string>();
            }
        }
                
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
}
