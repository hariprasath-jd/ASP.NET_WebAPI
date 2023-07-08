using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI_Main.Auth_Valid
{
    public class Authenticate : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Is Unauthorized, Please Check Again :)");
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string[] _data = decToken.Split(':');
                string username = _data[0];
                string password = _data[1];
                if (UserValidation.Login(username, password))
                {
                    var _userData = UserValidation.UserDetails(username, password);
                    var threadIdentiy = new GenericIdentity(username);
                    threadIdentiy.AddClaim(new Claim(ClaimTypes.Name, username));

                    IPrincipal principal = new GenericPrincipal(threadIdentiy, _userData.Roles.Split(','));
                    Thread.CurrentPrincipal = principal;
                    if(HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Credentials");
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Is Unauthorized, Please Check Again :)");
                }
            }
        }
    }
}