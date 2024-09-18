using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


namespace EmailWithCertificateTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emailSender = new EmailSender();
            emailSender.SendEmail("no-reply.tcsadd@tcsapps.com", "ramsaurabh@gmail.com", "Test Subject Dotnet", "Test Body Dotnet");
        }


    }

    public class EmailSender
    {
        private X509Certificate2 GetCertificate(string certificateThumbprint)
        {
            X509Certificate2 cert = null;
            X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            
            certStore.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = 
                certStore.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint,false);
            
            if (certCollection.Count > 0)
            {
                cert = certCollection[0];
                certStore.Close();                
            }
            return cert;
        }

        public void SendEmail(string fromEmail, string toEmail, string subject, string body)
        {
            // Specify the path to the PFX file and the password
            string certificatePath = @"C:/Manas/kv1-cid-prod-dm-dm-tcsaddtcsapps-20240406.pfx";
            string certificatePassword = "";


            // Prepare the certificate

            //byte[] rawCertBytes = File.ReadAllBytes(certificatePath);
            //string cert64String = Convert.ToBase64String(rawCertBytes);

            string cert64String = @"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";

            //byte[] bytes = Convert.FromBase64String(cert64String);
            //X509Certificate2 certificate = new X509Certificate2(bytes);

            X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String(cert64String), certificatePassword,
                    X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);


            //X509Certificate2 certificate = new X509Certificate2();
            //certificate.Import(Convert.FromBase64String(cert64String), certificatePassword,
            //    X509KeyStorageFlags.Exportable |
            //    X509KeyStorageFlags.PersistKeySet |
            //    X509KeyStorageFlags.UserKeySet);

            //X509Certificate2 certificate = GetCertificate("thumb_print_value");

            //X509Certificate2 certificate = new X509Certificate2(certificatePath, certificatePassword);


            ServicePointManager.ServerCertificateValidationCallback =
            delegate (object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };


            // Create a new SMTP client and set the server details
            SmtpClient client = new SmtpClient("tcsappsprod.mail.protection.outlook.com")
            {
                Port = 25,
                // Credentials = new NetworkCredential("yourUsername", "yourPassword"),
                EnableSsl = true,
                UseDefaultCredentials = true
            };

            // Attach the certificate
            client.ClientCertificates.Add(certificate);

            // Create a new MailMessage object
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body
            };
            mailMessage.To.Add(toEmail);

            try
            {
                // Send the email
                client.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email. " + ex.Message + " ## Inner Exception ## " + ex.InnerException + " ## Stack Trace ## " + ex.StackTrace);
                Console.Read();
            }
        }
    }


}