using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace warmUp.Models.Database
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(20)]
        public int Name { get; set; }

        [MaxLength(20)]
        public string Pass { get; set; }
    }
}