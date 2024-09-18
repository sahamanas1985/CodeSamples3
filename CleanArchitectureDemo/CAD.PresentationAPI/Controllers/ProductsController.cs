using CAD.Application;
using CAD.Domain;
using CAD.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CAD.PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMockDBRepository _db;
        IProductUseCases _productUseCases;

        public ProductsController(IMockDBRepository db, IProductUseCases productUseCases)
        {
            _db = db;
            List<TblProductModel> ProductsFromDb = _db.GetAllProductsFromDB();

            _productUseCases = productUseCases;
            _productUseCases.SetupInitialData(DbModelMapper.MapFromDbModelList(ProductsFromDb));
        }

        [HttpGet("GetAllProducts")]
        public List<Product> GetAllProducts()
        {
            return _productUseCases.GetAllProducts();
        }
        
        [HttpGet("GetAllProductsByID/{id}")]
        public Product GetAllProductsByID(int id)
        {
            return _productUseCases.GetProductById(id);
        }

        [HttpPost("CreateNewProduct")]
        public string GetAllProductsByID(Product NewProduct)
        {
            string validate = _productUseCases.AddNewProduct(NewProduct);
            if(validate == "Success")
            {               
                _db.AddNewProductInDB(DbModelMapper.MapToDbModel(NewProduct));
            }
            return validate;
        }



    }
}
