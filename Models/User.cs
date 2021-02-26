using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Role { get; set; }
        public string ImgURL { get; set; }

        public virtual List<TransportService> TransportServices { get; set; }
        public virtual List<TourGuideService> TourGuideServices { get; set; }
        public virtual List<EventPlannerService> EventPlannerServices { get; set; }
        public virtual List<HotelsService> HotelsServices { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        public virtual List<Cancellation> Cancellations { get; set; }
        public virtual List<TransportServiceComment> TransportServiceComments { get; set; }
        public virtual List<TourGuideServiceComment> TourGuideServiceComments { get; set; }
        public virtual List<EventPlannerServiceComment> EventPlannerServiceComment { get; set; }
        public virtual List<HotelsServiceComment> HotelsServiceComment { get; set; }
    }
}
