using DMWebUICoreAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace DMWebUICoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArgusAPIController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IRequestProcessor _requestProcessor;

        // Constructor for dependency injection
        public ArgusAPIController(IConfiguration config, IRequestProcessor rp)
        {
            _config = config;
            _requestProcessor = rp;
        }


        [HttpPost("SendStudyProductDetails")]
        public ApiResponse SendStudyProductDetails([FromBody] StudyProductModel Model)
        {
            try
            {
                _requestProcessor.DummyConfigTest();

                //Authenticate user credentials
                bool isAuthenticated = _requestProcessor.AuthenticateCredentials(Request, _config);
                if (!isAuthenticated) return new ApiResponse(false, "Could not authenticate the request.");

                // If authenticated, validate the request.
                string ValidationResult = _requestProcessor.ValidateStudyProductDetailsRequest(Model);
                if (ValidationResult != "Success") return new ApiResponse(false, ValidationResult);

                // At this moment, request is authenticated and valid. Process the request.
                return _requestProcessor.ProcessStudyProductDetailsRequest(Model);               

            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }            

        }




        [HttpGet("ReceiveNonAmgenDSDetails")]
        public ApiResponse ReceiveNonAmgenDSDetails()
        {
            try
            {
                //Authenticate user credentials
                bool isAuthenticated = _requestProcessor.AuthenticateCredentials(Request, _config);
                if (!isAuthenticated) return new ApiResponse(false, "Could not authenticate the request.");

                // If authenticated, Process the request.
                return _requestProcessor.ProcessNonAmgenDSDetailsRequest();                

            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }

        }



    }
}
