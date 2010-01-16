/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;

namespace NGenerics.Tests.TestObjects
{
#if (!SILVERLIGHT)
    [Serializable]
#endif
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