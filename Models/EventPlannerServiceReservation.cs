using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class EventPlannerServiceReservation
    {
        public Guid ID { get; set; }
        public Guid ReservationID { get; set; }
        public virtual Reservation Reservation { get; set; }
        public Guid EventPlannerServiceID { get; set; }
        public virtual EventPlannerService EventPlannerService { get; set; }
        public string EventType { get; set; }
    }
}
