
using System;

namespace ADDEmailRoutingService.Models
{
    public class ApiResponse
    {
        public ApiResponse(bool IsSuccess, string Message)
        {
            isSuccess = IsSuccess;
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            message = Message;
        }

        public bool isSuccess { get; set; }
        public string timestamp { get; set; }
        public string message { get; set; }
    }
}