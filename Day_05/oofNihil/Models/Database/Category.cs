namespace oofNihil.Models.Database
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Movie? Movie { get; set; }
        public int? MovieID { get; set; }
    }
}
