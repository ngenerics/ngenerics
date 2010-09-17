/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;
using Rhino.Mocks;
using System.Threading;
using System.Collections.Generic;

namespace NGenerics.Tests.DataStructures.General.SingletonTest
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    
    public class SingletonTest
    {
        #region Private Members

        internal class TestInstance
        {
            public int val;
        }

        internal static class TypeExtensions
        {
            public static Func<TResult> New<TResult>(Type type)
            {
                return GetConstructor<Func<TResult>>(type); // Type.EmptyTypes
            }

            public static Func<T, TResult> New<T, TResult>(Type type)
            {
                return GetConstructor<Func<T, TResult>>(type, typeof(T));
            }


            internal static TDelegate GetConstructor<TDelegate>(Type type, params Type[] argumentTypes)
            {
                var constructor = type.GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, argumentTypes, null);
                if (null == constructor)
                    throw new InvalidOperationException(
                        string.Format("Has no constructor {0}({1})", type,
                            string.Join(", ",
                                argumentTypes.Select(arg => Convert.ToString(arg)).ToArray())));
                var parameters = argumentTypes.Select((arg, index) => Expression.Parameter(arg, "arg" + index)).ToArray();
                return Expression.Lambda<TDelegate>(Expression.New(constructor, parameters), parameters).Compile();
            }
        }

        #endregion
    }
    #region Tests

    [TestFixture]
    public class Construction : SingletonTest
    {
        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<TestInstance>.Instance.val = 5;
        }

        [Test]
        public void Simple()
        {
            Assert.AreEqual(Singleton<TestInstance>.Instance.val, 5);
        }
    }

    [TestFixture]
    public class DefaultConstruction : SingletonTest
    {
        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            var temp = Singleton<int>.Instance;
            Singleton<int>.ConstructWith = () => temp + 88;
        }

        [Test]
        public void ConstructWith_Should_Be_Called_Before_Instance_Get()
        {
            Assert.AreEqual(Singleton<long>.Instance, 0);
        }
    }

    [TestFixture]
    public class AssignConstructWith : SingletonTest
    {
        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<float>.ConstructWith = () => 7;
            Singleton<float>.ConstructWith = () => 15;
        }

        [Test]
        public void ConstructWith_Assigned_Once()
        {
            Assert.AreEqual(Singleton<float>.Instance, 7);
        }
    }

    [TestFixture]
    public class NewConstruction : SingletonTest
    {
        #region Instance class

        private class InstanceWithDefaultConstructor
        {
            public int val;

            public InstanceWithDefaultConstructor()
            {
                val = 15;
            }
        }

        #endregion

        #region ConstructWith Method

        private static T Construct<T>()
                where T : new()
        {
            // new T() is equal to Activator.CreateInstance<T>
            return new T();
        }

        #endregion

        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<InstanceWithDefaultConstructor>.ConstructWith =
                () =>
                {
                    var instance = Construct<InstanceWithDefaultConstructor>();
                    if (instance != null)
                        instance.val = 99;
                    return instance;
                };
        }

        [Test]
        public void Call_New_Constructor()
        {
            Assert.AreEqual(Singleton<InstanceWithDefaultConstructor>.Instance.val, 99);
        }
    }

    [TestFixture]
    public class ReflectionConstruction : SingletonTest
    {
        #region Instance class

        private class InstanceWithReflectionConstructor
        {
            public int val;

            public InstanceWithReflectionConstructor(int value, int increment)
            {
                val = value + increment;
            }
        }

        #endregion

        #region ConstructWith Method

        private static T Construct<T>(int value, int increment)
        {
            return (T)typeof(T).InvokeMember(typeof(T).Name,
                    BindingFlags.CreateInstance |
                    BindingFlags.Instance |
                    BindingFlags.Public,
                    null, null, new object[] { value, increment });
        }

        #endregion

        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<InstanceWithReflectionConstructor>.ConstructWith =
                () => Construct<InstanceWithReflectionConstructor>(7, 13);
        }

        [Test]
        public void Call_Reflection_Constructor_With_Parameters()
        {
            Assert.AreEqual(Singleton<InstanceWithReflectionConstructor>.Instance.val, 20);
        }
    }

    [TestFixture]
    public class ActivatorConstruction : SingletonTest
    {
        #region Instance class

        private class InstanceWithActivatorConstructor
        {
            public int val;

            public InstanceWithActivatorConstructor(int value, int increment)
            {
                val = value + increment;
            }
        }

        #endregion

        #region ConstructWith Method

        private static T Construct<T>(int value, int increment)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { value, increment });
        }

        #endregion

        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<InstanceWithActivatorConstructor>.ConstructWith =
                () => Construct<InstanceWithActivatorConstructor>(57, 13);
        }

        [Test]
        public void Call_Activator_Constructor_With_Parameters()
        {
            Assert.AreEqual(Singleton<InstanceWithActivatorConstructor>.Instance.val, 70);
        }
    }

    [TestFixture]
    public class PrivateConstruction : SingletonTest
    {
        #region Instance class

        private class InstanceWithPrivateConstructor
        {
            public int val;

            private InstanceWithPrivateConstructor()
            {
                val = 15;
            }
        }

        #endregion

        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            var type = typeof(InstanceWithPrivateConstructor);
            var ctor = TypeExtensions.New<InstanceWithPrivateConstructor>(type);
            Singleton<InstanceWithPrivateConstructor>.ConstructWith = () => ctor();
        }

        [Test]
        public void Call_Private_Generic_New_Constructor()
        {
            Assert.AreEqual(Singleton<InstanceWithPrivateConstructor>.Instance.val, 15);
        }
    }

    [TestFixture]
    public class ParametricConstruction : SingletonTest
    {
        #region Instance class

        private class InstanceWithParametricConstructor
        {
            public int val;

            private InstanceWithParametricConstructor(int value)
            {
                val = value;
            }
        }

        #endregion

        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            var type = typeof(InstanceWithParametricConstructor);
            var ctor = TypeExtensions.New<int, InstanceWithParametricConstructor>(type);
            Singleton<InstanceWithParametricConstructor>.ConstructWith = () => ctor(7);
        }

        [Test]
        public void Call_Generic_Parametric_New_Constructor()
        {
            Assert.AreEqual(Singleton<InstanceWithParametricConstructor>.Instance.val, 7);
        }
    }

    [TestFixture]
    public class ConstructWith : SingletonTest
    {
        public interface ISimpleFactory<T>
        {
            T Construct();
        }

        [Test]
        public void Construction_Delegate_Should_Only_Be_Called_Once()
        {
            var mocks = new MockRepository();
            var factory = mocks.StrictMock<ISimpleFactory<int>>();
            Expect.Call(factory.Construct()).Return(43);

            mocks.ReplayAll();

            Singleton<int>.ConstructWith = factory.Construct;

            var threads = new List<Thread>();

            for (var i = 0; i < 20; i++)
            {
                var thread = new Thread(() => Assert.IsTrue(Singleton<int>.Instance == 43));
                threads.Add(thread);
                thread.Start();
            }

            for (var i = 0; i < 20; i++)
            {
                threads[i].Join();
            }

            mocks.VerifyAll();
        }
    }

    #endregion

}
