/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/



using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.General
{
    [TestFixture]
    public class AssociationExamples
    {

        #region Constructor
        public void ConstructorExample()
        {
            // Create a new association
            var association = new Association<int, string>(4, "four");

            // Key will be equal to 4
            Assert.AreEqual(association.Key, 4);

            // Value will be equal to "four"
            Assert.AreEqual(association.Value, "four");
        }
        #endregion

        #region Key
        [Test]
        public void KeyExample()
        {
            var association = new Association<int, string>(1, "monkey");

            // The key's value will be 1.
            Assert.AreEqual(association.Key, 1);

            // Set the key's value to 3.
            association.Key = 3;

            // The key's value will be 3.
            Assert.AreEqual(association.Key, 3);
        }
        #endregion

        #region Value
        [Test]
        public void ValueExample()
        {
            var association = new Association<int, string>(1, "dove"); 

            // The value will be "dove".
            Assert.AreEqual(association.Value, "dove");

            // Set the value to "monkey".
            association.Value = "monkey";

            // The value will be "monkey".
            Assert.AreEqual(association.Value, "monkey");
        }
        #endregion

        #region ToKeyValuePair
        [Test]
        public void ToKeyValuePairExample()
        {
            var association = new Association<int, string>(1, "dove");

            var pair = association.ToKeyValuePair();

            // The value and key will be the same as in the association.
            Assert.AreEqual(pair.Key, association.Key);
            Assert.AreEqual(pair.Value, association.Value);
        }
        #endregion
    }
}