/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;

namespace NGenerics.Extensions
{
    /// <summary>
    /// Provides extension methods to the Double type.
    /// </summary>
    public static class DoubleExtensions
    {
        #region Globals

        /// <summary>
        /// The default precision catered for in checking whether or not values are similar.
        /// </summary>
        public const double DefaultPrecision = 0.00000000001d;

        #endregion

        #region Public Members

        /// <summary>
        /// Checks if arguments are very close in values. If true we could assume they 
        /// refer to the same value. 
        /// </summary>
        /// <param name="arg1">The 1st argument value to check.</param>
        /// <param name="arg2">The 1st argument value to check.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Extensions\DoubleExtensionsExamples.cs" region="IsSimilarTo" lang="cs" title="The following example shows how to use the IsSimilarTo method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Extensions\DoubleExtensionsExamples.vb" region="IsSimilarTo" lang="vbnet" title="The following example shows how to use the IsSimilarTo method."/>
        /// </example>
        public static bool IsSimilarTo(this double arg1, double arg2)
        {
            return IsSimilarTo(arg1, arg2, DefaultPrecision);
        }

        /// <summary>
        /// Checks if arguments are very close in values using given precision perimeters. If true we could assume they 
        /// refer to the same value. 
        /// </summary>
        /// <param name="arg1">The 1st argument value to check.</param>
        /// <param name="arg2">The 1st argument value to check.</param>
        /// <param name="precision">The precision.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Extensions\DoubleExtensionsExamples.cs" region="IsSimilarWithPrecision" lang="cs" title="The following example shows how to use the IsSimilarTo method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Extensions\DoubleExtensionsExamples.vb" region="IsSimilarWithPrecision" lang="vbnet" title="The following example shows how to use the IsSimilarTo method."/>
        /// </example>
        public static bool IsSimilarTo(this double arg1, double arg2, double precision)
        {
            return Math.Abs(arg1 - arg2) < precision;
        }

        #endregion
    }
}
