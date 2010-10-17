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
    public class Add
    {
        [Test]
        public void Interface()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString());
            ICollection<int> collection = target;
            collection.Add(1);
            Assert.IsTrue(target.Contains(1));
        }
    }
}