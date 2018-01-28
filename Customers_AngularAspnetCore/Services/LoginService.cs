using System;
using System.Collections.Generic;
using System.Linq;
using Customers_AngularAspnetCore.DataModel;
using Customers_AngularAspnetCore.ViewModel;

namespace Customers_AngularAspnetCore.Services
{
    public class LoginService
    {
        public LoginVM VerifyLoginUser(string email, string password)
        {
            LoginVM login = null;

            try
            {
                using (var db = new ContextDB())
                {
                    login = (from us in db.UserSys
                             join ur in db.UserRole on us.UserRoleId equals ur.Id
                             where us.Email == email
                                && us.Password == password
                             select new LoginVM
                             {
                                 Id = us.Id,
                                 Login = us.Login,
                                 IsAdmin = ur.IsAdmin
                             }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return login;
        }
    }
}
