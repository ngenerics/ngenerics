using System;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableGeneralTreeTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var generalTree = new ObservableGeneralTree<string>("root")
                                  {
                                      "foo"
                                  };
            ObservableCollectionTester.ExpectEvents(generalTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var generalTree = new ObservableGeneralTree<string>("root")
                                  {
                                      "foo"
                                  };
            new ReentracyTester<ObservableGeneralTree<string>>(generalTree, obj => obj.Clear());
        }
    }
}