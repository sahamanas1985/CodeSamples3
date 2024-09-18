namespace CAD.Infrastructure
{
    public class MockDBRepository:IMockDBRepository
    {
        public static List<TblProductModel> _products;

        public MockDBRepository()
        {
            if(_products == null)
            {
                _products = new List<TblProductModel>();
                _products.Add(new TblProductModel(1, "Smartphone", 40000));
                _products.Add(new TblProductModel(2, "TV", 40000));
                _products.Add(new TblProductModel(3, "Fridge", 20000));
                _products.Add(new TblProductModel(4, "Headphone", 3000));
            }
        }

        public List<TblProductModel> GetAllProductsFromDB()
        {
            return _products;
        }

        public void AddNewProductInDB(TblProductModel NewProduct)
        {
            _products.Add(NewProduct);
        }

    }
}