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