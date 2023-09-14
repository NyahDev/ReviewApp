namespace ReviewApp.Models
{
    public class Pokemon
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Review> Reviews { get; set;}
        public ICollection<PkOwner> PkOwners { get; set;}
        public ICollection<PkCategory> pkCategories { get; set;}
    }
}
