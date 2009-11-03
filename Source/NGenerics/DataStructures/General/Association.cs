/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


#if (!SILVERLIGHT)
using System;
#endif
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
#if (!SILVERLIGHT)
    [Serializable]
#endif
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
		public TKey Key
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\AssociationExamples.cs" region="Value" lang="cs" title="The following example shows how to use the Value property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\AssociationExamples.vb" region="Value" lang="vbnet" title="The following example shows how to use the Value property."/>
        /// </example>
		public TValue Value
		{
			get;
			set;
		}

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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (Object.ReferenceEquals(obj, this))
                return true;
            if (!(obj is Association<TKey, TValue>))
                return false;
            var that = (Association<TKey, TValue>)obj;
            return
                this.Key.Equals(that.Key) &&
                this.Value.Equals(that.Value);
        }

        public override int GetHashCode()
        {
            return (Key.Equals(default(TKey)) ? 0 : Key.GetHashCode()) + (Value.Equals(default(TValue)) ? 0 : Value.GetHashCode()) * 37;
        }
        #endregion
    }
}
