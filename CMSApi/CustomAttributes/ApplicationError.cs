using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSApi.CustomAttributes
{
    public class ApplicationError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            string controller = filterContext.RouteData.Values["controller"].ToString();
            string action = filterContext.RouteData.Values["action"].ToString();
            filterContext.ExceptionHandled = true;

            var model = new HandleErrorInfo(filterContext.Exception, controller, action);

            filterContext.Result = new ViewResult()
            {
                ViewName = "ApplicationError",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}