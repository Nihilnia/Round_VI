using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLibrary_v2._5.Models.Database
{
    public class Movie
    {
        //public Movie()
        //{
        //    this.Categories = new List<Category>();
        //}

        public int ID { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public List<Category> Categories { get; set; }

        //Put this list and.. USERID as fKey.
    }
}