/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Graphs;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
    [TestFixture]
    public class Accept : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(false);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            for (var i = 0; i < 17; i += 2)
            {
                var edge = new Edge<int>(vertices[i], vertices[i + 2], false);
                graph.AddEdge(edge);
            }

            var trackingVisitor = new TrackingVisitor<int>();

            graph.AcceptVisitor(trackingVisitor);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, 20);

            for (var i = 0; i < 20; i++)
            {
                Assert.IsTrue(trackingVisitor.TrackingList.Contains(i));
            }
        }

        [Test]
        public void CompletedVisitor()
        {
            var graph = new Graph<int>(false);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            for (var i = 0; i < 17; i += 2)
            {
                var edge = new Edge<int>(vertices[i], vertices[i + 2], false);
                graph.AddEdge(edge);
            }

            var completedTrackingVisitor = new CompletedTrackingVisitor<int>();

            graph.AcceptVisitor(completedTrackingVisitor);
        }

        [Test]
        public void ExceptionNullVisitor()
        {
            Assert.Throws<ArgumentNullException>(() => new Graph<int>(false).AcceptVisitor(null));
        }
    }
}