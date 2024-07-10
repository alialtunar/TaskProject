using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TaskProject.WebUI.Dtos;

namespace TaskProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: Retrieve unfiltered data with empty query
        public async Task<IActionResult> Index()
        {
            // Get products with empty query
            var products = await GetProducts(new ProductQuery
            {
                categoryName = "",
                searchTerm = "",
                minPrice = null,
                maxPrice = null
            });

            // Send products to ViewBag
            ViewBag.Products = products;

            
            return View(new ProductQuery());
        }

        // POST: Method to fetch filtered data with query parameters
        [HttpPost]
        public async Task<IActionResult> Index(ProductQuery query)
        {
            // Get products with form data
            var products = await GetProducts(query);

            // Send products with ViewBag
            ViewBag.Products = products;


            return View(query);
        }
        // Method to fetch data according to queries via API
        private async Task<List<ResultProductDto>> GetProducts(ProductQuery query)
        {
            // Create HTTP client instance using HttpClientFactory
            var client = _clientFactory.CreateClient();

            // Send a POST request with the query object serialized as JSON
            var response = await client.PostAsJsonAsync("http://localhost:5126/api/products/query", query);

            // Enter block if request successful
            if (response.IsSuccessStatusCode)
            {
                // Get response content as JSON
                var json = await response.Content.ReadAsStringAsync();

                // Parse JSON string into List<ResultProductDto> object
                var products = JsonSerializer.Deserialize<List<ResultProductDto>>(json);

                // Make sure you get the products
                if (products == null)
                {
                    products = new List<ResultProductDto>();
                }

                return products;
            }
            // Return empty list if request failed
            return new List<ResultProductDto>();
        }
    }
}
