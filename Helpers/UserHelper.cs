using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginApi.Libraries;
using LoginApi.Models;

namespace LoginApi.Helpers
{
    public class UserHelper
    {
        public async Task<UserModel> GetUserByUserPassword(string email, string pass)
        {
            return await new UserLibrary().GetUserByUserPassword(email, pass);
        }
    }
}
