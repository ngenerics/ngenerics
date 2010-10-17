/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
        /// Converts the specified input to the specified output type.
        /// </summary>
        /// <param name="input">The input to convert..</param>
        /// <returns>A converted instance of the output type.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Patterns\Conversion\ConverterExamples.cs" region="Convert" lang="cs" title="The following example shows how to use the Convert method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Patterns\Conversion\ConverterExamples.vb" region="Convert" lang="vbnet" title="The following example shows how to use the Convert method."/>
        /// </example>
        TOutput Convert(TInput input);
    }
}