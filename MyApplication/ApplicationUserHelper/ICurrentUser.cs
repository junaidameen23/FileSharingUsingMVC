using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApplication.ApplicationUserHelper
{
    public interface ICurrentUser
    {
        string Id(HttpContextBase context);

        string Name(HttpContextBase context);

        string RoleId(HttpContextBase context);

        string RoleName(HttpContextBase context);
    }
}