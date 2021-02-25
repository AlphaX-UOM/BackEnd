using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class HotelsService
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public decimal PricePerDay { get; set; }
        public string District { get; set; }
        public string Pnumber { get; set; }
        public string Features { get; set; }
        public string OtherDetails { get; set; }
        public string ImgURL { get; set; }

        public Guid? RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public virtual List<HotelsServiceReservation> HotelsServiceReservations { get; set; }
        public virtual List<HotelsServiceComment> HotelsServiceComments { get; set; }
        public virtual List<HotelServiceRoomType> HotelServiceRoomTypes { get; set; }
    }
}
