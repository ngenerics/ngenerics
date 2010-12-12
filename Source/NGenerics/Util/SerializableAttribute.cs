
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