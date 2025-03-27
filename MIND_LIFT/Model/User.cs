using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.Util;

namespace MIND_LIFT.Model
{
    // This class is used to Represent a user in the system with authentication details and account-related information
    public class User
    {
        public string UserId { get; set; }     // Gives a unique ID for the user.
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }


    }
}
