using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using FixturesVer1.Services;

namespace FixturesVer1.Utility
{
    public class CustomAuthentication :System.Web.Http.AuthorizeAttribute
    
    {
        AccountsService _accountssService;

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Authorize(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }


        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var challengeMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
            throw new HttpResponseException(challengeMessage);
        }


        private bool Authorize(HttpActionContext actionContext)
        {
              //boolean logic to determine if you are authorized.  
                //We check for a valid token in the request header or cookie.
                ////if ()
                ////{
                ////    return true;
                ////}
                ////else
                ////{
                ////    return false;
                ////}

                return true; 
         }
    }
}