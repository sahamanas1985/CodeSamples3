using System;

namespace FileUploadService.Models
{
    public class FileUploadResponse
    {
        public bool UploadStatus { get; set; }
        public DateTime UploadDateTime { get; set; }
        public string Message { get; set; }

        public FileUploadResponse(bool uploadStatus, string message)
        {
            UploadStatus = uploadStatus;
            UploadDateTime = DateTime.Now;
            Message = message;
        }
    }
}
