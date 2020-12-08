using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class Payment
    {
        public Guid ID { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public DateTime Date { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
    }
}
