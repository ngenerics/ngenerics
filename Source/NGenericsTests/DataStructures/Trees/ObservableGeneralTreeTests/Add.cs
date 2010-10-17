using System;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableGeneralTreeTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var generalTree = new ObservableGeneralTree<string>("root");
            ObservableCollectionTester.ExpectEvents(generalTree, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var generalTree = new ObservableGeneralTree<string>("root");
            new ReentracyTester<ObservableGeneralTree<string>>(generalTree, obj => obj.Add("foo"));
        }

    }
}