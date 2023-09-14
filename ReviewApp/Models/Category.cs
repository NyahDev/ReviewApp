namespace ReviewApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PkCategory> pkCategories { get; set; }
    }
}
