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
        public string Email { get; set; }
        public string Address { get; set; }
        public string VehicleType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string NoOfSeats { get; set; }
        public Boolean AirCondition { get; set; }
        public string PricePer1KM { get; set; }
        public decimal PricePerDay { get; set; }
        public string Description { get; set; }
        public string ImgURL { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public virtual List<TransportServiceReservation> TransportServiceReservations { get; set; }
        public virtual List<TransportServiceComment> TransportServiceComments { get; set; }
    }
}
