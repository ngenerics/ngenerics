/*  
  Copyright 2007-2010 The NGenerics Team
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
    public class CodeFormat
    {


        [Test]
        public void All_Code_Files_Should_Start_With_The_Copyright_Header()
        {
            var files = GetNonCompliantFiles(
                @"..\..\..\NGenerics",
                @"..\..\..\NGenericsTests",
                @"..\..\..\SupportPrograms\ProjectSynchronizer",
                @"..\..\..\Examples\ExampleLibraryCSharp",
                @"..\..\..\Examples\ExampleLibraryVB"
                );
            //foreach (var file in files)
            //{
//                var readAllText = File.ReadAllText(file);
//                File.WriteAllText(file, @"/*  
//  Copyright 2007-2010 The NGenerics Team
// (http://code.google.com/p/ngenerics/wiki/Team)
//
// This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
// have received a copy of the license along with the source code.  If not, an online copy
// of the license can be found at http://www.gnu.org/copyleft/lesser.html.
//*/
//" + readAllText);
//            }
            var message = string.Format("Non compliant files found : {0}{1}", Environment.NewLine, String.Join(Environment.NewLine, files.ToArray()));
            Assert.AreEqual(files.Count, 0, message);
        }

        private static List<string> GetNonCompliantFiles(params string[] directories)
        {
            var ret = new List<string>();

            foreach (var root in directories)
            {
                ret.AddRange(GetNonCompliantFilesForDirectory(root));
            }

            return ret;
        }

        private static List<string> GetNonCompliantFilesForDirectory(string directory)
        {
            var directoryName = new DirectoryInfo(directory).Name;

            // Ignore bin, obj, Resources, and svn directories
            if ((directoryName == "obj") ||
                (directoryName == "bin") ||
                (directoryName == ".svn") ||
                (directoryName == "Resources"))
            {
                return new List<string>();
            }

            var ret = new List<string>();

            ScanFiles(directory, ret);

            foreach (var subdirectory in Directory.GetDirectories(directory))
            {
                ret.AddRange(GetNonCompliantFiles(subdirectory));
            }

            return ret;
        }

        private static void ScanFiles(string directory, ICollection<string> ret)
        {
            const string firstLine = "Copyright 2007-2010 The NGenerics Team";

            foreach (var file in Directory.GetFiles(directory, "*.cs"))
            {
                if (file.Contains(".Designer."))
                {
                    continue;
                }

                if (!IsCopyrightHeaderInFile("/*", firstLine, file))
                {
                    ret.Add(Path.GetFullPath(file));
                }
            }

            foreach (var file in Directory.GetFiles(directory, "*.vb"))
            {
                if (file.Contains(".Designer."))
                {
                    continue;
                }

                if (!IsCopyrightHeaderInFile("'", firstLine, file))
                {
                    ret.Add(Path.GetFullPath(file));
                }
            }
        }

        private static bool IsCopyrightHeaderInFile(string startsWith, string firstLine, string file)
        {
            using (var reader = File.OpenText(file))
            {
                var ret = reader.ReadLine().StartsWith(startsWith);

                if (ret)
                {
                    // Ensure that copyright notices are updated consistently.
                    // Change this whenever the copyright notices need to change in the files.
                    ret = reader.ReadLine().Contains(firstLine);
                }

                reader.Close();
                return ret;
            }
        }

    }
}