using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestabilityExample
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DatePlaced { get; set; }
        public Shipment Shipment { get; set; }  // Interesting, checking the Shipment Class 
        public float TotalPrice { get; set; }
        public bool IsShipped
        {
            get { return Shipment != null; }

        }
    }
}
