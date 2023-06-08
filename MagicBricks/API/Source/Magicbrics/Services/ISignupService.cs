using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Magicbrics.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Generators;

namespace Magicbrics.Services
{
    public interface ISignupService :IRepository<User>
    {
        string UpdateUser(int id, User user);
        string DeleteUser(int id);
        User AddUserAsync(User user);
        string OtpVerify(OtpVerify user);
    }
    public class SignupService: Repository<User>,ISignupService
    {
        private IConfiguration _configuration { get; set; }
        public SignupService(magicbrics2392jeetContext dbContext,IConfiguration configuration)  : base(dbContext)
        {
            _configuration = configuration;
        }


        public string UpdateUser(int id, User user)
        {
            var user1 = base.GetById(id);
            if (user1 == null) return $"User Not Exists with This ID: {id}";
            base.Update(user,id);
            return $"User with id {id} Updated Successfully";
        }

        public string DeleteUser(int id)
        {
            var user2 = base.GetById(id);
            if (user2 == null) return $"User Not Exists with This ID:{id}";
            base.Remove(user2);
            return $"User with id {id} Deleted Successfully";
        }
        public  User AddUserAsync(User user)
        {

            var obj = DbContext.Users.SingleOrDefault(u => u.Email == user.Email && u.Otpno == user.Otpno);
            Random rnd = new Random();
            var otp = rnd.Next(100000, 999999).ToString();
            try
            {
                var mailMessage = new
       MailMessage(_configuration.GetValue<string>("EMail"), user.Email)
                {
                    Subject = "MagicBricks OTP Varification",
                    Body = $"your Otp is :-${otp}",
                    IsBodyHtml = true
                };
                var smtp = new SmtpClient()
                {
                    Host = _configuration.GetValue<string>("Host"),
                    EnableSsl = true,
                    UseDefaultCredentials = true,
                    Port = Convert.ToInt32(_configuration.GetValue<int>("Port")),
                    Credentials = new NetworkCredential(_configuration.GetValue<string>("EMail"), _configuration.GetValue<string>("Password"))
                };
                smtp.Send(mailMessage);
            }
            catch(Exception e)
            {
                throw  e;
            }
            //bool b= SendOtpToEmail(otp, user.Email);
            if (obj != null)
            {
                user.UserId= obj.UserId;
                obj.Otpno = otp;
                obj.Password = BCrypt.Net.BCrypt.HashPassword($"{obj.Password}");
                base.Update(obj, obj.UserId);
                return obj;
            }
            else
            {
                user.Otpno = otp;
                user.Password = BCrypt.Net.BCrypt.HashPassword($"{user.Password}");
                base.Add(user);
                return user;
            }
    }

        public string OtpVerify(OtpVerify user)
        {
            var obj = DbContext.Users.SingleOrDefault(u=>u.Email==user.Email&& u.Otpno == user.Otp);
            if (obj != null)
                return $"{obj.UserId}";
            else
                return "OTP not  verified";
        }
    }
}
