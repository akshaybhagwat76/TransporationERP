using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TransportationERP.BL;
using TransportationERP.BL.Email;
using TransportationERP.dal.Model;
using TransportationERP.ViewModel;

namespace TransportationERP.Controllers.Auth
{


    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordAPI : ControllerBase
    {

        private AuthBL _bl = new AuthBL();

        [HttpGet]
        [Route("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email, string clienturl)
        {
            try
            {
                var _c = await _bl.GeneratePasswordRecoveryLink(email);
                if (_c.status)
                {
        
                    var request_url = clienturl + "forgot-password/resetpassword?token="+_c.data;
                
                    SendEmail se = new SendEmail();
                    bool isValid = se.ForgotPasswordEmail(email, request_url);

                }

                return Ok(_c);


            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string email, string token, string password)
        {
            var u = new ResponceVM();
            var user = await _bl.ReversePasswordRecoveryLink(token);

            if (user.status)
            {
                 u = await _bl.ResetPassword(user.data, password);
            }
               
            return Ok(u);
        }
















        //[HttpPost]
        //[Route("ResetPassword")]
        //public async Task<IActionResult> ResetPassword(string email, string token, string newPassword)
        //{
        //    try
        //    {
        //        var user = await userManager.FindByEmailAsync(email);
        //        if (user != null)
        //        {

        //            var res = await userManager.ResetPasswordAsync(user, token, newPassword);
        //            if (res.Succeeded)
        //            {
        //                return Ok("Password Updated Sucessfully");

        //            }
        //            else
        //            {
        //                return BadRequest("Something went wrong");
        //            }

        //        }
        //        else
        //        {
        //            return Unauthorized();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Invalid user");
        //    }
        //}


















    }

}
