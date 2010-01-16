/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.General
{
    #region Singleton
    [TestFixture]
    public class SingletonExamples
    {
        public SingletonExamples()
        {
            //get the singleton and set its data to 5;
            Singleton<MyExampleSingleton>.Instance.Data = 5;
        }

        [Test]
        public void RunExample()
        {
            // get two instances of MyExampleSingleton
            var singleton1 = Singleton<MyExampleSingleton>.Instance;
            var singleton2 = Singleton<MyExampleSingleton>.Instance;

            // Both will point to the same instance
            Assert.IsTrue(ReferenceEquals(singleton1, singleton2));

            // Both will have a data value of 5
            Assert.AreEqual(5, singleton1.Data);
            Assert.AreEqual(5, singleton2.Data);
        }
    }

    public class MyExampleSingleton
    {
        public int Data { get; set; }
    }
    #endregion

    #region ConstructWith
    [TestFixture]
    public class ConstructWithSingletonExample
    {
        public ConstructWithSingletonExample()
        {
            // Add the construction method for the singleton.
            Singleton<SimpleClass>.ConstructWith = () => new SimpleFactory().ProvideValue();
        }

        [Test]
        public void RunExample()
        {
            // get two instances of SimpleClass
            var singleton1 = Singleton<SimpleClass>.Instance;
            var singleton2 = Singleton<SimpleClass>.Instance;

            // Both will point to the same instance
            Assert.IsTrue(ReferenceEquals(singleton1, singleton2));

            // Both will have a data value of 5
            Assert.AreEqual(2, singleton1.Data);
            Assert.AreEqual(2, singleton2.Data);
        }
    }

    public class SimpleClass
    {
        public int Data {get; set;}
    }

    public class SimpleFactory
    {
        public SimpleClass ProvideValue()
        {
            return new SimpleClass
                       {
                           Data = 2
                       };
        }
    }
    #endregion
}