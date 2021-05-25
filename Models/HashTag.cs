using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class HashTag
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<PostHashTags> PostHashTags { get; set; }
    }
}
