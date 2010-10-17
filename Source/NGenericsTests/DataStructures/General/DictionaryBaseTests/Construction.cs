/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.DictionaryBaseTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            new MockStringDictionary();
        }

        [Test]
        public void Capacity()
        {
            new MockStringDictionary(1);
        }

        [Test]
        public void CapacityComparer()
        {
            var target = new MockStringDictionary(1, StringComparer.InvariantCultureIgnoreCase);
            Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase, target.Comparer);
        }

        [Test]
        public void DictionaryCompare()
        {
            var dictionary = new Dictionary<string, string> { { "a", "a" } };
            var target =
                new MockStringDictionary(dictionary, StringComparer.InvariantCultureIgnoreCase);
            Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase, target.Comparer);
            Assert.AreEqual(1, target.Count);
        }

        [Test]
        public void Dictionary()
        {
            var dictionary = new Dictionary<string, string> { { "a", "a" } };
            var target = new MockStringDictionary(dictionary);
            Assert.AreEqual(1, target.Count);
        }
    }
}