/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System.Collections.Generic;

namespace NGenerics.Tests.Util
{
    public class IntComparer : IComparer<int>
    {
        #region IComparer<int> Members

        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }

        #endregion
    }
}
