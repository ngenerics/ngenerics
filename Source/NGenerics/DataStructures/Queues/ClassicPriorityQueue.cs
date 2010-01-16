/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace NGenerics.DataStructures.Queues
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClassicPriorityQueue<T> : PriorityQueue<T, int>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassicPriorityQueue&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="queueType">Type of the queue.</param>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Queues\PriorityQueueExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Queues\PriorityQueueExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example>
        public ClassicPriorityQueue(PriorityQueueType queueType) : base(queueType)
        {
            // Do nothing
        }

        #endregion
    }
}
