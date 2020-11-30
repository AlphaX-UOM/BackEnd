using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class TransportServiceReservation
    {
        public Guid ID { get; set; }
        public Guid ReservationID { get; set; }
        public virtual Reservation Reservation { get; set; }
        public Guid TransportServiceID { get; set; }
        public virtual TransportService TransportService { get; set; }
        public DateTime PickUpTime { get; set; }
        public string PickUpLocation { get; set; }
        public DateTime DropOffTime { get; set; }
        public string DropOffLocation { get; set; }
        public string VehicleType { get; set; }

    }
}
