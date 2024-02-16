using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TrackerAPI.Models;

namespace TrackerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuditController : ApiController
    {
        private AuditLogDao auditLogDao = new AuditLogDao();

        // GET: api/audit
        [HttpGet]
        public IHttpActionResult Get()
        {
            var auditLogs = auditLogDao.GetAllAuditLogs();
            return Ok(auditLogs);
        }

        // GET: api/audit/Today
        [HttpGet]
        [Route("api/audit/Today")]
        public IHttpActionResult GetToday()
        {
            var auditLogs = auditLogDao.GetAuditLogsForToday();
            return Ok(auditLogs);
        }

        // GET: api/audit/Yesterday
        [HttpGet]
        [Route("api/audit/Yesterday")]
        public IHttpActionResult GetYesterday()
        {
            var auditLogs = auditLogDao.GetAuditLogsForYesterday();
            return Ok(auditLogs);
        }

        // GET: api/audit/CustomDate/{date}
        [HttpGet]
        [Route("api/audit/CustomDate/{date}")]
        public IHttpActionResult GetCustomDate(DateTime date)
        {
            var auditLogs = auditLogDao.GetAuditLogsForCustomDate(date);
            return Ok(auditLogs);
        }
    }
}

