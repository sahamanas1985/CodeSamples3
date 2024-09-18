using System.Collections.Generic;


namespace DNFApiBasicAuth.Models
{
    public class sitesdata
    {
        public sitesdata()
        {
            // default constructor
            studyid = "";
            sitelist = new List<site>();
        }
        
        public string studyid { get; set; }
        public List<site> sitelist { get; set; }
    }

    public class site
    {
        public site()
        {
            // default constructor
        }

        public site(int SiteID, string SiteName)
        {
            siteid = SiteID;
            SiteName = SiteName;
        }

        public int siteid { get; set; }
        public string sitename { get; set; }
    }

    // sample json
    /*
      
    {
      "studyid": "study001",
      "sitelist": [
          {
            "siteid": 101,
            "sitename": "site101"
          },
          {
            "siteid": 102,
            "sitename": "site102"
          },
          {
            "siteid": 103,
            "sitename": "site103"
          }     
      ]
    }

    
    */
}