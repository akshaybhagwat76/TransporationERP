using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationERP.dal.Model;
using TransportationERP.ViewModel;

namespace TransportationERP.BL
{
    public class AuthBL
    {
        private MMS_WebContext _context = new MMS_WebContext();
        public async Task<ResponceVM> Login(string email, string password)
        {
            var _res = new ResponceVM();
            try
            {
                var _user = await _context.Users.Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
                if (_user != null)
                {
                    var salt = _user.Salt;
                    var comb = password + salt;
                    var enc = Security.Encryption.SHA512(comb);
                    var pre = ByteArrayToString(enc);
                    var post = ByteArrayToString(_user.PasswordHash);

                    if (pre == post)
                    {
                        _res.discription = "Successful Login ";
                        _res.status = true;
                        _res.data = _user.UserId + "";
                        _res.statusCode = StatusCode.Ok;
                    }
                    else
                    {

                        _res.discription = "Incorrect Password ";
                        _res.status = false;
                        _res.statusCode = StatusCode.BadRequest;
                    }
                }
                else
                {
                    _res.discription = "Email Not Authenticated ";
                    _res.status = false;
                    _res.statusCode = StatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                _res.discription = "Something went wrong ";
                _res.status = false;
                _res.statusCode = StatusCode.BadRequest;

            }
            return _res;
        }
        public async Task<ResponceVM> ResetPassword(string email, string password)
        {
            var _res = new ResponceVM();

            try
            {
                var connstrnig = _context.Database.GetDbConnection().ConnectionString;
                var _user = await _context.Users.Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
                if (_user != null)
                {
                    var salt = _user.Salt;
                    var comb = password + salt;
                    var enc = Security.Encryption.SHA512(comb);
                    _user.PasswordHash = enc;
                    _context.Users.Update(_user);
                    await _context.SaveChangesAsync();

                    _res.discription = "Password Successfully Updated ";
                    _res.status = true;
                    _res.statusCode = StatusCode.Ok;
                }
                else
                {
                    _res.discription = "Email Not Authenticated ";
                    _res.status = false;
                    _res.statusCode = StatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                _res.discription = "Something went wrong ";
                _res.status = false;
                _res.statusCode = StatusCode.BadRequest;

            }
            return _res;
        }
        public async Task<ResponceVM> GeneratePasswordRecoveryLink(string email)
        {
            var _res = new ResponceVM();

            try
            {
                var _user = await _context.Users.Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
                if (_user != null)
                {
                    var salt = _user.Salt;
                    var comb = email;
                    var enc = Security.Encryption.Encrypt(comb);


                    _res.discription = "Password Recovery Email Successfully Sent ";
                    _res.status = true;
                    _res.statusCode = StatusCode.Ok;
                    _res.data = enc;
                }
                else
                {
                    _res.discription = "Email Not Authenticated ";
                    _res.status = false;
                    _res.statusCode = StatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                _res.discription = "Something went wrong ";
                _res.status = false;
                _res.statusCode = StatusCode.BadRequest;

            }
            return _res;
        }

        public async Task<ResponceVM> ReversePasswordRecoveryLink(string token)
        {
            var _res = new ResponceVM();

            try
            {

                var enc = Security.Encryption.Decrypt(token);
                var email = enc;
                var _user = await _context.Users.Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
                var l = true;
                if (l)
                {
                    _res.discription = "Successfull";
                    _res.status = true;
                    _res.statusCode = StatusCode.Ok;
                    _res.data = _user.EmailAddress;

                }
                else
                {
                    _res.discription = "Invalid token";
                    _res.status = false;
                    _res.statusCode = StatusCode.BadRequest;


                }

            }
            catch (Exception ex)
            {
                _res.discription = "Something went wrong ";
                _res.status = false;
                _res.statusCode = StatusCode.BadRequest;

            }
            return _res;
        }

        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
