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

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 3 };
            ICollection<int> collection = target;
            Assert.IsTrue(collection.Remove(3));
            Assert.IsFalse(target.ContainsKey("3"));
            Assert.IsFalse(collection.Remove(3));
        }

        [Test]
        public void NonExisting()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 1 };
            ICollection<int> collection = target;
            Assert.IsFalse(collection.Remove(2));
        }
    }
}