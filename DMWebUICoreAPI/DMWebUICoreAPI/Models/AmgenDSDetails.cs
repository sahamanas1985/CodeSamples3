namespace DMWebUICoreAPI.Models
{    
    public class DSAmgenProductFamily
    {
        public DSAmgenProductFamily()
        {
            // default constructor
        }

        public DSAmgenProductFamily(string? productFamilyName, string? productName,
            string? studyNumber, string? activeDatasheetName, DateTime? activationDate)
        {
            ProductFamilyName = productFamilyName;
            ProductName = productName;
            StudyNumber = studyNumber;
            ActiveDatasheetName = activeDatasheetName;
            ActivationDate = activationDate;
        }
        
        public string? ProductFamilyName { get; set; }
        public string? ProductName { get; set; }
        public string? StudyNumber { get; set; }
        public string? ActiveDatasheetName { get; set; }
        public DateTime? ActivationDate { get; set; }
    }

    public class AmgenDSDetails
    {
        public AmgenDSDetails()
        {
            AmgenProductFamily = new List<DSAmgenProductFamily>();
        }
        
        public List<DSAmgenProductFamily> AmgenProductFamily { get; set; }
    }

}
