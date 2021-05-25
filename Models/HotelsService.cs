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
        public string AddressLine01 { get; set; }
        public string AddressLine02 { get; set; }
        public decimal PricePerDay { get; set; }
        public string District { get; set; }
        public string Pnumber { get; set; }
        public string ContactName { get; set; }
        public string AltPnumber { get; set; }
        public string Languages { get; set; }
        public string RoomType { get; set; }
        public int NumOfRooms { get; set; }
        public string BedType { get; set; }
        public int Capacity { get; set; }
        public int Stars { get; set; }
        public string Features { get; set; }
        public string Amenities { get; set; }
        public string OtherDetails { get; set; }
        public string HotelImgURL { get; set; }
        public string RoomImgURL01 { get; set; }
        public string RoomImgURL02 { get; set; }
        public string RoomImgURL03 { get; set; }


        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public virtual List<HotelsServiceReservation> HotelsServiceReservations { get; set; }
        public virtual List<HotelsServiceComment> HotelsServiceComments { get; set; }
        public virtual List<HotelsServiceRating> HotelsServiceRatings { get; set; }
    }
}
