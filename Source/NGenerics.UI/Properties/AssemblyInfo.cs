/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if (!SILVERLIGHT)
using System.Security;
#endif
using System.Security.Permissions;

[assembly: AssemblyTitle("NGenerics.UI")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("The NGenerics Team")]
[assembly: AssemblyProduct("NGenerics.UI")]
[assembly: AssemblyCopyright("Copyright © 2008 The NGenerics Team")]
[assembly: AssemblyTrademark("NGenerics")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("1ac28a38-3b64-4dc3-98d8-1689481b5ef5")]
[assembly: AssemblyVersion("1.4.1.0")]
[assembly: AssemblyFileVersion("1.4.1.0")]
#if (!SILVERLIGHT)
[assembly: AllowPartiallyTrustedCallers]
#endif

[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum)]
[assembly: InternalsVisibleTo("NGenerics.Tests, PublicKey=002400000480000094000000060200000024000052534131000400000100010065218A06E4A3D9F9A4CEFE43CEB16013B97102DE5EAEDB07C2AEB844FE3A2C8BB6A809BF4DF1CF2439FA6A1FB3DB1296ED03B2D6496495E346BCEE6CF827DC3A0FF63555924AC456DD8CD699D32268688457BB8FDBC533D937356C75CB14E1EF7C0866A692FB5C43D02CAEFE795FE04B8C0E0AABF553B4B2D09D968BE4E31ACB")]