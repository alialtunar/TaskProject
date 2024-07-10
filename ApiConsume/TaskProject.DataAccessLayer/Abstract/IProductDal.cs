using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.DtoLayer.Dtos;
using TaskProject.EntityLayer.Concreate;

namespace TaskProject.DataAccessLayer.Abstract
{
    public interface IProductDal
    {
        // Method used to filter and list products
        List<ResultProductDto> GetProducts(ProductQuery query);
    }

}
