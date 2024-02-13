using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TrackerAPI.Models;

namespace TrackerAPI.Filters
{
    public class AuditLogAttribute : ActionFilterAttribute
    {
        private readonly AuditLogDao _auditDao;

        public AuditLogAttribute()
        {
            _auditDao = new AuditLogDao();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            DateTime currentTime = DateTime.Now;

            string username = actionContext.RequestContext.Principal.Identity.Name;
            string controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string actionName = actionContext.ActionDescriptor.ActionName;
            // Construct the audit log object
            var auditLog = new AuditLog
            {
                Date_And_Time = currentTime,
                userName = username,
                Module = controllerName,
                Action = actionName
            };
            // log the audit information to your data store here
            _auditDao.LogAudit(auditLog);

            base.OnActionExecuting(actionContext);
        }
    }
}
