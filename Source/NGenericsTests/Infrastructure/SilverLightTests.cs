/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/


using NUnit.Framework;
using ProjectSynchronizer.Core.Parsing;
using System.IO;

namespace NGenerics.Tests.Infrastructure {
    
    [TestFixture]
    public class SilverLightTests {

        [Test]
        [Ignore]
        public void All_NGenerics_Files_Should_Be_In_SilverLight_Build_And_All_SilverLight_Files_Must_Exist()
        {
            var parser = new VS2008ProjectParser();

            var ngenericsCompilationItems = parser.FindCompilationItems(@"..\..\..\NGenerics\NGenerics.csproj");
            var silverlightCompilationItems = parser.FindCompilationItems(@"..\..\..\NGenerics\NGenerics.SilverLight.csproj");

            foreach (var compilationItem in ngenericsCompilationItems)
            {
                Assert.IsTrue(silverlightCompilationItems.Contains(compilationItem), "File " + Path.GetFullPath(compilationItem) + " not found in SilverLight build.");
            }

            foreach (var compilationItem in silverlightCompilationItems)
            {
                if (!ngenericsCompilationItems.Contains(compilationItem))
                {
                    var path = Path.Combine(@"..\..\..\NGenerics", compilationItem);
                    Assert.IsTrue(File.Exists(path), path + " does not exist");
                }
            }
        }
    }
}
