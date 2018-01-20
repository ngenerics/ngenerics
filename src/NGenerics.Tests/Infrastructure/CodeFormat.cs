/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

namespace NGenerics.Tests.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using NUnit.Framework;

    [TestFixture]
    public class CodeFormat
    {
        [Test]
        public void All_Code_Files_Should_Start_With_The_Copyright_Header()
        {
            var files = GetNonCompliantFiles(
                @"..\..\..\NGenerics",
                @"..\..\..\NGenericsTests",
                @"..\..\..\Examples\ExampleLibraryCSharp",
                @"..\..\..\Examples\ExampleLibraryVB");

            var message = string.Format("Non compliant files found : {0}{1}", Environment.NewLine, string.Join(Environment.NewLine, files.ToArray()));
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

        private static IEnumerable<string> GetNonCompliantFilesForDirectory(string directory)
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
            const string firstLine = "Copyright 2007-2017 The NGenerics Team";

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