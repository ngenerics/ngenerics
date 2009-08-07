/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

#if (!SILVERLIGHT)
using System;
#endif
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// A class representing a vertex in a graph.
	/// </summary>
    /// <typeparam name="T">The type contained in the vertex.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
	public class Vertex<T>
	{
		#region Globals

    	private readonly List<Edge<T>> incidentEdges;
		private readonly List<Edge<T>> emanatingEdges;

    	#endregion

		#region Construction


		/// <remarks>The weight is 0 by default.</remarks>
		/// <param name="data">The data contained in the vertex.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the constructor."/>
        /// </example>
		public Vertex(T data)
		{
			Data = data;
			incidentEdges = new List<Edge<T>>();
			emanatingEdges = new List<Edge<T>>();
			Weight = 0;
		}


		/// <param name="data">The data contained in the vertex</param>
		/// <param name="weight">The weight of the vertex.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="ConstructorWithWeight" lang="cs" title="The following example shows how to use the constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="ConstructorWithWeight" lang="vbnet" title="The following example shows how to use the constructor."/>
        /// </example>
		public Vertex(T data, double weight)
		{
			Data = data;
			incidentEdges = new List<Edge<T>>();
			emanatingEdges = new List<Edge<T>>();
			Weight = weight;
		}

		#endregion

		#region Public Members

    	/// <summary>
    	/// Gets or sets the weight.
    	/// </summary>
    	/// <value>The weight.</value>
    	/// <example>
    	/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="Weight" lang="cs" title="The following example shows how to use the Weight property."/>
    	/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="Weight" lang="vbnet" title="The following example shows how to use the Weight property."/>
    	/// </example>
    	public double Weight { get; set; }

    	/// <summary>
    	/// Gets or sets the data.
    	/// </summary>
    	/// <value>The data contained in the vertex.</value>
    	/// <example>
    	/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="Data" lang="cs" title="The following example shows how to use the Data property."/>
    	/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="Data" lang="vbnet" title="The following example shows how to use the Data property."/>
    	/// </example>
    	public T Data { get; set; }

    	/// <summary>
		/// Gets the degree of this vertex (the number of emanating edges).
		/// </summary>
		/// <value>The degree.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="Degree" lang="cs" title="The following example shows how to use the Degree property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="Degree" lang="vbnet" title="The following example shows how to use the Degree property."/>
        /// </example>
		public int Degree
		{
			get
			{
				return emanatingEdges.Count;
			}
		}

		/// <summary>
		/// Gets the edges incident on this vertex.
		/// </summary>
		/// <value>The edges incident on this vertex.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="IncidentEdges" lang="cs" title="The following example shows how to use the IncidentEdges property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="IncidentEdges" lang="vbnet" title="The following example shows how to use the IncidentEdges property."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public IList<Edge<T>> IncidentEdges
		{
			get
			{
                return new ReadOnlyCollection<Edge<T>>(incidentEdges);
			}
		}

		/// <summary>
		/// Gets the emanating edges on this vertex.
		/// </summary>
		/// <value>The emanating edges on this vertex.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="EmanatingEdges" lang="cs" title="The following example shows how to use the EmanatingEdges property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="EmanatingEdges" lang="vbnet" title="The following example shows how to use the EmanatingEdges property."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public IList<Edge<T>> EmanatingEdges
		{
			get
			{
                return new ReadOnlyCollection<Edge<T>>(emanatingEdges);
			}
		}

        /// <summary>
        /// Gets count of the incoming edges on this vertex.
        /// </summary>
        /// <value>The number of incoming edges resident on the vertex.</value>
        public int IncomingEdgeCount
        {
            get
            {
            	 return incidentEdges.Count - emanatingEdges.Count;
            }
        }
            /// <summary>
		/// Determines whether this vertex has an emanating edge to the specified vertex.
		/// </summary>
		/// <param name="toVertex">The vertex to test connectivity to.</param>
		/// <returns>
		/// 	<c>true</c> if this vertex has an emanating edge to the specified vertex; otherwise, <c>false</c>.
		/// </returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="HasEmanatingEdgeTo" lang="cs" title="The following example shows how to use the HasEmanatingEdgeTo method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="HasEmanatingEdgeTo" lang="vbnet" title="The following example shows how to use the HasEmanatingEdgeTo method."/>
        /// </example>
		public bool HasEmanatingEdgeTo(Vertex<T> toVertex)
		{
			for (var i = 0; i < emanatingEdges.Count; i++)
			{
				if (emanatingEdges[i].IsDirected)
				{
					if (emanatingEdges[i].ToVertex == toVertex)
					{
						return true;
					}
				}
				else
				{
					if ((emanatingEdges[i].ToVertex == toVertex) || ((emanatingEdges[i].FromVertex == toVertex)))
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// Determines whether [has incident edge with] [the specified from vertex].
		/// </summary>
		/// <param name="fromVertex">From vertex.</param>
		/// <returns>
		/// 	<c>true</c> if [has incident edge with] [the specified from vertex]; otherwise, <c>false</c>.
		/// </returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="HasIncidentEdgeWith" lang="cs" title="The following example shows how to use the HasIncidentEdgeWith method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="HasIncidentEdgeWith" lang="vbnet" title="The following example shows how to use the HasIncidentEdgeWith method."/>
        /// </example>
		public bool HasIncidentEdgeWith(Vertex<T> fromVertex)
		{
			for (var i = 0; i < incidentEdges.Count; i++)
			{
				if ((incidentEdges[i].FromVertex == fromVertex) || (incidentEdges[i].ToVertex == fromVertex))
				{
					return true;
				}
			}

			return false;
		}

        /// <summary>
        /// Gets the emanating edge to the specified vertex.
        /// </summary>
        /// <param name="toVertex">To to vertex.</param>
        /// <returns>The emanating edge to the vertex specified if found, otherwise null.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="GetEmanatingEdgeTo" lang="cs" title="The following example shows how to use the GetEmanatingEdgeTo method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="GetEmanatingEdgeTo" lang="vbnet" title="The following example shows how to use the GetEmanatingEdgeTo method."/>
        /// </example>
		public Edge<T> GetEmanatingEdgeTo(Vertex<T> toVertex)
		{
			for (var i = 0; i < emanatingEdges.Count; i++)
			{
				if (emanatingEdges[i].IsDirected)
				{
					if (emanatingEdges[i].ToVertex == toVertex)
					{
						return emanatingEdges[i];
					}
				}
				else
				{					
					if ((emanatingEdges[i].FromVertex == toVertex) || (emanatingEdges[i].ToVertex == toVertex))
					{
						return emanatingEdges[i];
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Gets the incident edge to the specified vertex.
		/// </summary>
		/// <param name="toVertex">The to vertex.</param>
		/// <returns>The incident edge to the vertex specified if found, otherwise null.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\VertexExamples.cs" region="GetIncidentEdgeWith" lang="cs" title="The following example shows how to use the GetIncidentEdgeWith method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\VertexExamples.vb" region="GetIncidentEdgeWith" lang="vbnet" title="The following example shows how to use the GetIncidentEdgeWith method."/>
        /// </example>
		public Edge<T> GetIncidentEdgeWith(Vertex<T> toVertex)
		{
			for (var i = 0; i < incidentEdges.Count; i++)
			{
				if ((incidentEdges[i].ToVertex == toVertex) || (incidentEdges[i].FromVertex == toVertex))
				{
					return incidentEdges[i];
				}
			}

			return null;
		}


		#endregion

		#region Internal Members
        		
		/// <summary>
		/// Removes the edge specified from the vertex.
		/// </summary>
		/// <param name="edge">The edge to be removed.</param>
		internal void RemoveEdge(Edge<T> edge)
		{
			#region Asserts

			Debug.Assert(edge != null);

			#endregion

			RemoveEdgeFromVertex(edge);
		}

        /// <summary>
        /// Adds the edge to the vertex.
        /// </summary>
        /// <param name="edge">The edge to add.</param>
		internal void AddEdge(Edge<T> edge)
		{
			#region Asserts

			Debug.Assert(edge != null);

			#endregion

			if (edge.IsDirected)
			{
				if (edge.FromVertex == this)
				{
					emanatingEdges.Add(edge);
				}
			}
			else
			{
				emanatingEdges.Add(edge);
			}

			incidentEdges.Add(edge);
		}

		#endregion

		#region Private Members

		private void RemoveEdgeFromVertex(Edge<T> edge)
        {
            #region Asserts

            Debug.Assert(incidentEdges.Remove(edge), "Edge not found on vertex in RemoveEdgeFromVertex.");

            #endregion

            incidentEdges.Remove(edge);

			if (edge.IsDirected)
			{
				if (edge.FromVertex == this)
				{
					emanatingEdges.Remove(edge);
				}
			}
			else
			{
				emanatingEdges.Remove(edge);
			}
		}

		#endregion
	}
}
