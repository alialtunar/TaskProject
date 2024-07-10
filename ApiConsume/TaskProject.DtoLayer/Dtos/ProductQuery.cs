using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.DtoLayer.Dtos
{
    // Filtering queries to be sent to the method
    public class ProductQuery
    {
        public string? CategoryName { get; set; }
        public string? SearchTerm { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

    }

}
