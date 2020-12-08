using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class Cancellation
    {
        public Guid ID { get; set; }
        public bool IsApproved { get; set; }
        public DateTime Date { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public Guid? ReservationID { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
