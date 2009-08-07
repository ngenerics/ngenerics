/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

namespace NGenerics.DataStructures.Queues
{
    /// <summary>
    /// Specifies the Priority Queue type (min or max).
    /// </summary>
    public enum PriorityQueueType
    {
        /// <summary>
        /// Specify a Minimum <see cref="PriorityQueue{TValue, TPriority}"/>.
        /// </summary>
        Minimum = 0,

        /// <summary>
        /// Specify a Maximum <see cref="PriorityQueue{TValue, TPriority}"/>.
        /// </summary>
        Maximum = 1
    }
}