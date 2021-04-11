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
            
        

        }
    }
}
