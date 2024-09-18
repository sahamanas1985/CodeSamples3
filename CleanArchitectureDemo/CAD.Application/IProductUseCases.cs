using CAD.Domain;

namespace CAD.Application
{
    public interface IProductUseCases
    {
        void SetupInitialData(List<Product> Products);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        string AddNewProduct(Product NewProduct);
    }
}
