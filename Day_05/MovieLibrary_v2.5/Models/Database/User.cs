using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieLibrary_v2._5.Models.Database
{
    public class User
    {
        public User()
        {
            this.Movies = new List<Movie>();
        }

        [Key]
        public int ID { get; set; }

        [MaxLength(20)]
        public string UserName { get; set; }

        public string Password { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string EMail { get; set; }
        public string ProfilePic { get; set; }

        public int Role { get; set; }
        public List<Movie> Movies { get; set; }
    }
}