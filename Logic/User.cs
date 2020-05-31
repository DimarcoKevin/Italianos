using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace Italianos.Logic
{
    public enum Role { USER = 0, ADMIN = 1 }
    /* Created By Kevin Dimarco */
    public class User
    {   
        /// <summary>
        /// Unique User ID
        /// </summary>
        public int UserId { get; internal set; }
        /// <summary>
        /// First Name of the User
        /// </summary>
        public String FirstName { get; internal set; }
        /// <summary>
        /// Last Name of User
        /// </summary>
        public String LastName { get; internal set; }
        /// <summary>
        /// Email of User
        /// </summary>
        public String Email { get; internal set; }
        /// <summary>
        /// Phone Number of the User
        /// </summary>
        public String PhoneNumber { get; internal set; }
        /// <summary>
        /// Boolean Property to determine if users email is verified
        /// </summary>
        public bool Verified { get; internal set; }
        /// <summary>
        /// Role of the User
        /// </summary>
        public Role Role { get; internal set; }


        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="email"></param>
        /// <param name="number"></param>
        /// <param name="verified"></param>
        /// <param name="role"></param>
        public User(int id, String fname, String lname, String email, String number, bool verified, Role role)
        {
            UserId = id;
            FirstName = fname;
            LastName = lname;
            Email = email;
            PhoneNumber = number;
            Verified = verified;
            Role = role;
        }
        /// <summary>
        /// Property dump of user
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"ID: {UserId}, Name: {FirstName} {LastName}, Email: {Email}, " +
                $"Phone Number: {PhoneNumber}";
        }
    }
}
