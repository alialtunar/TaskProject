using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.DataAccessLayer.Abstract;
using TaskProject.DataAccessLayer.Concreate;
using TaskProject.DtoLayer.Dtos;
using TaskProject.EntityLayer.Concreate;

namespace TaskProject.DataAccessLayer.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        private readonly TaskDbContext _context;

        public EfProductDal(TaskDbContext context)
        {
            _context = context;
        }

        // Method used to access the database to filter and list products
        public List<ResultProductDto> GetProducts(ProductQuery query)
        {
            IQueryable<Product> products = _context.Products;

            //CategoryName all, filter by category if not empty or null
            if (!string.IsNullOrEmpty(query.CategoryName) && !(query.CategoryName.ToLower() == "all"))
            {
                string searchCategoryLower = query.CategoryName.ToLower();
                products = products.Where(p =>
                    p.Category.Name.ToLower().Contains(searchCategoryLower)
                   );
            }

            // If there is a string to search, we filter it by searching in the name and description fields
            if (!string.IsNullOrEmpty(query.SearchTerm))
            {
                string searchTermLower = query.SearchTerm.ToLower();
                products = products.Where(p =>
                    p.Name.ToLower().Contains(searchTermLower) ||
                    p.Description.ToLower().Contains(searchTermLower));
            }

            //If the MinPrice field is not null, we include it in the filtering
            if (query.MinPrice != null)
            {
                products = products.Where(p => p.Price >= query.MinPrice);
            }
            // If the MaxPrice field is not null, we include it in the filtering
            if (query.MaxPrice != null)
            {
                products = products.Where(p => p.Price <= query.MaxPrice);
            }

            //ResultProductDto type data returning
            var productList = products.Select(p => new ResultProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId 
            }).ToList();

            return productList;
        }

    }

}
