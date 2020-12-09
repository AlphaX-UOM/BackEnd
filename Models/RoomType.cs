using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class RoomType
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int NumOfGuests { get; set; }
        public string Specs { get; set; }
        public decimal BasePricePerDay { get; set; }
        public int Count { get; set; }
        public virtual List<HotelServiceRoomType> HotelServiceRoomTypes { get; set; }
    }
}
