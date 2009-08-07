/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx. 
*/


using NUnit.Framework;
using ProjectSynchronizer.Core.Parsing;
using System.IO;

namespace NGenerics.Tests.Infrastructure {
    
    [TestFixture]
    public class SilverLightTests {

        [Test]
        public void All_NGenerics_Files_Should_Be_In_SilverLight_Build_And_All_SilverLight_Files_Must_Exist()
        {
            var parser = new VS2008ProjectParser();

            var ngenericsCompilationItems = parser.FindCompilationItems(@"..\..\..\NGenerics\NGenerics.csproj");
            var silverlightCompilationItems = parser.FindCompilationItems(@"..\..\..\NGenerics\NGenerics.SilverLight.csproj");

            for (var i = 0; i < ngenericsCompilationItems.Count; i++)
            {
                Assert.IsTrue(silverlightCompilationItems.Contains(ngenericsCompilationItems[i]), "File " + ngenericsCompilationItems[i] + " not found in SilverLight build.");
            }

            for (var i = 0; i < silverlightCompilationItems.Count; i++)
            {
                if (!ngenericsCompilationItems.Contains(silverlightCompilationItems[i]))
                {
                    var path = Path.Combine(@"..\..\..\NGenerics", silverlightCompilationItems[i]);
                    Assert.IsTrue(File.Exists(path), path + " does not exist");
                }
            }
        }
    }
}
