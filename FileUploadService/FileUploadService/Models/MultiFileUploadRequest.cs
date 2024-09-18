using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FileUploadService.Models
{
    public class MultiFileUploadRequest
    {        
        public string LabelName { get; set; }        
        public List<IFormFile> Files { get; set; }
    }
}
