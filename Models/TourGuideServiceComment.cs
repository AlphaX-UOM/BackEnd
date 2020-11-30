using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class TourGuideServiceComment
    {
        public Guid ID { get; set; }
        public Guid TourGuideServiceID { get; set; }
        public virtual TourGuideService TourGuideService { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
    }
}
