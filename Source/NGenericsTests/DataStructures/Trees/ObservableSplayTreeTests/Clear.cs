using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableSplayTreeTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            var splayTree = new ObservableSplayTree<string, string>
                                {
                                    keyValuePair
                                };
            ObservableCollectionTester.ExpectEvents(splayTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            var splayTree = new ObservableSplayTree<string, string>
                                {
                                    keyValuePair
                                };
            new ReentracyTester<ObservableSplayTree<string, string>>(splayTree, obj => obj.Clear());
        }
    }
}