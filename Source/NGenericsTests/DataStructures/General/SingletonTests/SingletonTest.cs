/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{

    
    public class SingletonTest
    {

        internal class TestInstance
        {
            public int val;
        }

        internal static class TypeExtensions
        {
            public static Func<TResult> New<TResult>(Type type)
            {
                return GetConstructor<Func<TResult>>(type); // Type.EmptyTypes
            }

            public static Func<T, TResult> New<T, TResult>(Type type)
            {
                return GetConstructor<Func<T, TResult>>(type, typeof(T));
            }


            internal static TDelegate GetConstructor<TDelegate>(Type type, params Type[] argumentTypes)
            {
                var constructor = type.GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, argumentTypes, null);
                if (null == constructor)
                    throw new InvalidOperationException(
                        string.Format("Has no constructor {0}({1})", type,
                            string.Join(", ",
                                argumentTypes.Select(arg => Convert.ToString(arg)).ToArray())));
                var parameters = argumentTypes.Select((arg, index) => Expression.Parameter(arg, "arg" + index)).ToArray();
                return Expression.Lambda<TDelegate>(Expression.New(constructor, parameters), parameters).Compile();
            }
        }

    }
}
