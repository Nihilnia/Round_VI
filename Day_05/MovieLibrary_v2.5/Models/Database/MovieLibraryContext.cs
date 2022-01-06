using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLibrary_v2._5.Models.Database
{
    public class MovieLibraryContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source  = .\SQLEXPRESS; Initial Catalog = MovieLibrary_2dot5; Integrated Security = SSPI");
        }
    }
}