namespace oofNihil.Models.Database
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public User? User { get; set; }
        public int? UserID { get; set; }
    }
}
