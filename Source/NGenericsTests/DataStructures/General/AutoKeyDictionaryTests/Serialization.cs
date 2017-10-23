/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class Serialization
    {
        [Test]
        public void DataContractSerializer()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2 };
            ICollection<int> collection = target;
            Assert.IsTrue(collection.Contains(2));
            Assert.IsFalse(collection.Contains(1));
            Assert.IsFalse(collection.Contains(3));
        }
    }
}