using ADDEmailRoutingService.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace ADDEmailRoutingService.Controllers
{
    public class EmailRoutingController : ApiController
    {
        [HttpPost]
        [Route("api/EmailRouting/SendEmail")]
        [DMBasicAuth]
        public ApiResponse SendEmail([FromBody] EmailRequest request)
        {
            string isValidRequest = ValidateRequest(request);
            if (isValidRequest != "valid") return new ApiResponse(false, isValidRequest);

            return SendEmailFunction(request);
        }

        private string ValidateRequest(EmailRequest request)
        {            
            if (string.IsNullOrEmpty(request.EmailSubject)) return "Email Subject can not be empty";
            if (string.IsNullOrEmpty(request.EmailContent)) return "Email Body can not be empty";
            if (request.RecepientEmailIDs.Count < 1) return "At least one sender is required";
            else return "valid";
        }

        public static ApiResponse SendEmailFunction(EmailRequest request)
        {
            try
            {
                string cert64String = ConfigurationManager.ConnectionStrings["pfxcertpath"].ConnectionString;

                X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String(cert64String), string.Empty,
                                    X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
                
                ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                
                var fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromSenderID"].ToString());
                var SmtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();

                var smtp = new SmtpClient(SmtpHost)
                {

                    Host = ConfigurationManager.AppSettings["SmtpHost"].ToString(),
                    Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true                    
                };
                
                // Attach the certificate
                smtp.ClientCertificates.Add(certificate);

                using (var message = new MailMessage()
                {
                    From = fromAddress,
                    Subject = request.EmailSubject,
                    Body = request.EmailContent,
                })
                {
                    foreach (var emailId in request.RecepientEmailIDs)
                        message.To.Add(emailId);

                    foreach(var ccId in request.CCIDs)
                        message.CC.Add(ccId);

                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
                                
                return new ApiResponse(true, "Email posted successfully to SMTP server.");

            }
            catch (Exception ex)
            {
                string exceptionDetails = ex.Message + ". # Inner exeption" + ex.InnerException;
                return new ApiResponse(false, exceptionDetails);
            }

        }

    }
}