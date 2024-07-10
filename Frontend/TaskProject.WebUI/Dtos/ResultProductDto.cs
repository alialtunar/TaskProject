namespace TaskProject.WebUI.Dtos
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }
        public int categoryId { get; set; }
    }
}
