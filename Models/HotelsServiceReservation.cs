using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class HotelsServiceReservation
    {
        public Guid ID { get; set; }
        public Guid ReservationID { get; set; }
        public virtual Reservation Reservation { get; set; }
        public Guid HotelsServiceID { get; set; }
        public virtual HotelsService HotelsService { get; set; }
        public string RoomType { get; set; }
    }
}
