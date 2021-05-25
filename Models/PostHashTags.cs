using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class PostHashTags
    {
        public Guid? EventPlannerServiceID { get; set; }
        public EventPlannerService EventPlannerService { get; set; }
        public Guid? HashTagID { get; set; }
        public HashTag HashTag { get; set; }
    }
}
