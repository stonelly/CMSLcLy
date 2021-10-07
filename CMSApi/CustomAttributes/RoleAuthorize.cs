using CMSLcLy.Common.Enums;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMSApi.CustomAttributes
{
    /// <summary>
    /// Custom Role Attribute to handle Role check. For normal implementation, may use AuthorizeAttribute's Roles property.
    /// <para>
    /// To cater for Superadmin specific functions, please use IsSuperAdminOnly property.
    /// </para>
    /// </summary>
    public class RoleAuthorize : AuthorizeAttribute
    {
        /// <summary>
        /// Set true to allow superadmin access only, default is false.
        /// </summary>
        public bool IsSuperAdminOnly { get; set; } = false;

        /// <summary>
        /// Represents AccessType for a particular function, enumeration flag
        /// <para>To set multiple AccessType, use bit operator OR (|)</para>
        /// </summary>
        public AccessTypes AccessType { get; set; }

        /// <summary>
        /// true if AccessType value is more than one, otherwise false
        /// </summary>
        public bool IsMultipleAccessTypes { get; set; } = false;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("Empty context found.");

            IPrincipal user = httpContext.User;

            // check if user is logged in
            if (!user.Identity.IsAuthenticated)
                return false;

            //To be DO
            //bool isSuperAdmin = HtmlHelperExtensions.IsSuperAdmin();

            ///* 1. If page for superadmin only but user is not superadmin
            // * 2. If page is not for superadmin only but user is not superadmin and does not have specified role's access type
            // */
            //if ((IsSuperAdminOnly && !isSuperAdmin) ||
            //    (!IsSuperAdminOnly && !isSuperAdmin &&
            //    !HtmlHelperExtensions.HasAccess(base.Roles, this.AccessType, this.IsMultipleAccessTypes)))
            //    return false;

            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //already logged in
                var authenticatedUnauthorizedRouteValues =
                        new RouteValueDictionary(new { controller = "Error", action = "AccessDenied", area = string.Empty });

                filterContext.Result = new RedirectToRouteResult(authenticatedUnauthorizedRouteValues);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}