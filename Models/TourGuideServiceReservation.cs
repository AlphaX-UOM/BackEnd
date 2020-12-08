using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class TourGuideServiceReservation : Reservation
    {
        public Guid? TourGuideServiceID { get; set; }
        public virtual TourGuideService TourGuideService { get; set; }
        
    }
}
