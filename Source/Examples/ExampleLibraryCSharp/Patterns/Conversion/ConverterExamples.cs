/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using NGenerics.Patterns.Conversion;
using NUnit.Framework;

namespace ExampleLibraryCSharp.Patterns.Conversion {

    [TestFixture]
    public class ConverterExamples {

        #region Convert

        [Test]
        public void ConvertExample() {
            var converter = new OrderConverter();
            var order = new Order
            {
                OrderDate = DateTime.Now,
                LineItems = new[] {
                       new OrderLineItem { Amount = 20.2M, Description = "Item 1" },
                       new OrderLineItem { Amount = 14.43M, Description = "Item 2" }
                  }
            };


            var dto = converter.Convert(order);

            Assert.AreEqual(dto.OrderDate, order.OrderDate);
            Assert.AreEqual(dto.Total, 34.63M);
        }

        public class OrderConverter : IConverter<Order, OrderDto> {
            public OrderDto Convert(Order input) {

                return new OrderDto
                {
                    OrderDate = input.OrderDate,
                    Total = input.Total
                };
            }
        }

        public class Order {

            public DateTime OrderDate { get; set; }
            public IList<OrderLineItem> LineItems { get; set; }

            public decimal Total {
                get {
                    decimal total = 0;

                    if (LineItems == null) {
                        return total;
                    }

                    foreach (var lineItem in LineItems) {
                        total += lineItem.Amount;
                    }

                    return total;
                }
            }
        }

        public class OrderLineItem {
            public string Description { get; set; }
            public decimal Amount { get; set; }
        }

        public class OrderDto {
            public DateTime OrderDate { get; set; }
            public decimal Total { get; set; }
        }

        #endregion
    }
}
