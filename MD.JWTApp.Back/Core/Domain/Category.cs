namespace MD.JWTApp.Back.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Definiton { get; set; }
        public List<Product>? Products { get; set; }

       
    }
}
