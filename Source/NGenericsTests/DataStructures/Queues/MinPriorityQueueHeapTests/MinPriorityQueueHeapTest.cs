/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.DataStructures.Queues;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{

    public class MinPriorityQueueTest
    {

        internal static PriorityQueue<string, int> GetTestPriorityQueue()
        {
            return new PriorityQueue<string, int>(PriorityQueueType.Minimum)
                                          {
                                              {"a", 1},
                                              {"b", 2},
                                              {"c", 3},
                                              {"d", 4},
                                              {"e", 5},
                                              {"f", 6},
                                              {"z", 6},
                                              {"y", 5},
                                              {"x", 4},
                                              {"w", 3},
                                              {"v", 2},
                                              {"u", 1}
                                          };
        }

        internal static PriorityQueue<string, int> GetSimpleTestPriorityQueue()
        {
            return new PriorityQueue<string, int>(PriorityQueueType.Minimum)
                                          {
                                              {"a", 1},
                                              {"b", 2},
                                              {"c", 3},
                                              {"d", 4},
                                              {"e", 5},
                                              {"f", 6}
                                          };
        }

    }
}