/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	/// <summary>
	/// A class representing an edge in a graph.
	/// </summary>
	/// <typeparam name="T">The type of object the edge contains.</typeparam>
#if (!SILVERLIGHT && !WINDOWSPHONE)
    [Serializable]
#endif
	public class Edge<T>
	{
		#region Globals

		private readonly Vertex<T> from;
		private readonly Vertex<T> to;
		private readonly bool edgeIsDirected;

		#endregion
        
		#region Construction


		/// <param name="fromVertex">From <see cref="Vertex{T}"/>.</param>
		/// <param name="toVertex">To <see cref="Vertex{T}"/>.</param>
		/// <param name="isDirected">if set to <c>true</c> [is directed].</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\EdgeExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\EdgeExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the constructor."/>
        /// </example>
		public Edge(Vertex<T> fromVertex, Vertex<T> toVertex, bool isDirected) : this(fromVertex, toVertex, 0, isDirected)
		{
		}



		/// <param name="fromVertex">From <see cref="Vertex{T}"/>.</param>
		/// <param name="toVertex">To <see cref="Vertex{T}"/>.</param>
		/// <param name="weight">The weight associated with the edge.</param>
        /// <param name="isDirected">if set to <c>true</c> [is directed].</param>
        /// <exception cref="ArgumentNullException"><paramref name="fromVertex"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="toVertex"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\EdgeExamples.cs" region="WeightedConstructor" lang="cs" title="The following example shows how to use the constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\EdgeExamples.vb" region="WeightedConstructor" lang="vbnet" title="The following example shows how to use the constructor."/>
        /// </example>
		public Edge(Vertex<T> fromVertex, Vertex<T> toVertex, double weight, bool isDirected)
        {
            Guard.ArgumentNotNull(toVertex, "toVertex");
            Guard.ArgumentNotNull(fromVertex, "fromVertex");


			from = fromVertex;
			to = toVertex;
			Weight = weight;
			edgeIsDirected = isDirected;
		}

		#endregion

		#region Public Members

		/// <summary>
		/// Gets the from <see cref="Vertex{T}"/>.
		/// </summary>
		/// <value>The from <see cref="Vertex{T}"/>.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\EdgeExamples.cs" region="FromVertex" lang="cs" title="The following example shows how to use the FromVertex property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\EdgeExamples.vb" region="FromVertex" lang="vbnet" title="The following example shows how to use the FromVertex property."/>
        /// </example>
		public Vertex<T> FromVertex
		{
			get
			{
				return from;
			}
		}

		/// <summary>
		/// Gets the to <see cref="Vertex{T}"/>.
		/// </summary>
		/// <value>The to <see cref="Vertex{T}"/>.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\EdgeExamples.cs" region="ToVertex" lang="cs" title="The following example shows how to use the ToVertex property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\EdgeExamples.vb" region="ToVertex" lang="vbnet" title="The following example shows how to use the ToVertex property."/>
        /// </example>
		public Vertex<T> ToVertex
		{
			get
			{
				return to;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="Edge{T}"/> is directed.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this edge is directed; otherwise, <c>false</c>.
		/// </value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\EdgeExamples.cs" region="IsDirected" lang="cs" title="The following example shows how to use the IsDirected property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\EdgeExamples.vb" region="IsDirected" lang="vbnet" title="The following example shows how to use the IsDirected property."/>
        /// </example>
		public bool IsDirected
		{
			get
			{
				return edgeIsDirected;
			}
		}

		/// <summary>
		/// Gets the weight associated with this <see cref="Edge{T}"/>.
		/// </summary>
		/// <value>The weight associated with this <see cref="Edge{T}"/>.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\EdgeExamples.cs" region="Weight" lang="cs" title="The following example shows how to use the Weight property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\EdgeExamples.vb" region="Weight" lang="vbnet" title="The following example shows how to use the Weight property."/>
        /// </example>
		public double Weight
		{
			get;
			set;
		}


		/// <summary>
		/// Gets the partner vertex in this <see cref="Edge{T}"/> relationship.
		/// </summary>
		/// <param name="vertex">The <see cref="Vertex{T}"/>.</param>
		/// <returns>The partner of the <see cref="Vertex{T}"/> specified in this <see cref="Edge{T}"/> relationship.</returns>
		/// <exception cref="ArgumentException"><paramref name="vertex"/> does not equal <see cref="FromVertex"/> or <see cref="ToVertex"/>.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\EdgeExamples.cs" region="GetPartnerVertex" lang="cs" title="The following example shows how to use the GetPartnerVertex method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\EdgeExamples.vb" region="GetPartnerVertex" lang="vbnet" title="The following example shows how to use the GetPartnerVertex method."/>
        /// </example>
		public Vertex<T> GetPartnerVertex(Vertex<T> vertex)
		{
		    if (from == vertex)
			{
				return to;
			}
		
            if (to == vertex)
		    {
		        return from;
		    }

            throw new ArgumentException("The vertex specified does not form part of this edge.", "vertex");
		}


	    /// <summary>
		/// Gets or sets the tag object contained in the edge.
		/// </summary>
		/// <value>The tag object.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\EdgeExamples.cs" region="Tag" lang="cs" title="The following example shows how to use the Tag property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\EdgeExamples.vb" region="Tag" lang="vbnet" title="The following example shows how to use the Tag property."/>
        /// </example>
		public object Tag
		{
			get;
			set;
		}

		#endregion
	}
}