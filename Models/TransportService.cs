using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class TransportService
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string Pnumber { get; set; }
        public string Description { get; set; }
        public Guid TransportTypeID { get; set; }
        public virtual TransportType TransportType { get; set; }
        public virtual List<TransportServiceReservation> TransportServiceReservations { get; set; }
    }
}
