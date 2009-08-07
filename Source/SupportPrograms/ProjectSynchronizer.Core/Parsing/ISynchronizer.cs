/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx. 
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
