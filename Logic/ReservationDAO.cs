using Italianos.App_Data.RestaurantDataSetTableAdapters;
using Italianos.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using static Italianos.App_Data.RestaurantDataSet;

/* Created By Brandon Sheppard */
namespace Logic
{
    class ReservationDAO
    {
        /// <summary>
        /// SQL Reservation Adapter
        /// </summary>
        private ReservationTableAdapter _reservationAdapter;
        /// <summary>
        /// SQL Reservation Table
        /// </summary>
        private ReservationDataTable _reservationTable;
        /// <summary>
        /// SQL Item Adapter
        /// </summary>
        private ItemTableAdapter _itemAdapter;
        /// <summary>
        /// SQL Item Table
        /// </summary>
        private ItemDataTable _itemTable;
        /// <summary>
        /// UserDao class for user information access
        /// </summary>
        private UserDao _userDao;
        /// <summary>
        /// Random class
        /// </summary>
        static Random _rng;
        /// <summary>
        /// Generates a 6 digit hexidecimal number used for Reservation IDs.
        /// </summary>
        /// <returns></returns>
        public string GenerateReservationId()
        {
            //Length of generated code.
            const int idLength = 6;
            //Code to give sender
            string output = "";
            List<String> ids = new List<String>();
            foreach(DataRow r in _reservationTable)
            {
                ids.Add(r.Field<String>(0));
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
        /// Default Constructor.
        /// </summary>
        public ReservationDAO()
        {
            _userDao = new UserDao();
            _reservationAdapter = new ReservationTableAdapter();
            _reservationTable = new ReservationDataTable();
            _reservationAdapter.Fill(_reservationTable);
            _itemAdapter = new ItemTableAdapter();
            _itemTable = new ItemDataTable();
            _itemAdapter.Fill(_itemTable);
            _rng = new Random();
        }
        /// <summary>
        /// Returns a list of Item Names where the item
        /// is available.
        /// </summary>
        /// <returns></returns>
        public List<String> GetAvailableItems()
        {
            List<String> items = new List<String>();
            foreach(DataRow r in _itemTable.Rows)
            {
                items.Add(r.Field<String>(0));
            }
            return items;
        }
        /// <summary>
        /// Returns a list of Item Names where the item
        /// is available, for a specific course.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public List<String> GetAvailableItems(Course course)
        {
            List<String> items = new List<String>();
            foreach (DataRow r in _itemTable.Rows)
            {
                if(r.Field<Course>(3) == course)
                {
                    if (r.Field<bool>(2) == true)
                    {
                        items.Add(r.Field<String>(0));
                    }
                }
            }
            return items;
        }
        /// <summary>
        /// Returns an integer list of tables
        /// available for a given date and time.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<int> TablesAvailable(DateTime dt)
        {
            List<int> tableNums = new List<int>();
            for(int i = 0; i < 12; i++)
            {
                tableNums.Add(i + 1);
            }
            foreach (DataRow r in _reservationTable)
            {
                if(r.Field<DateTime>(3).Date == dt.Date
                    && r.Field<Status>(9) == Status.Reserved)
                {
                    tableNums.Remove(r.Field<int>(2));
                }
            }
            return tableNums;
        }
        /// <summary>
        /// Returns a DataTable view of all Items
        /// </summary>
        /// <returns></returns>
        public DataTable GetItems()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Item Name");
            dt.Columns.Add("Category");
            dt.Columns.Add("Course");
            foreach(DataRow r in _itemTable.Rows)
            {
                DataRow row = dt.NewRow();
                row[0] = r.Field<String>(0);
                row[1] = r.Field<Category>(1);
                row[2] = r.Field<Course>(3);
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// Creates a new item in the Database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cat"></param>
        /// <param name="course"></param>
        /// <param name="desc"></param>
        public void AddItem(string name, Category cat, Course course, String desc)
        {
            _itemAdapter.Insert(name, (int)cat, true, (int)course, desc);
            _itemAdapter.Update(_itemTable);
        }

        /// <summary>
        /// Returns an Item given the unique item ID.
        /// Returns null if the item name does not exist.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Item GetItemByName(string name)
        {
            foreach(DataRow r in _itemTable.Rows)
            {
                if(r.Field<string>(0) == name)
                {
                    return new Item(
                           r.Field<String>(0),
                           r.Field<Category>(1),
                           r.Field<bool>(2),
                           r.Field<Course>(3),
                           r.Field<String>(4));
                }
            }
            return null;
        }
        /// <summary>
        /// Returns a DataTable View of reservations associated
        /// to a given user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetReservationsByUserId(int id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Reservation ID");
            dt.Columns.Add("Appetizer");
            dt.Columns.Add("Main");
            dt.Columns.Add("Dessert");
            foreach(DataRow r in _reservationTable.Rows)
            {
                if(r.Field<int>(1) == id)
                {
                    DataRow row = dt.NewRow();
                    row[0] = r.Field<string>(0);
                    row[1] = r.Field<string>(4);
                    row[2] = r.Field<string>(5);
                    row[3] = r.Field<string>(6);
                    dt.Rows.Add(row);
                }
            }
            return dt; // Reservation was not found;
        }
        /// <summary>
        /// Returns a reservation object associated with a 
        /// ReservationID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Reservation GetReservationByReservationId(string id)
        { 
            foreach (DataRow r in _reservationTable.Rows)
            {
                if(r.Field<string>(0) == id)
                    return new Reservation(
                                r.Field<String>(0),
                                _userDao.GetUserById(r.Field<int>(1)),
                                r.Field<int>(2),
                                r.Field<DateTime>(3),
                                GetItemByName(r.Field<string>(4)),
                                GetItemByName(r.Field<string>(5)),
                                GetItemByName(r.Field<string>(6)),
                                r.Field<int>(7),
                                r.Field<DateTime>(8),
                                r.Field<Status>(9));
            }
            return null; // Reservation was not found;

        }
        /// <summary>
        /// Creates a new reservationID with the given parameters.
        /// </summary>
        /// <param name="hostId"></param>
        /// <param name="reservationDate"></param>
        /// <param name="tableNumber"></param>
        /// <param name="appetizer"></param>
        /// <param name="main"></param>
        /// <param name="dessert"></param>
        /// <param name="numOfGuests"></param>
        /// <returns></returns>
        public int CreateReservation(int hostId, DateTime reservationDate, int tableNumber, string appetizer, string main, string dessert, int numOfGuests)
        {
            /* Tables are booked in blocks of 2 hours.
             * To determine if a reservation is correct
             * we must check if a specific table has been
             * booked on the given day, for the given block
             * of time (4pm-6pm, 6pm-8pm, 8pm-10pm). */
            foreach (DataRow r in _reservationTable.Rows)
            {
                if (r.Field<DateTime>(3) == reservationDate && r.Field<int>(2) == tableNumber)
                    return 1; //Reservation could not be made becasue table is already booked
                else if (r.Field<int>(1) == hostId && r.Field<DateTime>(3) == reservationDate)
                    return 2; //Reservation could not be made because customer already has reservation
            }

            _reservationAdapter.Insert(GenerateReservationId(),hostId, tableNumber, reservationDate, appetizer, main, dessert, numOfGuests, DateTime.Now,(int) Status.Reserved);
            _reservationAdapter.Update(_reservationTable);
            return 0; //Added
        }
        /// <summary>
        /// Cancels a reservation with a given ReservationID
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        public int DisableReservation(string reservationId)
        {
            foreach(DataRow r in _reservationTable.Rows)
            {
                if(r.Field<string>(0) == reservationId)
                {
                    r["Status"] = Status.Canceled;
                    _reservationAdapter.Update(_reservationTable);
                    return 0;
                }
            }
            return 0; //Ran successfully
        }
        /// <summary>
        /// Method updates an item giving its new availability.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="isAvailable"></param>
        public void UpdateItem(string itemName, bool isAvailable)
        {
            DataRow row = _itemTable.Rows.Find(itemName);
            if (!row.Field<bool>(2) == isAvailable)
            {
                row["Available"] = isAvailable;
                _itemAdapter.Update(_itemTable);
            }
        }
        /// <summary>
        /// Reads all reservations from the database
        /// </summary>
        /// <returns></returns>
        public List<Reservation> ReadAll()
        {
            List<Reservation> reservationList = new List<Reservation>();

            foreach (DataRow r in _reservationTable.Rows)
            {
                reservationList.Add(new Reservation(
                            r.Field<string>(0),
                            _userDao.GetUserById(r.Field<int>(1)),
                            r.Field<int>(2),
                            r.Field<DateTime>(3),
                            GetItemByName(r.Field<string>(4)),
                            GetItemByName(r.Field<string>(5)),
                            GetItemByName(r.Field<string>(6)),
                            r.Field<int>(7),
                            r.Field<DateTime>(8),
                            r.Field<Status>(9)));
            }
            return reservationList;
        }

        public List<Reservation> ReadAll(Status status)
        {
            List<Reservation> reservationList = new List<Reservation>();

            foreach (DataRow r in _reservationTable.Rows)
            {
                if((Status) r["Status"] == status)
                {
                    reservationList.Add(new Reservation(
                            r.Field<string>(0),
                            _userDao.GetUserById(r.Field<int>(1)),
                            r.Field<int>(2),
                            r.Field<DateTime>(3),
                            GetItemByName(r.Field<string>(4)),
                            GetItemByName(r.Field<string>(5)),
                            GetItemByName(r.Field<string>(6)),
                            r.Field<int>(7),
                            r.Field<DateTime>(8),
                            r.Field<Status>(9)));
                }
                
            }
            return reservationList;
        }
        /// <summary>
        /// Returns the reservations assocaited with this user.
        /// If this user is an admin, they will instead see upcoming
        /// reservations.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetReservations(int id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Reservation ID");
            dt.Columns.Add("Table Number");
            dt.Columns.Add("Reservation Date");
            dt.Columns.Add("Time Slot");
            dt.Columns.Add("Appetizer");
            dt.Columns.Add("Main");
            dt.Columns.Add("Dessert");
            dt.Columns.Add("Number Of Guests");
            dt.Columns.Add("Status");
            User user = _userDao.GetUserById(id);
            if (user.Role == Role.USER)
            {
                foreach (Reservation r in ReadAll())
                {
                    if(r.Host.UserId == id)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = r.ReservationId;
                        row[1] = r.TableNumber;
                        row[2] = r.ReservationDate.Date;
                        row[3] = r.ReservationDate.TimeOfDay;
                        row[4] = r.Appetizer.Name;
                        row[5] = r.Main.Name;
                        row[6] = r.Dessert.Name;
                        row[7] = r.NumberOfGuests;
                        row[8] = r.Status;
                    }

                }
            }
            else
            {
                foreach (Reservation r in ReadAll())
                {
                    if(r.Status == Status.Reserved)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = r.ReservationId;
                        row[1] = r.TableNumber;
                        row[2] = r.ReservationDate.Date;
                        row[3] = r.ReservationDate.TimeOfDay;
                        row[4] = r.Appetizer.Name;
                        row[5] = r.Main.Name;
                        row[6] = r.Dessert.Name;
                        row[7] = r.NumberOfGuests;
                        row[8] = r.Status;
                    }
                }
            }
            return dt;
        }
    }
}
