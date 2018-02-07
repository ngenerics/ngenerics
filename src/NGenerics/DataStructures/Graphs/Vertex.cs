/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.Graphs
{
    /// <summary>
    /// A class representing a vertex in a graph.
	/// </summary>
	/// <typeparam name="T">The type contained in the vertex.</typeparam>
    [Serializable]
	public class Vertex<T>
	{
		#region Globals

    	private readonly List<Edge<T>> _incidentEdges;
		private readonly List<Edge<T>> _emanatingEdges;

    	#endregion

		#region Construction


		/// <remarks>The weight is 0 by default.</remarks>
		/// <param name="data">The data contained in the vertex.</param>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the constructor."/>
        /// </example>
		public Vertex(T data) : this(data, 0)
		{
		}


		/// <param name="data">The data contained in the vertex</param>
		/// <param name="weight">The weight of the vertex.</param>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="ConstructorWithWeight" lang="cs" title="The following example shows how to use the constructor."/>
        /// </example>
		public Vertex(T data, double weight)
		{
			_incidentEdges = new List<Edge<T>>();
			_emanatingEdges = new List<Edge<T>>();
			Data = data;
			Weight = weight;
		}

		#endregion

		#region Public Members

    	/// <summary>
    	/// Gets or sets the weight.
    	/// </summary>
    	/// <value>The weight.</value>
    	/// <example>
    	/// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="ConstructorWithWeightExample" lang="cs" title="The following example shows how to use the Weight property."/>
    	/// </example>
    	public double Weight { get; set; }

    	/// <summary>
    	/// Gets or sets the data.
    	/// </summary>
    	/// <value>The data contained in the vertex.</value>
    	/// <example>
    	/// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="Data" lang="cs" title="The following example shows how to use the Data property."/>
    	/// </example>
    	public T Data { get; set; }

    	/// <summary>
		/// Gets the degree of this vertex (the number of emanating edges).
		/// </summary>
		/// <value>The degree.</value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="Degree" lang="cs" title="The following example shows how to use the Degree property."/>
        /// </example>
		public int Degree => _emanatingEdges.Count;

		/// <summary>
		/// Gets the edges incident on this vertex.
		/// </summary>
		/// <value>The edges incident on this vertex.</value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="IncidentEdges" lang="cs" title="The following example shows how to use the IncidentEdges property."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public IList<Edge<T>> IncidentEdges => new ReadOnlyCollection<Edge<T>>(_incidentEdges);

		/// <summary>
		/// Gets the emanating edges on this vertex.
		/// </summary>
		/// <value>The emanating edges on this vertex.</value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="EmanatingEdges" lang="cs" title="The following example shows how to use the EmanatingEdges property."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public IList<Edge<T>> EmanatingEdges => new ReadOnlyCollection<Edge<T>>(_emanatingEdges);

		/// <summary>
        /// Gets count of the incoming edges on this vertex.
        /// </summary>
        /// <value>The number of incoming edges resident on the vertex.</value>
        public int IncomingEdgeCount => _incidentEdges.Count - _emanatingEdges.Count;

		/// <summary>
		/// Determines whether this vertex has an emanating edge to the specified vertex.
		/// </summary>
		/// <param name="toVertex">The vertex to test connectivity to.</param>
		/// <returns>
		/// 	<c>true</c> if this vertex has an emanating edge to the specified vertex; otherwise, <c>false</c>.
		/// </returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="HasEmanatingEdgeTo" lang="cs" title="The following example shows how to use the HasEmanatingEdgeTo method."/>
        /// </example>
		public bool HasEmanatingEdgeTo(Vertex<T> toVertex)
		{
			foreach (var emanatingEdge in _emanatingEdges)
			{
				if (emanatingEdge.IsDirected && emanatingEdge.ToVertex == toVertex)
                {
						return true;
				}

			    if (emanatingEdge.ToVertex == toVertex || (emanatingEdge.FromVertex == toVertex))
			    {
			        return true;
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
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="HasIncidentEdgeWith" lang="cs" title="The following example shows how to use the HasIncidentEdgeWith method."/>
        /// </example>
		public bool HasIncidentEdgeWith(Vertex<T> fromVertex)
		{
			for (var i = 0; i < _incidentEdges.Count; i++)
			{
			    var incidentEdge = _incidentEdges[i];
			    if ((incidentEdge.FromVertex == fromVertex) || (incidentEdge.ToVertex == fromVertex))
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
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="GetEmanatingEdgeTo" lang="cs" title="The following example shows how to use the GetEmanatingEdgeTo method."/>
        /// </example>
		public Edge<T> GetEmanatingEdgeTo(Vertex<T> toVertex)
        {
	        foreach (var emanatingEdgeTo in _emanatingEdges)
	        {
		        if (emanatingEdgeTo.IsDirected)
		        {
			        if (emanatingEdgeTo.ToVertex == toVertex)
			        {
				        return emanatingEdgeTo;
			        }
		        }
		        else
		        {					
			        if ((emanatingEdgeTo.FromVertex == toVertex) || (emanatingEdgeTo.ToVertex == toVertex))
			        {
				        return emanatingEdgeTo;
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
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\VertexExamples.cs" region="GetIncidentEdgeWith" lang="cs" title="The following example shows how to use the GetIncidentEdgeWith method."/>
        /// </example>
		public Edge<T> GetIncidentEdgeWith(Vertex<T> toVertex)
		{
			foreach (var incidentEdgeWith in _incidentEdges)
			{
				if ((incidentEdgeWith.ToVertex == toVertex) || (incidentEdgeWith.FromVertex == toVertex))
				{
					return incidentEdgeWith;
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
			Debug.Assert(edge != null);
			RemoveEdgeFromVertex(edge);
		}

        /// <summary>
        /// Adds the edge to the vertex.
        /// </summary>
        /// <param name="edge">The edge to add.</param>
		internal void AddEdge(Edge<T> edge)
		{
			Debug.Assert(edge != null);

			if (edge.IsDirected)
			{
				if (edge.FromVertex == this)
				{
					_emanatingEdges.Add(edge);
				}
			}
			else
			{
				_emanatingEdges.Add(edge);
			}

			_incidentEdges.Add(edge);
		}

		#endregion

		#region Private Members

		private void RemoveEdgeFromVertex(Edge<T> edge)
        {
            bool present = _incidentEdges.Remove(edge);
            Debug.Assert(present, "Edge not found on vertex in RemoveEdgeFromVertex.");

			if (edge.IsDirected)
			{
				if (edge.FromVertex == this)
				{
					_emanatingEdges.Remove(edge);
				}
			}
			else
			{
				_emanatingEdges.Remove(edge);
			}
		}

		#endregion
	}
}
