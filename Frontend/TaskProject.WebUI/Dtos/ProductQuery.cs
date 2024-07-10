namespace TaskProject.WebUI.Dtos
{
    public class ProductQuery
    {
        public string categoryName { get; set; }
        public string searchTerm { get; set; }
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }
    }
}
