
namespace CAD.Infrastructure
{
    public interface IMockDBRepository
    {
        List<TblProductModel> GetAllProductsFromDB();
        void AddNewProductInDB(TblProductModel NewProduct);
    }
}
