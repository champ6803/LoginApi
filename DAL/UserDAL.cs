using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using LoginApi.Models;

namespace LoginApi.DAL
{
    public class UserDAL
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<UserModel> col;

        public UserDAL()
        {
            this.client = new MongoClient("mongodb://champ6803:www12345@clusteratsdev-shard-00-00-lxs0q.mongodb.net:27017,clusteratsdev-shard-00-01-lxs0q.mongodb.net:27017,clusteratsdev-shard-00-02-lxs0q.mongodb.net:27017/admin?ssl=true");
            this.db = client.GetDatabase("ats");
            this.col = this.db.GetCollection<UserModel>("user");
        }

        public async Task<UserModel> GetUserByUserPassword(string email, string pass)
        {
            try
            {
                var user = await this.col.Find(x => x.email.Equals(email) && x.pwd.Equals(pass)).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}