using System;
using System.Collections.Generic;

namespace eventPlanner.Models
{
    public partial class EventPlanner
    {
        public string EventId { get; set; }
        public string UserId { get; set; }
        public string EventName { get; set; }
        public DateTime? Date { get; set; }
        public string Venue { get; set; }
        public decimal Price { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string OtherDetails { get; set; }
        public string Comments { get; set; }
        public string Notifications { get; set; }

        public virtual Users User { get; set; }
    }
}
