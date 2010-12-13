/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

/*
* Stolen straight from Devlicuo.us : 
* http://devlicio.us/blogs/krzysztof_kozmic/archive/2010/11/16/how-to-make-sharing-code-between-net-and-silverlight-a-little-less-painful.aspx
* Incredible useful for removing the preconditions on the Serializable attribute over all classes.
*/

#if SILVERLIGHT || WINDOWSPHONE
namespace System
{
    using Diagnostics;

    [Conditional("THIS_IS_NEVER_TRUE")]
    internal class SerializableAttribute : Attribute
    {

    }
    
    [Conditional("THIS_IS_NEVER_TRUE")]
    internal class NonSerializedAttribute : Attribute
    {

    }
}
#endif