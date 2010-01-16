/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System.Collections.Generic;
using System.IO;

namespace ProjectSynchronizer.Core.Parsing {
    /// <summary>
    /// A concrete instance of a <see cref="ISynchronizer"/> for Visual Studio 2008 project files.
    /// </summary>
    public class VS2008Synchronizer : ISynchronizer {

        #region ISynchronizer Members

        /// <summary>
        /// Synchronizes the specified "from" project with the "to" project.
        /// </summary>
        /// <param name="fromProjectPath">From project path.</param>
        /// <param name="toProjectPath">To project path.</param>
        public void Synchronize(string fromProjectPath, string toProjectPath) {
            var parser = new VS2008ProjectParser();
            var fromItems = parser.FindCompilationItems(fromProjectPath);
            var toItems = parser.FindCompilationItems(toProjectPath);

            var itemsToAdd = new List<string>();
            
            foreach (var compilationItem in fromItems)
            {
                if (!toItems.Contains(compilationItem))
                {
                    itemsToAdd.Add(compilationItem);
                }
            }

            var itemsToRemove = new List<string>();
            var projectPath = Path.GetDirectoryName(fromProjectPath);

            foreach (var compilationItem in toItems) 
            {
                if (!fromItems.Contains(compilationItem))
                {
                    if (!File.Exists(Path.Combine(projectPath, compilationItem)))
                    {
                        itemsToRemove.Add(compilationItem);
                    }
                }
            }

            if ((itemsToAdd.Count > 0) || (itemsToRemove.Count > 0))
            {
                parser.EditCompilationItems(toProjectPath, itemsToAdd, itemsToRemove);
            }
        }

        #endregion
    }
}
