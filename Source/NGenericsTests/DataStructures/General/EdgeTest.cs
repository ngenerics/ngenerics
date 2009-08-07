/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{
    [TestFixture]
    public class EdgeTest
    {
        [TestFixture]
        public class Construction
        {
            [Test]
            public void Edge()
            {
                var vertex1 = new Vertex<int>(6);
                var vertex2 = new Vertex<int>(4);

                var edge = new Edge<int>(vertex1, vertex2, true);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);
                Assert.AreEqual(edge.Weight, 0);

                edge = new Edge<int>(vertex1, vertex2, 55, true);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);
                Assert.AreEqual(edge.Weight, 55);

                edge = new Edge<int>(vertex1, vertex2, -2, true);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);
                Assert.AreEqual(edge.Weight, -2);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullFromVertexDirected()
            {
                new Edge<int>(null, new Vertex<int>(4), true);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullToVertexDirected()
            {
                new Edge<int>(new Vertex<int>(4), null, true);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullFromVertexUndirected()
            {
                new Edge<int>(null, new Vertex<int>(4), false);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullToVertexUndirected()
            {
                new Edge<int>(new Vertex<int>(4), null, false);
            }
        }

        [TestFixture]
        public class Tag
        {
            [Test]
            public void Simple()
            {
                var edge = new Edge<int>(new Vertex<int>(5), new Vertex<int>(4), true);
                Assert.IsNull(edge.Tag);

                const string tag = "NGenerics";

                edge.Tag = tag;

                Assert.AreSame(edge.Tag, tag);
            }
        }

        [TestFixture]
        public class Weight
        {
            [Test]
            public void Simple()
            {
                var edge = new Edge<int>(new Vertex<int>(5), new Vertex<int>(4), 23.2, true);

                Assert.AreEqual(edge.Weight, 23.2);

                edge.Weight = 14.6;
                Assert.AreEqual(edge.Weight, 14.6);
            }
        }
    }
}
