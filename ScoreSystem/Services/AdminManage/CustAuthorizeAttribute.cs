using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoreSystem.Services.AdminManage
{
    public class CustAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] roles;

        public CustAuthorizeAttribute(params String[] role)
        {
            roles = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            String role = httpContext.Request.QueryString["role"];
            if (role != null)
            {
                return roles.Contains(role);
            }
            return base.AuthorizeCore(httpContext);
        }
    }

}