using CAD.Domain;

namespace CAD.Application
{
    public class ProductUseCases : IProductUseCases
    {
        List<Product> products;
                
        public void SetupInitialData(List<Product> Products)
        {
            products = Products;
        }

        public string AddNewProduct(Product NewProduct)
        {
            // business logic
            if (NewProduct.ProductId == 0)
                return "Product id can not be zero.";
            else if (NewProduct.ProductName == string.Empty)
                return "Product Name can not be blank.";
            if (NewProduct.ProductPrice < 1)
                return "Product Price is too low";
            else
            {
                products.Add(NewProduct);
                return "Success";
            }            
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.Where(i => i.ProductId == id).FirstOrDefault();
        }

        
    }
}