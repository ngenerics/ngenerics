/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;

namespace NGenerics.Tests.TestObjects
{
    [Serializable]
    public class NonComparableTClass : IComparable
    {
        private readonly int number;

        public NonComparableTClass(int number)
        {
            this.number = number;
        }

        public int Number
        {
            get
            {
                return number;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is NonComparableTClass))
            {
                throw new ArgumentException("Argument must be NonComparableTClass.", "obj");
            }
            var num = (NonComparableTClass) obj;
            if (number < num.number)
            {
                return -1;
            }
            if (number > num.number)
            {
                return 1;
            }
            return 0;
        }
    
    }
}