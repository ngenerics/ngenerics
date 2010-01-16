/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Diagnostics;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.General
{
    [TestFixture]
    public class HashListExamples
    {


        #region Add

        [Test]
        public void AddExample()
        {
            var whatAnimalEatHashList = new HashList<string, string>();
            whatAnimalEatHashList.Add("cat", "milk");
            whatAnimalEatHashList.Add("cat", "fish");
            whatAnimalEatHashList.Add("dog", "dog food");
            whatAnimalEatHashList.Add("dog", "bones");
            whatAnimalEatHashList.Add("tiger", "people");
            // There should be 3 items.
            Assert.AreEqual(3, whatAnimalEatHashList.Count);
        }

        #endregion


        #region AddParams

        [Test]
        public void AddParamsExample()
        {
            var whatAnimalEatHashList = new HashList<string, string>();
            whatAnimalEatHashList.Add("cat", "milk", "fish");
            whatAnimalEatHashList.Add("dog", "dog food", "bones");
            whatAnimalEatHashList.Add("tiger", "people");

            // There are 3 keys.
            Assert.AreEqual(3, whatAnimalEatHashList.KeyCount);

            // There are 5 values.
            Assert.AreEqual(5, whatAnimalEatHashList.ValueCount);
        }

        #endregion




        #region Constructor

        [Test]
        public void ConstructorExample()
        {
        	var whatAnimalEatHashList = new HashList<string, string>
        	                            	{
        	                            		{"cat", "milk"},
        	                            		{"cat", "fish"},
        	                            		{"dog", "dog food"},
        	                            		{"dog", "bones"},
        	                            		{"tiger", "people"}
        	                            	};
        }

    	#endregion


        #region ConstructorCapacity

		[Test]
		public void ConstructorCapacityExample()
		{
			// If you know how many items will initially be in the HashList it is 
			// more efficient to set the initial capacity
			var whatAnimalEatHashList = new HashList<string, string>(3)
			                            	{
			                            		{"cat", "milk"},
			                            		{"cat", "fish"},
			                            		{"dog", "dog food"},
			                            		{"dog", "bones"},
			                            		{"tiger", "people"}
			                            	};
		}

    	#endregion


        #region ConstructorComparer

        [Test]
        public void ConstructorComparerExample()
        {
        	var whatAnimalEatHashListIgnoreCase = new HashList<string, string>(StringComparer.OrdinalIgnoreCase)
        	                                      	{
        	                                      		{"cat", "milk"},
        	                                      		{"CAT", "fish"}
        	                                      	};

        	// KeyCount is 1 because case is ignored
        	Assert.AreEqual(1, whatAnimalEatHashListIgnoreCase.KeyCount);


        	var whatAnimalEatHashListUseCase = new HashList<string, string>(StringComparer.Ordinal)
        	                                   	{
        	                                   		{"cat", "milk"},
        	                                   		{"CAT", "fish"}
        	                                   	};

        	// KeyCount is 2 because case is not ignored
        	Assert.AreEqual(2, whatAnimalEatHashListUseCase.KeyCount);
        }

    	#endregion

        #region GetValueEnumerator

		[Test]
		public void GetValueEnumeratorExample()
		{
			var whatAnimalEatHashList = new HashList<string, string>
			                            	{
			                            		{"cat", "milk"},
			                            		{"cat", "fish"},
			                            		{"dog", "dog food"},
			                            		{"dog", "bones"},
			                            		{"tiger", "people"}
			                            	};

			// Get the enumerator and iterate through all 5 values.
			var enumerator = whatAnimalEatHashList.GetValueEnumerator();
			while (enumerator.MoveNext())
			{
				Debug.WriteLine(enumerator.Current);
			}
		}

    	#endregion


    

        #region KeyCount

        [Test]
        public void KeyCountExample()
        {
        	var whatAnimalEatHashList = new HashList<string, string>
        	                            	{
        	                            		{"cat", "milk", "fish"},
        	                            		{"dog", "dog food", "bones"},
        	                            		{"tiger", "people"}
        	                            	};

        	// There are 4 keys.
        	Assert.AreEqual(3, whatAnimalEatHashList.KeyCount);
        }

    	#endregion

        #region Remove

        [Test]
        public void RemoveExample()
        {
        	var whatAnimalEatHashList = new HashList<string, string>
        	                            	{
        	                            		{"cat", "milk"},
        	                            		{"cat", "fish"},
        	                            		{"dog", "dog food"},
        	                            		{"dog", "bones"},
        	                            		{"tiger", "people"}
        	                            	};

        	// HashList contains "dog"
        	Assert.IsTrue(whatAnimalEatHashList.ContainsKey("dog"));

        	// Remove "dog"
        	whatAnimalEatHashList.Remove("dog");

        	// HashList does not contain "dog"
        	Assert.IsFalse(whatAnimalEatHashList.ContainsKey("dog"));
        }

    	#endregion

        #region RemoveKeyValue
        [Test]
        public void RemoveKeyValueExample()
        {
        	var whatAnimalEatHashList = new HashList<string, string>
        	                            	{
        	                            		{"dog", "dog food"},
        	                            		{"dog", "bones"}
        	                            	};
        	Assert.AreEqual(2, whatAnimalEatHashList["dog"].Count);
        	whatAnimalEatHashList.Remove("dog", "bones");
        	Assert.AreEqual(1, whatAnimalEatHashList["dog"].Count);
        }

    	#endregion



        #region RemoveValue
		[Test]
		public void RemoveValueExample()
		{
			var whatAnimalEatHashList = new HashList<string, string>
			                            	{
			                            		{"dog", "dog food"},
			                            		{"dog", "bones"},
			                            		{"lion", "bones"}
			                            	};

			// There are 3 Values.
			Assert.AreEqual(3, whatAnimalEatHashList.ValueCount);

			// Remove the first instance of "bones"
			whatAnimalEatHashList.RemoveValue("bones");

			// There are now 2 Values.
			Assert.AreEqual(2, whatAnimalEatHashList.ValueCount);
		}

    	#endregion


        #region RemoveAll

		[Test]
		public void RemoveAllExample()
		{
			var whatAnimalEatHashList = new HashList<string, string>
			                            	{
			                            		{"dog", "dog food"},
			                            		{"dog", "bones"},
			                            		{"dog", "cats"},
			                            		{"tiger", "people"},
			                            		{"tiger", "cats"}
			                            	};

			// HashList contains 5 values
			Assert.AreEqual(5, whatAnimalEatHashList.ValueCount);

			// Remove "cats" values
			whatAnimalEatHashList.RemoveAll("cats");

			// HashList contains 3 values because all values matching "cats" have been removed
			Assert.AreEqual(3, whatAnimalEatHashList.ValueCount);
		}

    	#endregion


      
        #region ValueCount

        [Test]
        public void ValueCountExample()
        {
        	var whatAnimalEatHashList = new HashList<string, string>
        	                            	{
        	                            		{"cat", "milk", "fish"},
        	                            		{"dog", "dog food", "bones"},
        	                            		{"tiger", "people"}
        	                            	};


        	// There are 4 values.
        	Assert.AreEqual(5, whatAnimalEatHashList.ValueCount);
        }

    	#endregion


    }
}