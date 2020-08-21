using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Vic.SportsStore.WebApp.Infrastructure.Abstract;

namespace Vic.SportsStore.WebApp.Infrastructure.Concret
{
    public class DbAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = false;
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase)
                && password.Equals("adminpwd", StringComparison.OrdinalIgnoreCase))
            {
                result = true;
            }


            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}