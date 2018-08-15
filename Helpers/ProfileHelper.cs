using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginApi.Libraries;
using LoginApi.Models;

namespace LoginApi.Helpers
{
    public class ProfileHelper
    {
        public async Task<IEnumerable<ProfileModel>> GetProfileList()
        {
            return await new ProfileLibrary().GetProfileList();
        }

        public async Task<ProfileModel> GetProfileByEmail(string email)
        {
            return await new ProfileLibrary().GetProfileByEmail(email);
        }
    }
}