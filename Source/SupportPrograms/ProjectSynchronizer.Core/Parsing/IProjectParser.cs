/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System.Collections.Generic;
namespace ProjectSynchronizer.Core.Parsing {

    /// <summary>
    /// An interface for parsing VS projects.
    /// </summary>
    public interface IProjectParser {
        IList<string> FindCompilationItems(string projectPath);
        void EditCompilationItems(string projectPath, IList<string> pathsToAdd, IList<string> pathsToRemove);
    }
}
