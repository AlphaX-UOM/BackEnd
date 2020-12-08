using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class TransportServiceReservation : Reservation
    {
        
        public DateTime PickUpTime { get; set; }
        public string PickUpLocation { get; set; }
        public DateTime DropOffTime { get; set; }
        public string DropOffLocation { get; set; }
        public string VehicleType { get; set; }

        public Guid? TransportServiceID { get; set; }
        public virtual TransportService TransportService { get; set; }

    }
}
