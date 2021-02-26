using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class TourGuideService
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Language { get; set; }
        public decimal CostPerDay { get; set; }
        public string Pnumber { get; set; }
        public string OtherDetails { get; set; }
        public string ImgURL { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public virtual List<TourGuideServiceReservation> TourGuideServiceReservations { get; set; }
        public virtual List<TourGuideServiceComment> TourGuideServiceComments { get; set; }
    }
}
