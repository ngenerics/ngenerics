/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

namespace NGenerics.Patterns.Conversion
{
    /// <summary>
    /// A simple interface for conversions between types.
    /// </summary>
    /// <typeparam name="TInput">The from type.</typeparam>
    /// <typeparam name="TOutput">The to type.</typeparam>
    public interface IConverter<TInput, TOutput>
    {
        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        TOutput Convert(TInput input);
    }
}