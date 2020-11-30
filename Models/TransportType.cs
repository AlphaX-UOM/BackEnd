using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class TransportType
    {
        public Guid ID { get; set; }
        public string VehicleType { get; set; }
        public int Count { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
