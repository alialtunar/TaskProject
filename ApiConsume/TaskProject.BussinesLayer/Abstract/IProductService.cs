using TaskProject.DtoLayer.Dtos;


namespace TaskProject.BussinesLayer.Abstract
{
    public interface IProductService
    {
        // Interface method to be used for filtering and listing products
        List<ResultProductDto> GetProducts(ProductQuery query);
    }
}
