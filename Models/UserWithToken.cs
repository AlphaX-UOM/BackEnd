using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestorCodeFirstAPI.Models
{
    public class UserWithToken : User
    {
        public string Token { get; set; }

        public UserWithToken(User user)
        {
            
            this.ID = user.ID;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Password = user.Password;
            this.DOB = user.DOB;
            this.Address = user.Address;
            this.Email = user.Email;
            this.Contact = user.Contact;
            this.Role = user.Role;
            this.TransportServices = user.TransportServices;
            this.TourGuideServices = user.TourGuideServices;
            this.EventPlannerServices = user.EventPlannerServices;
            this.HotelsServices = user.HotelsServices;
            this.Reservations = user.Reservations;
            this.Cancellations = user.Cancellations;
            this.TransportServiceComments = user.TransportServiceComments;
            this.TourGuideServiceComments = user.TourGuideServiceComments;
            this.EventPlannerServiceComment = user.EventPlannerServiceComment;
            this.HotelsServiceComment = user.HotelsServiceComment;

        }
    }
}
