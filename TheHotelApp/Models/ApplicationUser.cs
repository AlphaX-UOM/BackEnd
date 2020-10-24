﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHotelApp.Models;
using Microsoft.AspNetCore.Identity;

namespace TheHotelApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProfilePic { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}