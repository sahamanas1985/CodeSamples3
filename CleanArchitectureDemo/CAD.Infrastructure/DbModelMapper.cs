using CAD.Domain;

namespace CAD.Infrastructure
{
    public class DbModelMapper
    {
        public static TblProductModel MapToDbModel(Product Model)
        {
            TblProductModel dbproduct = new TblProductModel
            {
                DbProductId = Model.ProductId,
                DbProductName = Model.ProductName,
                DbProductPrice = Model.ProductPrice
            };

            return dbproduct;
        }

        public static Product MapFromDbModel(TblProductModel DbModel)
        {
            Product product = new Product
            {
                ProductId = DbModel.DbProductId,
                ProductName = DbModel.DbProductName,
                ProductPrice = DbModel.DbProductPrice
            };

            return product;
        }

        public static List<Product> MapFromDbModelList(List<TblProductModel> DbModel)
        {
            List<Product> productList = new List<Product>();
            foreach(TblProductModel model in DbModel)
            {
                productList.Add(MapFromDbModel(model));
            }
            return productList;
        }
    }
}
