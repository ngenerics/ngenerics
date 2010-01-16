/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

namespace ProjectSynchronizer.Core.Parsing {

    /// <summary>
    /// Synchronizes the files between one project and another.
    /// </summary>
    public interface ISynchronizer {

        /// <summary>
        /// Synchronizes the specified "from" project with the "to" project.
        /// </summary>
        /// <param name="fromProjectPath">From project path.</param>
        /// <param name="toProjectPath">To project path.</param>
        void Synchronize(string fromProjectPath, string toProjectPath);
    }
}
