/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.Tests.DataStructures.General.DictionaryBaseTests
{
    internal class MockStringDictionary : DictionaryBase<string, string>
    {
        public MockStringDictionary()
        {
        }


        public MockStringDictionary(IDictionary<string, string> dictionary)
            : base(dictionary)
        {
        }


        public MockStringDictionary(IEqualityComparer<string> comparer)
            : base(comparer)
        {
        }


        public MockStringDictionary(int capacity)
            : base(capacity)
        {
        }


        public MockStringDictionary(IDictionary<string, string> dictionary, IEqualityComparer<string> comparer)
            : base(dictionary, comparer)
        {
        }


        public MockStringDictionary(int capacity, IEqualityComparer<string> comparer)
            : base(capacity, comparer)
        {
        }

    }
}