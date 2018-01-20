/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;

namespace NGenerics.DataStructures.General
{
    /// <summary>
	/// The Association performs the same function as a <see cref="KeyValuePair{TKey,TValue}"/>, but allows the 
    /// Value members to be written to.
    /// It is serializable and implemented as class, whereas KeyValuePair is struct.
    /// </summary>
    /// <typeparam name="TKey">The type of the key for the association.</typeparam>
	/// <typeparam name="TValue">The type of the value for the association.</typeparam>
    [Serializable]
    public class Association<TKey, TValue> 
	{
		#region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Association{TKey,TValue}"/> class.
        /// </summary>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\AssociationExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the constructor."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\AssociationExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the constructor."/>
        /// </example>
        public Association() 
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Association{TKey,TValue}"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\AssociationExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the constructor."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\AssociationExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the constructor."/>
        /// </example>
		public Association(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Association{TKey,TValue}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\AssociationExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the constructor."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\AssociationExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the constructor."/>
        /// </example>
        public Association(KeyValuePair<TKey,TValue> value)
        {
            Key = value.Key;
            Value = value.Value;
        }

		#endregion

		#region Public Members

		/// <summary>
		/// Gets the key.
		/// </summary>
		/// <value>The key.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\AssociationExamples.cs" region="Key" lang="cs" title="The following example shows how to use the Key property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\AssociationExamples.vb" region="Key" lang="vbnet" title="The following example shows how to use the Key property."/>
        /// </example>
		public TKey Key{get;set;}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\AssociationExamples.cs" region="Value" lang="cs" title="The following example shows how to use the Value property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\AssociationExamples.vb" region="Value" lang="vbnet" title="The following example shows how to use the Value property."/>
        /// </example>
		public TValue Value{get;set;}

        /// <summary>
        /// Construct a <see cref="KeyValuePair{TKey,TValue}"/> object from the current values.
        /// </summary>
        /// <returns>A key value pair representation of this <see cref="Association{TKey,TValue}"/>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\AssociationExamples.cs" region="ToKeyValuePair" lang="cs" title="The following example shows how to use the ToKeyValuePair method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\AssociationExamples.vb" region="ToKeyValuePair" lang="vbnet" title="The following example shows how to use the ToKeyValuePair method."/>
        /// </example>
        public KeyValuePair<TKey, TValue> ToKeyValuePair()
        {
            return new KeyValuePair<TKey, TValue>(Key, Value);
        }

		#endregion

        #region Object Members

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0} : {1}", Key, Value);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            var association = obj as Association<TKey, TValue>;
            if (association == null)
            {
                return false;
            }
            return Key.Equals(association.Key) && Value.Equals(association.Value);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (Equals(Key, default(TKey)) ? 0 : Key.GetHashCode()) + (Equals(Value, default(TValue)) ? 0 : Value.GetHashCode()) * 37;
        }

        #endregion
    }
}
