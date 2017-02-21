using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestabilityExample
{
    public  class OrderProcessor
    { 
        private readonly IShippingCalculator _shippingCalculator;
         
  
        // reference to Interface :  loose coupling 
        public OrderProcessor(IShippingCalculator shippingCalculator )
        {
            _shippingCalculator =  shippingCalculator;
        }

        public void Process(Order order)
        {
            if (order.IsShipped)

             throw new InvalidOperationException("THis order is already processed");

            order.Shipment = new Shipment
            {
                Cost = _shippingCalculator.CalculateShipping(order),
                ShippingDate=DateTime.Today.AddDays(2)
 
            };
                 
        }
    }
}
