/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using NGenerics.DataStructures.General;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    public class BagTest
    {

        #region Private Members

        internal static Bag<string> GetTestBag()
        {
            var bag = new Bag<string>();

            for (var i = 0; i < 20; i++)
            {
                bag.Add(i.ToString());
            }

            for (var i = 0; i < 10; i++)
            {
                bag.Add(i.ToString());
            }

            for (var i = 0; i < 5; i++)
            {
                bag.Add(i.ToString());
            }

            return bag;
        }

        #endregion
    }
}