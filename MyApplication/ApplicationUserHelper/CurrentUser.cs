using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MyApplication.ApplicationUserHelper
{
    public class CurrentUser:ICurrentUser
    {
        public string Id(HttpContextBase context)
        {
            return ((ClaimsIdentity)context.User.Identity).Claims
                    .Where(c => c.Type == ClaimTypes.NameIdentifier)
                    .Select(c => c.Value).FirstOrDefault();
        }


        public string Name(HttpContextBase context)
        {
            return ((ClaimsIdentity)context.User.Identity).Claims
                    .Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).FirstOrDefault();
        }

        public string RoleId(HttpContextBase context)
        {
            return ((ClaimsIdentity)context.User.Identity).Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value).FirstOrDefault();
        }

        public string RoleName(HttpContextBase context)
        {
            return ((ClaimsIdentity)context.User.Identity).Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value).FirstOrDefault();
        }
    }
}