using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.BussinesLayer.Abstract;
using TaskProject.DataAccessLayer.Abstract;
using TaskProject.DtoLayer.Dtos;
using TaskProject.EntityLayer.Concreate;

namespace TaskProject.BussinesLayer.Concreate
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productRepository;

        public ProductManager(IProductDal productRepository)
        {
            _productRepository = productRepository;
        }

        // Method was iplemented from the interface, fetches products using the data access layer
        public List<ResultProductDto> GetProducts(ProductQuery query)
        {
            return _productRepository.GetProducts(query);
        }
    }

}
