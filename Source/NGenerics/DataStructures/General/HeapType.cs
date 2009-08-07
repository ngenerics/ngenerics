/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/



namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// The type of <see cref="Heap{T}"/> to implemented.
    /// </summary>
    public enum HeapType
    {
        /// <summary>
        /// Makes the heap a Minimum-Heap - the smallest item is kept in the root of the <see cref="Heap{T}"/>.
        /// </summary>
        Minimum,

        /// <summary>
        /// Makes the heap a Maximum-Heap - the largest item is kept in the root of the <see cref="Heap{T}"/>.
        /// </summary>
        Maximum
    }
}