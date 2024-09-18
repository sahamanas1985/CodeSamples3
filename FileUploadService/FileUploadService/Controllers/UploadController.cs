using FileUploadService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IConfiguration _config;
        private const long MaxFileSize = 2L * 1024L * 1024L * 1024L; // 2GB

        public UploadController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("PostMultipleFiles")]
        [RequestSizeLimit(MaxFileSize)] //increased max request size
        [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)] //increased max request size
        [Produces("application/json")]
        [ProducesResponseType(typeof(FileUploadResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FileUploadResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FileUploadResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(FileUploadResponse), StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<ActionResult> PostMultipleFiles([FromForm] MultiFileUploadRequest request)
        {
            try
            {
                
                // Validate request
                string ValidationResult = ValidateMultiFileUploadRequest(request);

                if (ValidationResult != "valid")
                {
                    //return invalid request                    
                    return BadRequest(new FileUploadResponse(false, ValidationResult));
                }


                //Get destination folder path to save the files
                string Uploadfolder = _config.GetSection("FileSavePath").Value;

                // make subfolder with label name
                string destinationfolder = Path.Combine(Uploadfolder, request.LabelName);
                if (!Directory.Exists(destinationfolder)) Directory.CreateDirectory(destinationfolder);


                //Push files in the server
                foreach (IFormFile File in request.Files)
                {
                    var saveFilePath = Path.Combine(destinationfolder, File.FileName);
                    using (var stream = new FileStream(saveFilePath, FileMode.Create))
                    {
                        await File.CopyToAsync(stream);
                    }                    
                }

                FileUploadResponse res = new FileUploadResponse(true, "File post successful");
                return Ok(res);
            }
            catch (Exception Ex)
            {
                //return error                             
                return StatusCode(500, new FileUploadResponse(false, Ex.Message));
            }

        }


        // private method to validate request.
        [NonAction]
        public string ValidateMultiFileUploadRequest(MultiFileUploadRequest request)
        {
            if (request == null) return "Request can't be null";
            if (string.IsNullOrEmpty(request.LabelName)) return "Label Name can't be null";
            if (request.Files == null) return "Request contains no files";
            return "valid";
        }



    }
}
