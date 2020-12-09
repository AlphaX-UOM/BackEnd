using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class EventPlannerServiceReservation : Reservation
    {
        public string EventType { get; set; }

        public Guid? EventPlannerServiceID { get; set; }
        public virtual EventPlannerService EventPlannerService { get; set; }
    }
}
