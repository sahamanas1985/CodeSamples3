
namespace DNFApiBasicAuth.Models
{
    public class Output
    {
        public Output(bool IsSuccess, string StudyName, int SiteCount)
        {
            isSuccess = IsSuccess;
            studyName = StudyName;
            siteCount = SiteCount;
        }

        public bool isSuccess { get; set; }
        public string studyName { get; set; }
        public int siteCount { get; set; }
    }
}