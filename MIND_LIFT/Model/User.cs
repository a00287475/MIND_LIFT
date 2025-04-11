using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIND_LIFT.Model
{
    // This class is used to Represent a user in the system with authentication details and account-related information
    public class User
    {
        public string UserId { get; set; }     // Gives a unique ID for the user from Firebase.
        public string Email { get; set; }     // User Email
        public string FirstName { get; set; }   // First name of the user
        public string LastName { get; set; }   // Last name of the user
        public string PasswordHash { get; set; } // Hashed Password  ------  have to removed later as it should only live in Firebase Auth
        public DateTime CreatedDate { get; set; } // Account creation timestamp
        public DateTime UpdatedDate { get; set; } // Last Updated timestamp
        public bool IsActive { get; set; } // Indicates whether the user is active or not


    }
}
