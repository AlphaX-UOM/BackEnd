using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class EventPlannerService
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string EventType { get; set; }
        public string OtherDetails { get; set; }
        public string ImgURL { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public virtual List<EventPlannerServiceReservation> EventPlannerServiceReservations { get; set; }
        public virtual List<EventPlannerServiceComment> EventPlannerServiceComments { get; set; }
    }
}
