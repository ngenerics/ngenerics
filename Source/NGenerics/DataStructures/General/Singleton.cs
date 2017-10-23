/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// A generic Singleton pattern implementation.
    /// </summary>
    /// <typeparam name="T">The type of object to create a single instance of.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SingletonExamples.cs" region="Singleton" lang="cs" title="The following example shows how to use the Instance method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SingletonExamples.vb" region="Singleton" lang="vbnet" title="The following example shows how to use the Instance method."/>
    /// </example>
    public static class Singleton<T>
    {
        #region Delegates

        /// <summary>
        /// A custom delegate for the creation of objects.  Used instead of Func for backwards compatibility with .NET 2.
        /// </summary>
        public delegate T FactoryDelegate();

        #endregion

        #region Globals

        private static FactoryDelegate createInstance = Activator.CreateInstance<T>;

        #endregion

        #region Public Members

        /// <summary>
        /// Sets a method of construction of the value of this singleton.
        /// </summary>
        /// <value>The construct with.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SingletonExamples.cs" region="ConstructWith" lang="cs" title="The following example shows how to use the ConstructWith property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SingletonExamples.vb" region="ConstructWith" lang="vbnet" title="The following example shows how to use the ConstructWith property."/>
        /// </example>
        public static FactoryDelegate ConstructWith
        {
            set
            {
                if (value != null)
                {
                    createInstance = value;
                    RuntimeHelpers.RunClassConstructor(typeof(Container).TypeHandle);
                }
            }
        }


        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SingletonExamples.cs" region="Singleton" lang="cs" title="The following example shows how to use the Instance method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SingletonExamples.vb" region="Singleton" lang="vbnet" title="The following example shows how to use the Instance method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static T Instance
        {
            get
            {
                return Container.Instance;
            }
        }

        #endregion

        #region Nested type: Container

        /// <summary>
        /// Internal container class fo the actual value - needed so that the CLR
        /// can guarantee thread safety.
        /// </summary>
        private static class Container
        {
            internal static readonly T Instance = createInstance();
        }

        #endregion

    }
}
