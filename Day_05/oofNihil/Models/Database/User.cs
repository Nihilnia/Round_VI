using System.ComponentModel.DataAnnotations;

namespace oofNihil.Models.Database
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EMail { get; set; }
        public string? ProfilePic { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
