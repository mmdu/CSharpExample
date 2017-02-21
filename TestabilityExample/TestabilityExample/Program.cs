using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestabilityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderProcess = new OrderProcessor(new ShippingCalculator());
            var order = new Order { DatePlaced = DateTime.Now, TotalPrice = 200f };
            orderProcess.Process(order);
        }
    }
}
