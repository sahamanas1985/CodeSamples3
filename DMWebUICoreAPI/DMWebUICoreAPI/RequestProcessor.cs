using DMWebUICoreAPI.Models;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace DMWebUICoreAPI
{
    public interface IRequestProcessor
    {
        public bool AuthenticateCredentials(HttpRequest request, IConfiguration config);
        public string ValidateStudyProductDetailsRequest(StudyProductModel model);
        public ApiResponse ProcessStudyProductDetailsRequest(StudyProductModel model);

        
        public ApiResponse ProcessNonAmgenDSDetailsRequest();

        public string DummyConfigTest();


    }


    public class RequestProcessor : IRequestProcessor
    {
        
        public bool AuthenticateCredentials(HttpRequest request, IConfiguration config)
        {
            try
            {
                // Get Credentials from Authentication Header. 
                
                var authHeaderParsed = AuthenticationHeaderValue.Parse(request.Headers["Authorization"]);
                string? credentials = authHeaderParsed.Parameter;

                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(credentials));

                int seperatorIndex = usernamePassword.IndexOf(':');

                string usernameFromHeader = usernamePassword.Substring(0, seperatorIndex).ToLower();
                string passwordFromHeader = usernamePassword.Substring(seperatorIndex + 1);

                // Hash these using SHA256 
                string HashedUsernameFromHeader = GetSha256HashedString(usernameFromHeader);
                string HashedPasswordFromHeader = GetSha256HashedString(passwordFromHeader);

                // Get Hashed Credentials from appsettings config.

                string usernameFromConfig = config.GetSection("ApiCredentials").GetSection("SHA256EncodedUserId").Value;
                string secretFromConfig = config.GetSection("ApiCredentials").GetSection("SHA256Encodedsecret").Value;

                // Compare the two hashes.

                if (HashedUsernameFromHeader != usernameFromConfig || HashedPasswordFromHeader != secretFromConfig) return false;
                else return true;
            }
            catch
            {
                throw;
            }
        }
        
        public string ValidateStudyProductDetailsRequest(StudyProductModel model)
        {
            string Message = "Success";

            if (model == null) Message = "Request can not be empty";
            if(model.AmgenProductFamily.Count <1 ) Message = "Request can not be empty";

            foreach(AmgenProductFamily item in model.AmgenProductFamily)
            {
                if(string.IsNullOrEmpty(item.ProductFamilyName)) Message = "Product Family Name is Empty in one or more items";                
                if (string.IsNullOrEmpty(item.StudyNumber)) Message = "StudyNumber is Empty in one or more items";
            }

            return Message;
        }

        public ApiResponse ProcessStudyProductDetailsRequest(StudyProductModel model)
        {
            // Do Processing and Database entry here.

            return new ApiResponse(true, "Processed successfully.");
        }


        public ApiResponse ProcessNonAmgenDSDetailsRequest()
        {            
            // Do Processing and Database entry here - dummy code

            DSAmgenProductFamily DSitem1 = new DSAmgenProductFamily("Family001", "Product001", "Study111", "RSIName1", DateTime.Now);
            DSAmgenProductFamily DSitem2 = new DSAmgenProductFamily("Family002", "Product002", "Study222", "RSIName2", DateTime.Now);
            DSAmgenProductFamily DSitem3 = new DSAmgenProductFamily("Family003", "Product003", "Study333", "RSIName3", DateTime.Now);

            AmgenDSDetails result = new AmgenDSDetails();
            result.AmgenProductFamily.Add(DSitem1);
            result.AmgenProductFamily.Add(DSitem2);
            result.AmgenProductFamily.Add(DSitem3);

            // Dummy code ends

            ApiResponse response = new ApiResponse(true, "Data Retrieved Successfully.");
            response.Result = result;

            return response;
        }

        
        // Private methods

        private static string GetSha256HashedString(string PlainText)
        {
            string key = "73c98b27-7a38-4819-b0cc-a57ba2e0c345";
            int interactionCount = 10000;

            byte[] clearTextBytes = Encoding.Unicode.GetBytes(PlainText);
            byte[] saltBytes = Encoding.Unicode.GetBytes(key);

            using (var pbkdf2 =
                new Rfc2898DeriveBytes(clearTextBytes, saltBytes, interactionCount, HashAlgorithmName.SHA256))
            {
                byte[] hashedDataBytes = pbkdf2.GetBytes(32);
                return Convert.ToBase64String(hashedDataBytes);
            }
        }

        public string DummyConfigTest()
        {
            IConfiguration _config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            string myvalue = _config.GetSection("ApiCredentials").GetSection("SHA256EncodedUserId").Value;

            return myvalue;
        }
    }
}
