/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General;

namespace NGenerics.Tests.DataStructures.General.DictionaryBaseTests
{
    internal class MockExceptionDictionary : DictionaryBase<int, int>
    {
        protected override void AddItem(int key, int value)
        {
            throw new Exception("AddItem");
        }


        protected override bool RemoveItem(int key)
        {
            throw new Exception("RemoveItem");
        }


        protected override void ClearItems()
        {
            throw new Exception("ClearItems");
        }


        protected override void SetItem(int key, int value)
        {
            throw new Exception("SetItem");
        }

    }
}