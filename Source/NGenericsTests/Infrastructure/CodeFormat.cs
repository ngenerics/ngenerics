/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace NGenerics.Tests.Infrastructure
{
    [TestFixture]
    public class CodeFormat {

        #region Tests

        [Test]
        public void All_Code_Files_Should_Start_With_The_Copyright_Header() {
            List<string> files = GetNonCompliantFiles(
                @"..\..\..\NGenerics",
                @"..\..\..\NGenerics.UI",
                @"..\..\..\NGenericsTests",
                @"..\..\..\SupportPrograms\ProjectSynchronizer",
                @"..\..\..\Examples\ExampleLibraryCSharp",
                @"..\..\..\Examples\ExampleLibraryVB"
                );

            Assert.AreEqual(files.Count, 0,
                            "Non compliant files found : " + Environment.NewLine + String.Join(Environment.NewLine, files.ToArray()));
        }

        #endregion

        #region Private Members

        private static List<string> GetNonCompliantFiles(params string[] directories) {
            var ret = new List<string>();

            foreach (string root in directories) {
                ret.AddRange(GetNonCompliantFilesForDirectory(root));
            }

            return ret;
        }

        private static List<string> GetNonCompliantFilesForDirectory(string directory) {
            string directoryName = new DirectoryInfo(directory).Name;

            // Ignore bin, obj, Resources, and svn directories
            if ((directoryName == "obj") ||
                (directoryName == "bin") ||
                (directoryName == ".svn") ||
                (directoryName == "Resources")) {
                    return new List<string>();
                }

            var ret = new List<string>();

            ScanFiles(directory, ret);

            foreach (string subdirectory in Directory.GetDirectories(directory)) {
                ret.AddRange(GetNonCompliantFiles(subdirectory));
            }

            return ret;
        }

        private static void ScanFiles(string directory, ICollection<string> ret)
        {
            const string firstLine = "Copyright 2007-2009 The NGenerics Team";

            foreach (string file in Directory.GetFiles(directory, "*.cs")) {
                if (file.Contains(".Designer.")) {
                    continue;
                }

                if (!IsCopyrightHeaderInFile("/*", firstLine, file)) {
                    ret.Add(Path.GetFullPath(file));
                }
            }

            foreach (string file in Directory.GetFiles(directory, "*.vb")) {
                if (file.Contains(".Designer.")) {
                    continue;
                }

                if (!IsCopyrightHeaderInFile("'", firstLine, file)) {
                    ret.Add(Path.GetFullPath(file));
                }
            }
        }

        private static bool IsCopyrightHeaderInFile(string startsWith, string firstLine, string file) {
            using (var reader = File.OpenText(file)) {
                bool ret = reader.ReadLine().StartsWith(startsWith);

                if (ret) {
                    // Ensure that copyright notices are updated consistently.
                    // Change this whenever the copyright notices need to change in the files.
                    ret = reader.ReadLine().Contains(firstLine);
                }

                reader.Close();
                return ret;
            }
        }

        #endregion
    }
}