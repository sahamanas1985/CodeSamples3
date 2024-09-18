using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Configuration;


namespace ADDEmailRoutingService
{
    public class DMBasicAuth : AuthorizationFilterAttribute
    {       
        private static string UserName = ConfigurationManager.AppSettings["ApiAuthUserName"];
        private static string UserPass = ConfigurationManager.AppSettings["ApiAuthSecret"];

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string uname = usernamePasswordArray[0];
                string pass = usernamePasswordArray[1];
                if (UserName.ToLower() == uname.ToLower() && UserPass == pass)
                {
                    // Authentication successful.
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(uname), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}