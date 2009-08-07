/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


namespace NGenerics.Patterns.Visitor
{
    /// <summary>
    /// A visitor that sums integers in any collection of type int.
    /// </summary>
    public sealed class SumVisitor : IVisitor<int>
    {
        #region Globals

        #endregion


        #region IVisitor<int> Members

        /// <inheritdoc />
        public void Visit(int obj)
        {
            Sum += obj;
        }

        /// <inheritdoc />
        public bool HasCompleted
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the sum accumulated by this <see cref="SumVisitor"/>.
        /// </summary>
        /// <value>The sum.</value>
        public int Sum { get; private set; }

        #endregion
    }
}