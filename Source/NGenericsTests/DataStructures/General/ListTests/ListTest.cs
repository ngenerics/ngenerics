/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NGenerics.DataStructures.General;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    public class ListTest
    {
        public static ListBase<int> GetTestList()
        {
            var visitableList = new ListBase<int>(5);

            for (var i = 0; i < 5; i++)
            {
                visitableList.Add(i * 3);
            }

            return visitableList;
        }

    }


    [TestFixture]
        public class Serializable
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int>();

                for (var i = 0; i < 100; i++)
                {
                    listBase.Add(i);
                }

                for (var i = 200; i >= 100; i--)
                {
                    listBase.Add(i);
                }

                var newList = SerializeUtil.BinarySerializeDeserialize(listBase);

                for (var i = 0; i < 100; i++)
                {
                    Assert.AreEqual(newList[i], i);
                }

                var counter = 100;

                for (var i = 200; i >= 100; i--)
                {
                    Assert.AreEqual(newList[counter], i);
                    counter++;
                }
            }
        }

}
