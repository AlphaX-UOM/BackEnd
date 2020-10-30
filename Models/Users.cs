using System;
using System.Collections.Generic;

namespace eventPlanner.Models
{
    public partial class Users
    {
        public Users()
        {
            EventPlanner = new HashSet<EventPlanner>();
        }

        public string UserId { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime? Dob { get; set; }
        public string HouseNo { get; set; }
        public string Lane { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }

        public virtual ICollection<EventPlanner> EventPlanner { get; set; }
    }
}
