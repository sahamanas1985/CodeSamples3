using System.Collections.Generic;

namespace ADDEmailRoutingService.Models
{
    public class EmailRequest
    {
        public List<string> RecepientEmailIDs { get; set; }
        public List<string> CCIDs { get; set; }

        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
    }
}