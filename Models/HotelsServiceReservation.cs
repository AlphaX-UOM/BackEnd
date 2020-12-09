using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class HotelsServiceReservation : Reservation
    {
        public string RoomType { get; set; }
        public int NoOfRooms { get; set; }

        public Guid? HotelsServiceID { get; set; }
        public virtual HotelsService HotelsService { get; set; }
    }
}
