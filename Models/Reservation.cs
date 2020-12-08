using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class Reservation
    {
        public Guid ID { get; set; }
        public int NumOfTravellers { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Price { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public Guid? PaymentID { get; set; }
        public virtual Payment Payment { get; set; }

        public virtual Cancellation Cancellation { get; set; }
    }
}
