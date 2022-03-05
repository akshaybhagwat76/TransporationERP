using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading.Tasks;
using TransportationERP.BL;
using TransportationERP.BL.Helpers;
using TransportationERP.BL.Repository;
using TransportationERP.DAL.Model;
using TransportationERP.ViewModel;

namespace TransportationERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationAPI : ControllerBase
    {
        private AuthBL _bl = new AuthBL();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuditLog _auditRepository;
        public AuthenticationAPI(IHttpContextAccessor httpContextAccessor, IAuditLog auditRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _auditRepository = auditRepository;
        }
        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login(LoginVM vm)
        {
            var _res = await _bl.Login(vm.Email,vm.Password);
            HttpContext.Session.SetString(AllSessionKeys.UserName, "demoaudit");
            HttpContext.Session.SetString(AllSessionKeys.IsFirstLogin, "N");
            HttpContext.Session.SetInt32(AllSessionKeys.RoleId, 1);
            HttpContext.Session.SetInt32(AllSessionKeys.LangId, 1);
            AuditLogin();
            return Ok(_res);
        }
        private void AuditLogin()
        {
            var objaudit = new AuditLogs();
            objaudit.RoleId = Convert.ToString(HttpContext.Session.GetInt32(AllSessionKeys.RoleId));
            objaudit.ControllerName = "Portal";
            objaudit.ActionName = "Login";
            objaudit.Area = "";
            objaudit.LoggedInAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            if (_httpContextAccessor.HttpContext != null)
                objaudit.IpAddress = Convert.ToString(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress);
            objaudit.UserId = Convert.ToString(HttpContext.Session.GetInt32(AllSessionKeys.UserId));
            objaudit.PageAccessed = "";
            objaudit.UrlReferrer = "";
            objaudit.SessionId = HttpContext.Session.Id;
            _auditRepository.InsertAuditLogs(objaudit);
        }
        private void AuditLogout()
        {
            var objaudit = new AuditLogs();
            objaudit.RoleId = Convert.ToString(HttpContext.Session.GetInt32(AllSessionKeys.RoleId));
            objaudit.ControllerName = "Portal";
            objaudit.ActionName = "Logout";
            objaudit.Area = "";
            objaudit.LoggedOutAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            if (_httpContextAccessor.HttpContext != null)
                objaudit.IpAddress = Convert.ToString(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress);
            objaudit.UserId = Convert.ToString(HttpContext.Session.GetInt32(AllSessionKeys.UserId));
            objaudit.PageAccessed = "";
            objaudit.UrlReferrer = "";
            objaudit.SessionId = HttpContext.Session.Id;

            _auditRepository.InsertAuditLogs(objaudit);
        }

        [HttpGet]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string email, string pwd)
        {
            var _res = await _bl.ResetPassword(email, pwd);
            return Ok(_res);
        }


    }


}
