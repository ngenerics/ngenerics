using System;
using NGenerics.DataStructures.General;

namespace NGenerics.Tests.DataStructures.General.DictionaryBaseTests
{
    internal class MockExceptionDictionary : DictionaryBase<int, int>
    {
        protected override void AddItem(int key, int value)
        {
            throw new Exception("AddItem");
        }


        protected override bool RemoveItem(int key)
        {
            throw new Exception("RemoveItem");
        }


        protected override void ClearItems()
        {
            throw new Exception("ClearItems");
        }


        protected override void SetItem(int key, int value)
        {
            throw new Exception("SetItem");
        }

    }
}