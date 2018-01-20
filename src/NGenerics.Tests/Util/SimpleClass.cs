/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;

namespace NGenerics.Tests.Util
{
    [Serializable]
    internal class SimpleClass
    {
        #region Globals

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleClass"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public SimpleClass(string value)
        {
            TestProperty = value;
        }

        #endregion

        #region Public Members

        public string TestProperty { get; set; }

        public int InvalidProperty
        {
            get
            {
                return 5;
            }
        }

        #endregion
    }
}
