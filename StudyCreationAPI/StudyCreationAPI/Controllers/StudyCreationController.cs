using StudyCreationAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace StudyCreationAPI.Controllers
{
    public class StudyCreationController : ApiController
    {
        
        [AcceptVerbs("GET")]
        public IEnumerable<string> QueueUpdated()
        {
            // Entry point - When the queue is updated, the Endpoint URL will be hit
            // and the Debugger will come here.
            // From here, check the queue, and then start processing.

            

            return new string[] { "value1", "value2" };
        }

        // POST api/<controller>
        [ActionName("DownloadFile")]
        public HttpResponseMessage DownloadFile(string filetype)
        {            
            string FilePath = "";           
            string filename = "";

            //read file from Path
            if (filetype == "pdf")
            {
                FilePath = @"C:\Manas\FilePath\DownloadTest\payload1.pdf";
                filename = "download.pdf";

            }
            else if (filetype == "excel")
            {
                FilePath = @"C:\Manas\FilePath\DownloadTest\payload2.xlsx";
                filename = "download.xlsx";
            }

            var stream = new FileStream(FilePath, FileMode.Open);
            
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = filename
            };

            return result;

        }

    }
}
