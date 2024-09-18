namespace DMWebUICoreAPI.Models
{
       
    public class AmgenProductFamily
    {
        public string? ProductFamilyName { get; set; }       
        public string? StudyNumber { get; set; }
    }

    public class StudyProductModel
    {
        public List<AmgenProductFamily> AmgenProductFamily { get; set; }
    }
}
