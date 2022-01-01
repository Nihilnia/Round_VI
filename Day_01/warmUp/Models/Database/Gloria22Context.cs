using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace warmUp.Models.Database
{
    public class Gloria22Context: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source  = .\SQLEXPRESS; Initial Catalog = SongsDB_04; Integrated Security = SSPI");
        }
    }
}