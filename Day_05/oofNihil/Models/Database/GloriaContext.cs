using Microsoft.EntityFrameworkCore;

namespace oofNihil.Models.Database
{
    public class GloriaContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source  = .\SQLEXPRESS; Initial Catalog = learningcore; Integrated Security = SSPI");
        }
    }
}
