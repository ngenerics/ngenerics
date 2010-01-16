/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System.IO;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;
using ProjectSynchronizer.Core.Parsing;

namespace NGenerics.Tests.SupportPrograms.ProjectSynchronizer.Parsing {
    
    [TestFixture]
    public class VS2008SynchronizerTests {

        private const string SampleNGenericsProject = @"..\..\TestObjects\Artifacts\SampleProjects\NGenerics.csproj";
        private const string SampleNGenericsSilverLightProject = @"..\..\TestObjects\Artifacts\SampleProjects\NGenerics.SilverLight.csproj";
        private const string MergeNGenericsSilverLightProject = @"..\..\TestObjects\Artifacts\SampleProjects\NGenerics.SilverLight.Merged.csproj";

        [TestFixture]
        public class Synchronize {

            [Test]
            public void Should_Synchronize_Test_Project_Files()
            {
                var parser = new VS2008ProjectParser();
                var synchronizer = new VS2008Synchronizer();

                var items = parser.FindCompilationItems(SampleNGenericsSilverLightProject);

                Assert.AreEqual(items.Count, 1);
                Assert.AreEqual(items[0], @"Algorithms\GraphAlgorithms.cs");

                try {
                    
                    // Copy the silverlight project to another location
                    File.WriteAllText(MergeNGenericsSilverLightProject, TestFiles.NGenerics_Silverlight);

                    // Sync any changes
                    synchronizer.Synchronize(SampleNGenericsProject, MergeNGenericsSilverLightProject);

                    // File size must be larger after we've added the dependencies
                    var size = new FileInfo(MergeNGenericsSilverLightProject).Length;

                    // Parse the file back in, and ensure that those items are there.
                    items = parser.FindCompilationItems(MergeNGenericsSilverLightProject);

                    Assert.AreEqual(items.Count, 4);

                    Assert.AreEqual(items[0], @"Algorithms\GraphAlgorithms.cs");
                    Assert.AreEqual(items[1], @"Algorithms\MathAlgorithms.cs");
                    Assert.AreEqual(items[2], @"Algorithms\VertexInfo.cs");
                    Assert.AreEqual(items[3], @"Comparers\AssociationKeyComparer.cs");
                }
                finally {
                    if (File.Exists(MergeNGenericsSilverLightProject)) {
                        File.Delete(MergeNGenericsSilverLightProject);
                    }
                }
            }
        }
    }
}
