using Magicbrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Services
{
    public interface ILoginService : IRepository<User> 
    {
        public int LoginUser(LoginModel model);
    }


    public class LoginService:Repository<User>,ILoginService
    {
        public LoginService(magicbrics2392jeetContext dbContext) : base(dbContext)
        {
        }

        public int LoginUser(LoginModel model)
        {
            var user = DbContext.Users.Where(u => (u.Email==model.EmailOrPhone)||(u.PhoneNo==model.EmailOrPhone)).FirstOrDefault();
            var isUser=   BCrypt.Net.BCrypt.Verify(model.pswd, user.Password);
            if (isUser == true)
            {
                return user.UserId;
            }
            else return 0;
        }
    }
}
