using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class HotelServiceRoomType
    {
        public Guid? HotelServiceId { get; set; }
        public virtual HotelsService HotelsService { get; set; }

        public Guid? RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
