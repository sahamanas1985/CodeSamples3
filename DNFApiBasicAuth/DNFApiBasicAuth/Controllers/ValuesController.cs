using DNFApiBasicAuth.Models;


using System.Web.Http;

namespace DNFApiBasicAuth.Controllers
{

    public class ValuesController : ApiController
    {        
        [HttpPost]
        [Route("api/values/CreateSites")]
        public Output CreateSites([FromBody] sitesdata sites)
        {
            return new Output(true, sites.studyid, sites.sitelist.Count);
        }

        [HttpPost]
        [Route("api/values/CreateSitesWithAuth")]
        [DMBasicAuth]
        public Output CreateSitesWithAuth([FromBody] sitesdata sites)
        {
            return new Output(true, sites.studyid, sites.sitelist.Count);
        }


    }
}
