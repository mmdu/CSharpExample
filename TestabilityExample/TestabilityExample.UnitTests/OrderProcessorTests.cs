using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestabilityExample;

namespace TestabilityExample.UnitTests
{
    [TestClass]
    public class OrderProcessorTests
    {
        //methode name _condition_expectaion
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Proecess_OrderIsAlreadyShipped_THrowAnException()
        {
            var orderProcessor = new OrderProcessor(new FakeShippingCalculator());

            // create an order is already shipped,  Isshipped, return shippment is not null 
            var order = new Order
            {
                Shipment = new Shipment()
            };

            orderProcessor.Process(order);
       

        }
        [TestMethod]
        public void Process_OrderIsNotShipped_ShouldSetTheshipmentPropertyOfTheOrder()
        {
            var orderProcessor = new OrderProcessor(new FakeShippingCalculator());
            //not initialize the shipment property,  Isshiped is false 
            var order = new Order();
            orderProcessor.Process(order);
            Assert.IsTrue(order.IsShipped);
            Assert.AreEqual(1, order.Shipment.Cost);
            Assert.AreEqual(DateTime.Today.AddDays(2), order.Shipment.ShippingDate);
        }
    }


    public class FakeShippingCalculator : IShippingCalculator
    {
        public float CalculateShipping(Order order)
        {
            return 1;
        }
    }
}
