using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class TourGuideServiceReservation
    {
        public Guid ID { get; set; }
        public Guid ReservationID { get; set; }
        public virtual Reservation Reservation { get; set; }
        public Guid TourGuideServiceID { get; set; }
        public virtual TourGuideService TourGuideService { get; set; }
    }
}
