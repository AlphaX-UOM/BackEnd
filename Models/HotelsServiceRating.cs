using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class HotelsServiceRating
    {
        public Guid ID { get; set; }
        public int Rating { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        public Guid? HotelsServiceID { get; set; }
        public virtual HotelsService HotelsService { get; set; }
    }
}
