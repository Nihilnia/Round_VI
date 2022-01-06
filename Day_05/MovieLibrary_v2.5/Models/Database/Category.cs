using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLibrary_v2._5.Models.Database
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Movie Movie { get; set; }
        public int MovieID { get; set; }
    }
}