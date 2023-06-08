using Magicbrics.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Magicbrics.Services
{
    public interface IContactOwnerService:IRepository<ContactOwner>
    {
        public new object Add(ContactOwner contactOwner);
        public string Update(int id, ContactOwner contactOwner);
        public string Remove(int id);
    }
    public class ContactOwnerService : Repository<ContactOwner>, IContactOwnerService 
    {
       public  string name;
      public  string phone;
        public string email;
        private IConfiguration _configuration { get; set; }

        public ContactOwnerService(magicbrics2392jeetContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _configuration = configuration;
        }
        public new object Add(ContactOwner contactOwner)
        {
            
            try
            {
                var user = DbContext.Properties.Join(DbContext.Users, p => p.UserId, u => u.UserId, (p, u) => new { u.Email ,u.Name,u.PhoneNo});
                foreach(var u in user)
                {
                    name = u.Name;
                    phone = u.PhoneNo;
                    email = u.Email;
                }
                var mailMessage = new
                    MailMessage(_configuration.GetValue<string>("EMail"), contactOwner.Email)
                {
                    Subject = "You Have Contacted Owner Of The Property Successfully At MagicBricks",
                    Body = $"Owner Name is:{name} Owner Contact Number is:{phone}  and Owner's Email is:{email}",
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
                base.Add(contactOwner);
                return new Response() {Status=200,Message="Contacted to owner successfully" };

            }
            catch(Exception e)
            {
                return e;
            }
        }

        public string Update(int id , ContactOwner contactOwner)
        {
            var obj = base.GetById(id);
            if (obj == null) return $"Details Not found Of ID: {id}";
            base.Update(contactOwner,id);
            return $"Details With ID {id} Updated Successfully";
        }

        public string Remove(int id)
        {
            var obj = base.GetById(id);
            if (obj == null) return $"Details Not found Of ID: {id}";
            base.Remove(obj);
            return $"Details With ID {id} Deleted Successfully";
        }
    }
}
