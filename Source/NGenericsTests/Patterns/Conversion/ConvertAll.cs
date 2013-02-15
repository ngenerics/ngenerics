/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System.Collections.Generic;
using System.Linq;
using NGenerics.Patterns.Conversion;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Conversion
{
    [TestFixture]
    public class ConvertAll
    {
        [Test]
        public void Converter_Should_Convert_All_Items()
        {
            var mocks = new MockRepository();
            var converter = mocks.StrictMock<IConverter<int, string>>();

            Expect.Call(converter.Convert(5)).Return("5");
            Expect.Call(converter.Convert(3)).Return("3");
            Expect.Call(converter.Convert(7)).Return("7");

            mocks.ReplayAll();

            IList<int> input = new List<int> { 5, 3, 7 };
            var output = converter.ConvertAll(input);

            Assert.IsTrue(output.Contains("5"));
            Assert.IsTrue(output.Contains("3"));
            Assert.IsTrue(output.Contains("7"));

            mocks.VerifyAll();
        }

        [Test]
        public void Enumerable_Should_Convert_All_Items_With_Specified_Converter()
        {
            var mocks = new MockRepository();
            var converter = mocks.StrictMock<IConverter<int, string>>();

            Expect.Call(converter.Convert(5)).Return("5");
            Expect.Call(converter.Convert(3)).Return("3");
            Expect.Call(converter.Convert(7)).Return("7");

            mocks.ReplayAll();

            IList<int> input = new List<int> { 5, 3, 7 };
            var output = input.Convert(converter);

            Assert.IsTrue(output.Contains("5"));
            Assert.IsTrue(output.Contains("3"));
            Assert.IsTrue(output.Contains("7"));

            mocks.VerifyAll();
        }

        [Test]
        public void BidirectionalConverter_Should_Convert_All_Items()
        {
            var mocks = new MockRepository();
            var converter1 = mocks.StrictMock<IBidirectionalConverter<int, string>>();

            Expect.Call(converter1.Convert(5)).Return("5");
            Expect.Call(converter1.Convert(3)).Return("3");
            Expect.Call(converter1.Convert(7)).Return("7");

            var converter2 = mocks.StrictMock<IBidirectionalConverter<string, int>>();

            Expect.Call(converter2.Convert("5")).Return(5);
            Expect.Call(converter2.Convert("3")).Return(3);
            Expect.Call(converter2.Convert("7")).Return(7);

            mocks.ReplayAll();

            // Convert one way
            IList<int> input1 = new List<int> { 5, 3, 7 };
            var output1 = converter1.ConvertAll(input1);

            Assert.IsTrue(output1.Contains("5"));
            Assert.IsTrue(output1.Contains("3"));
            Assert.IsTrue(output1.Contains("7"));

            // Convert the other way
            IList<string> input2 = new List<string> { "5", "3", "7" };
            var output2 = converter2.ConvertAll(input2);

            Assert.IsTrue(output2.Contains(5));
            Assert.IsTrue(output2.Contains(3));
            Assert.IsTrue(output2.Contains(7));

            mocks.VerifyAll();
        }

        [Test]
        public void Enumerable_Should_Convert_All_Items_With_Specified_BidirectionalConverter()
        {
            var mocks = new MockRepository();
            var converter1 = mocks.StrictMock<IBidirectionalConverter<int, string>>();

            Expect.Call(converter1.Convert(5)).Return("5");
            Expect.Call(converter1.Convert(3)).Return("3");
            Expect.Call(converter1.Convert(7)).Return("7");

            var converter2 = mocks.StrictMock<IBidirectionalConverter<string, int>>();

            Expect.Call(converter2.Convert("5")).Return(5);
            Expect.Call(converter2.Convert("3")).Return(3);
            Expect.Call(converter2.Convert("7")).Return(7);

            mocks.ReplayAll();

            // Convert one way
            IList<int> input1 = new List<int> { 5, 3, 7 };
            var output1 = input1.Convert(converter1);

            Assert.IsTrue(output1.Contains("5"));
            Assert.IsTrue(output1.Contains("3"));
            Assert.IsTrue(output1.Contains("7"));

            // Convert the other way
            IList<string> input2 = new List<string> { "5", "3", "7" };
            var output2 = input2.Convert(converter2);

            Assert.IsTrue(output2.Contains(5));
            Assert.IsTrue(output2.Contains(3));
            Assert.IsTrue(output2.Contains(7));

            mocks.VerifyAll();
        }
    }

}