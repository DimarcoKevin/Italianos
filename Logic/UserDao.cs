using Italianos.App_Data.RestaurantDataSetTableAdapters;
using Italianos.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows;
using static Italianos.App_Data.RestaurantDataSet;

/* Class Created By Kevin Dimarco */
namespace Logic
{

    public class UserDao
    {
        /// <summary>
        /// SQL User Adapter
        /// </summary>
        private UserTableAdapter _userAdapter;
        /// <summary>
        /// SQL User Table
        /// </summary>
        private UserDataTable _userTable;
        /// <summary>
        /// Random class
        /// </summary>
        private static Random _rng;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserDao()
        {
            _userAdapter = new UserTableAdapter();
            _userTable = new UserDataTable();
            _userAdapter.Fill(_userTable);
            _rng = new Random();
        }
        /// <summary>
        /// Generates a verification code.
        /// </summary>
        /// <returns></returns>
        public string GenerateVerificationCode()
        {
            //Length of generated code.
            const int idLength = 6;
            //Code to give sender
            string output = "";
            List<String> ids = new List<String>();
            foreach (DataRow r in _userTable)
            {
                ids.Add(r.Field<String>(8));
            }
            //Character set of available characters
            const string characters = "0123456789ABCDEF";
            do
            {
                for (int i = 0; i < idLength; i++)
                {
                    //Add random character to the array of characters
                    char[] chars = characters.ToCharArray();
                    output += chars[_rng.Next(0, characters.Length)];
                }
            }
            while (ids.Contains(output.ToString())); //End when Game Id is unique
            return output;
        }
        /// <summary>
        /// Verifies email given ID
        /// </summary>
        /// <param name="id"></param>
        public void VerifyEmail(string id)
        {
            foreach(DataRow r in _userTable.Rows)
            {
                if((String) r["VerificationCode"] == id)
                {
                    r["Verified"] = true;
                    _userAdapter.Update(_userTable);
                }
            }
        }
        /// <summary>
        /// Returns true if an email and password match.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsAuthentic(string email, string password)
        {
            foreach (DataRow r in _userTable.Rows)
            {
                
                if (r.Field<string>(3).Equals(email) && encrypt(password).Equals(r.Field<string>(7)))
                {
                    return true;
                }
                    
            }
            return false;
        }

        /// <summary>
        /// Returns true if given email exists
        /// </summary>
        /// <param name="txtEmail"></param>
        /// <returns></returns>
        public bool EmailExists(string txtEmail)
        {
            foreach(DataRow r in _userTable.Rows)
            {
                if (r.Field<String>(3) == txtEmail)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns an encrypted password given a string.
        /// </summary>
        /// <param name="stringToEncrypt"></param>
        /// <returns></returns>
        public static string encrypt(string stringToEncrypt)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding uft8 = new UTF8Encoding();
                return Convert.ToBase64String(md5.ComputeHash(uft8.GetBytes(stringToEncrypt)));
            }
        }

        /// <summary>
        /// Returns the user given the user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            foreach (DataRow r in _userTable.Rows)
            {
                if(r.Field<int>(0) == id)
                {
                    string fname = r.Field<string>(1);
                    string lname = r.Field<string>(2);
                    string email = r.Field<string>(3);
                    string phoneNumber = r.Field<string>(4);
                    bool verified = r.Field<bool>(5);
                    Role role = r.Field<Role>(6);
                    return new User(id, fname, lname, email, phoneNumber, verified, role);
                }
                
            }
            return null;
        }

        /// <summary>
        /// Returns a user if email and password match.
        /// Returns null if user doesn't exist.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(String email, String password)
        {
            foreach (DataRow r in _userTable.Rows)
            {
                if(r.Field<String>(3) == email && encrypt(password) == r.Field<String>(7)) 
                {
                    int id = r.Field<int>(0);
                    string fname = r.Field<string>(1);
                    string lname = r.Field<string>(1);
                    string phoneNumber = r.Field<string>(4);
                    bool verified = r.Field<bool>(5);
                    return new User(id, fname, lname, email, phoneNumber, verified, (Role) r.Field<int>(6));
                }
            }
            return null;
        }

        /// <summary>
        /// Registers a user given account information.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="number"></param>
        /// <param name="verificationCode"></param>
        public void Register(String email, String password, String fname, String lname, String number, String verificationCode)
        {
            _userAdapter.Insert(fname, lname, email, number, false, 0, encrypt(password), verificationCode);
            _userAdapter.Update(_userTable);
        }

        /// <summary>
        /// Reads all users from the database.
        /// </summary>
        /// <returns></returns>
        public List<User> ReadAll()
        {
           List<User> users = new List<User>();
           foreach(DataRow r in _userTable.Rows)
           {
                int id = r.Field<int>(0);
                string fname = r.Field<string>(1);
                string lname = r.Field<string>(1);
                string email = r.Field<string>(3);
                string phoneNumber = r.Field<string>(4);
                bool verified = r.Field<bool>(5);
                Role role = r.Field<Role>(6);
                users.Add(new User(id, fname, lname, email, phoneNumber, verified, role));
           }
            return users;
        }
    }
}