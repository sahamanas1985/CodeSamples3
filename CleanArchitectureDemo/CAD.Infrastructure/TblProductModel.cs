
namespace CAD.Infrastructure
{
    public class TblProductModel
    {
        public TblProductModel()
        {
            //default constructor
        }

        public TblProductModel(int dbProductId, string dbProductName, double dbProductPrice)
        {
            DbProductId = dbProductId;
            DbProductName = dbProductName;
            DbProductPrice = dbProductPrice;
        }

        public int DbProductId { get; set; }
        public string DbProductName { get; set; }
        public double DbProductPrice { get; set; }
    }
}
