using FixturesVer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FixturesVer1.Utility
{
    public class CookieHelper
    {
        public static void ReadFromCookie(HttpCookie authCookie)
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string cookiePath = ticket.CookiePath;
            DateTime expiration = ticket.Expiration;
            bool expired = ticket.Expired;
            bool isPersistent = ticket.IsPersistent;
            DateTime issueDate = ticket.IssueDate;
            string name = ticket.Name;
            string userData = ticket.UserData;
            int version = ticket.Version;
            
        }

        public static void WriteToCookie(string token, LoginViewModel loginModel, bool isPersistent)
        {
            //Forms Authentication - setting cookie START
            string userData = token;
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
            loginModel.usr_Username,
            DateTime.Now,
            DateTime.Now.AddMinutes(30),
            isPersistent,
            userData,
            FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            //Forms Authentication - setting cookie END  
        }
    }
}