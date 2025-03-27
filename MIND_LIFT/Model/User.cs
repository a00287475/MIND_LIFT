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
        public string UserId { get; set; }     // Gives a unique ID for the user from Firebase.
        public string Email { get; set; }     // User Email
        public string PasswordHash { get; set; } // Hashed Password
        public DateTime CreatedDate { get; set; } // Account creation timestamp
        public DateTime UpdatedDate { get; set; } // Last Updated timestamp
        public bool IsActive { get; set; } // Indicates whether the user is active or not


    }
}
