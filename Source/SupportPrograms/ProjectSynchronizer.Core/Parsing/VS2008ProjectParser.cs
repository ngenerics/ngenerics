/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx. 
*/

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System;
namespace ProjectSynchronizer.Core.Parsing {

    /// <summary>
    /// Parses the compilation items in a VS 2008 projec.t
    /// </summary>
    public class VS2008ProjectParser : IProjectParser {

        #region Globals

        private const string MSBuildSchema = "http://schemas.microsoft.com/developer/msbuild/2003";

        #endregion

        #region IProjectParser Members

        /// <summary>
        /// Finds the compilation items.
        /// </summary>
        /// <param name="projectPath">The project path.</param>
        /// <returns></returns>
        public IList<string> FindCompilationItems(string projectPath) {
            var document = XDocument.Load(projectPath);

            if (document.Root == null)
            {
                return new List<string>();
            }

            return (
                from itemGroup in document.Root.Elements(XName.Get("ItemGroup", MSBuildSchema))
                from compileNode in itemGroup.Elements(XName.Get("Compile", MSBuildSchema))
                from attribute in compileNode.Attributes(XName.Get("Include"))
                select attribute.Value
            ).ToList();
        }

        /// <summary>
        /// Adds the compilation items.
        /// </summary>
        /// <param name="projectPath">The project path.</param>
        /// <param name="pathsToAdd">The paths to add.</param>
        /// <param name="pathsToRemove">The paths to remove.</param>
        public void EditCompilationItems(string projectPath, IList<string> pathsToAdd, IList<string> pathsToRemove) {
            var document = XDocument.Load(projectPath);

            if (document.Root == null)
            {
                throw new ArgumentException("No root node could be found.");
            }

            var compileNode = (
                from itemGroup in document.Root.Elements(XName.Get("ItemGroup", MSBuildSchema))
                where itemGroup.Elements(XName.Get("Compile", MSBuildSchema)).Count() > 0
                select itemGroup
            ).First();

            for (var i = 0; i < pathsToAdd.Count; i++)
            {
                compileNode.Add(new XElement(XName.Get("Compile", MSBuildSchema), new XAttribute("Include", pathsToAdd[i])));
            }

            foreach (var path in pathsToRemove) 
            {
                var checkValue = path;

                var nodeToRemove = (
                    from includeNode in compileNode.Elements(XName.Get("Compile", MSBuildSchema))
                    from attribute in includeNode.Attributes(XName.Get("Include"))
                    where attribute.Value == checkValue
                    select includeNode
                ).First();

                nodeToRemove.Remove();
            }

            document.Save(projectPath);
        }

        #endregion
    }
}
