using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class TransportServiceRating
    {
        public Guid ID { get; set; }
        public int Rating { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public Guid? TransportServiceID { get; set; }
        public virtual TransportService TransportService { get; set; }
    }
}
