using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* Created By Brandon Sheppard */
namespace Italianos.Logic
{
    public enum Category { Meats = 0, Pastas = 1, Pizza = 2, Breads = 3, Soups = 4, Salads = 5, Desserts = 6 }
    public enum Course { Appetizer = 0, Main = 1, Dessert = 2 }
    /* Created By Kevin Dimarco */
    public class Item
    {
        /// <summary>
        /// Unique name of the Item
        /// </summary>
        public String Name { get; internal set; }
        /// <summary>
        /// Category of the Item
        /// </summary>
        public Category Category { get; internal set; }
        /// <summary>
        /// Availability of the Item in boolean format
        /// </summary>
        public Boolean Available { get; internal set; }
        /// <summary>
        /// Course of the Item
        /// </summary>
        public Course Course { get; internal set; }
        /// <summary>
        /// Description of the Item
        /// </summary>
        public String Description { get; internal set; }
        /// <summary>
        /// Constructor to create Item Object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="available"></param>
        /// <param name="course"></param>
        /// <param name="description"></param>
        public Item(string name, Category category, bool available, Course course, String description)
        {
            Name = name;
            Category = category;
            Available = available;
            Course = course;
            Description = description;
        }
        /// <summary>
        /// ToString function to print the item in string format
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"{Name}, {Category}, {Available}, {Course}";
        }
    }
}