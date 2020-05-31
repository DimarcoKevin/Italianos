using Italianos.Logic;
using System;

namespace Logic
{
    public enum Status { Reserved = 0, Completed = 1, Canceled = 2}
    /* Created By Brandon Sheppard */
    public class Reservation
    {
        /// <summary>
        /// Unique ReservationID for the user
        /// </summary>
        public String ReservationId { get; internal set; }
        /// <summary>
        /// User object of the Reservation Host
        /// </summary>
        public User Host { get; internal set; }
        /// <summary>
        /// Table Number of Reservation
        /// </summary>
        public int TableNumber { get; internal set; }
        /// <summary>
        /// Date and Time of reservation
        /// </summary>
        public DateTime ReservationDate { get; internal set; }
        /// <summary>
        /// Item object of the Appetizer
        /// </summary>
        public Item Appetizer { get; internal set; }
        /// <summary>
        /// Item object of the Main
        /// </summary>
        public Item Main { get; internal set; }
        /// <summary>
        /// Item object of the Dessert
        /// </summary>
        public Item Dessert { get; internal set; }
        /// <summary>
        /// Number of Guests
        /// </summary>
        public int NumberOfGuests { get; internal set; }
        /// <summary>
        /// Date and Time of Request
        /// </summary>
        public DateTime RequestDate { get; internal set; }
        /// <summary>
        /// Status of the Request
        /// </summary>
        public Status Status { get; internal set; }
        /// <summary>
        /// Constructor to create a Reservation Object
        /// </summary>
        /// <param name="resId"></param>
        /// <param name="host"></param>
        /// <param name="tableNum"></param>
        /// <param name="resDate"></param>
        /// <param name="appetizer"></param>
        /// <param name="main"></param>
        /// <param name="dessert"></param>
        /// <param name="numOfGuests"></param>
        /// <param name="reqDate"></param>
        /// <param name="status"></param>
        public Reservation(String resId, User host, int tableNum, DateTime resDate, Item appetizer,
                            Item main, Item dessert, int numOfGuests, DateTime reqDate, Status status)
        {
            ReservationId = resId;
            Host = host;
            TableNumber = tableNum;
            ReservationDate = resDate;
            Appetizer = appetizer;
            Main = main;
            Dessert = dessert;
            NumberOfGuests = numOfGuests;
            RequestDate = reqDate;
            Status = status;
        }

        /// <summary>
        /// ToString to print reservation in string format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Reservation '{ReservationId}', Host '{Host.FirstName}', Table Number '{TableNumber}', Appetizer: {Appetizer}, Main: {Main}, Dessert: {Dessert}, Number of Guests: {NumberOfGuests}";
        }
    }
}
