/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.HashListTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            var hashList = new HashList<string, int>();

            Assert.AreEqual(hashList.Count, 0);

            var dictionary = new Dictionary<string, IList<int>>
                                 {
                                     {"aa", new List<int>()},
                                     {"bb", new List<int>()},
                                     {"cc", new List<int>()}
                                 };

            dictionary["bb"].Add(5);
            dictionary["bb"].Add(6);
            dictionary["cc"].Add(2);

            hashList = new HashList<string, int>(dictionary);

            Assert.AreEqual(hashList.Count, 3);
            Assert.AreEqual(hashList.ValueCount, 3);

            Assert.AreEqual(hashList["aa"].Count, 0);
            Assert.AreEqual(hashList["bb"].Count, 2);
            Assert.AreEqual(hashList["cc"].Count, 1);

            Assert.AreEqual(hashList["bb"][0], 5);
            Assert.AreEqual(hashList["bb"][1], 6);
            Assert.AreEqual(hashList["cc"][0], 2);

            hashList = new HashList<string, int>(50);

            Assert.AreEqual(hashList.Count, 0);
            Assert.AreEqual(hashList.ValueCount, 0);

            hashList = new HashList<string, int>(EqualityComparer<string>.Default);

            Assert.AreEqual(hashList.Count, 0);
            Assert.AreEqual(hashList.ValueCount, 0);

            hashList = new HashList<string, int>(20, EqualityComparer<string>.Default);

            Assert.AreEqual(hashList.Count, 0);
            Assert.AreEqual(hashList.ValueCount, 0);
        }
    }
}