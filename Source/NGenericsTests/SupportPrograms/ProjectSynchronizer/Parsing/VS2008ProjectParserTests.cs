/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System.Collections.Generic;
using NUnit.Framework;
using ProjectSynchronizer.Core.Parsing;
using System.IO;
using NGenerics.Tests.TestObjects;

namespace NGenerics.Tests.SupportPrograms.ProjectSynchronizer.Parsing {
    
    [TestFixture]
    public class VS2008ProjectParserTests {

        private const string SampleNGenericsProject = @"..\..\TestObjects\Artifacts\SampleProjects\NGenerics.csproj";
        private const string SampleNGenericsSilverLightProject = @"..\..\TestObjects\Artifacts\SampleProjects\NGenerics.SilverLight.csproj";
        private const string MergeNGenericsSilverLightProject = @"..\..\TestObjects\Artifacts\SampleProjects\NGenerics.SilverLight.Merged.csproj";

        [TestFixture]
        public class FindCompilationItems {

            [Test]
            public void Should_Find_Only_Compilation_Items_In_NGenerics()
            {
                var parser = new VS2008ProjectParser();
                var items = parser.FindCompilationItems(SampleNGenericsProject);

                Assert.AreEqual(items.Count, 4);

                Assert.AreEqual(items[0], @"Algorithms\GraphAlgorithms.cs");
                Assert.AreEqual(items[1], @"Algorithms\MathAlgorithms.cs");
                Assert.AreEqual(items[2], @"Algorithms\VertexInfo.cs");
                Assert.AreEqual(items[3], @"Comparers\AssociationKeyComparer.cs");
            }

            [Test]
            public void Should_Find_Only_Compilation_Items_In_NGenerics_SilverLight() {
                var parser = new VS2008ProjectParser();
                var items = parser.FindCompilationItems(SampleNGenericsSilverLightProject);

                Assert.AreEqual(items.Count, 1);
                Assert.AreEqual(items[0], @"Algorithms\GraphAlgorithms.cs");
            }
        }

        [TestFixture]
        public class AddCompilationItems {

            [Test]
            public void Should_Add_Compilation_Items_But_Not_Drop_Anything_Else() {
                var parser = new VS2008ProjectParser();

                var items = parser.FindCompilationItems(SampleNGenericsSilverLightProject);

                Assert.AreEqual(items.Count, 1);
                Assert.AreEqual(items[0], @"Algorithms\GraphAlgorithms.cs");
                
                try {
                    // Copy the silverlight project to another location
                    File.WriteAllText(MergeNGenericsSilverLightProject, TestFiles.NGenerics_Silverlight);

                    // File size must be larger after we've added the dependencies
                    var size = new FileInfo(MergeNGenericsSilverLightProject).Length;
                    

                    // Add two test components
                    parser.EditCompilationItems(MergeNGenericsSilverLightProject, new List<string> { "Test1", "Test2" }, new List<string>());

                    // Parse the file back in, and ensure that those items are there.
                    items = parser.FindCompilationItems(MergeNGenericsSilverLightProject);

                    Assert.AreEqual(items.Count, 3);

                    Assert.AreEqual(items[0], @"Algorithms\GraphAlgorithms.cs");
                    Assert.AreEqual(items[1], @"Test1");
                    Assert.AreEqual(items[2], @"Test2");

                    // Ensure that the file size is larger than it was..
                    Assert.Greater(new FileInfo(MergeNGenericsSilverLightProject).Length, size);

                } 
                finally
                {
                    if (File.Exists(MergeNGenericsSilverLightProject))
                    {
                        File.Delete(MergeNGenericsSilverLightProject);
                    }
                }
            }
        }
    }
}
