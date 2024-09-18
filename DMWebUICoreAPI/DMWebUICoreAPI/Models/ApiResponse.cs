namespace DMWebUICoreAPI.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public DateTime ProcessedAt { get; set; }
        public dynamic Result { get; set; }

        public ApiResponse()
        {
            //default constructor
        }

        public ApiResponse(bool success, string? message)
        {
            Success = success;
            Message = message;
            ProcessedAt = DateTime.Now;
            Result = null;
        }
    }
}
