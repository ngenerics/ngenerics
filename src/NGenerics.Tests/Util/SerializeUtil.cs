/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NGenerics.Tests.Util
{
    public static class SerializeUtil
    {
        /// <summary>
        /// Serializes the object, then deserialize the object and returns the result.
        /// </summary>
        /// <param name="obj">The object to serializer / deserialize.</param>
        public static T BinarySerializeDeserialize<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);

                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
                //using (var readStream = new MemoryStream(ms.ToArray()))
                //{
                //    return (T) formatter.Deserialize(readStream);
                //}
            }
        }
    }
}
