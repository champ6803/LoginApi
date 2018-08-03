using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginApi.Models;
using LoginApi.DAL;

namespace LoginApi.Libraries
{
    public class UserLibrary
    {
        UserDAL userDal = new UserDAL();

        public async Task<UserModel> GetUserByUserPassword(string email, string pass)
        {
            try
            {
                var user = await userDal.GetUserByUserPassword(email, pass);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
