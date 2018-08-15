using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginApi.Models;
using LoginApi.DAL;

namespace LoginApi.Libraries
{
    public class ProfileLibrary
    {
        ProfileDAL prodDal = new ProfileDAL();

        public async Task<IEnumerable<ProfileModel>> GetProfileList()
        {
            try
            {
                var all = await prodDal.All();
                return all;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProfileModel> GetProfileByEmail(string email)
        {
            try
            {
                var profile = await prodDal.GetProfileByEmail(email);
                return profile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
