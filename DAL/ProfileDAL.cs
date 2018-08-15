using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using LoginApi.Models;

namespace LoginApi.DAL
{
    public class ProfileDAL
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<ProfileModel> col;

        public ProfileDAL()
        {
            this.client = new MongoClient("mongodb://champ6803:www12345@clusteratsdev-shard-00-00-lxs0q.mongodb.net:27017,clusteratsdev-shard-00-01-lxs0q.mongodb.net:27017,clusteratsdev-shard-00-02-lxs0q.mongodb.net:27017/admin?ssl=true");
            this.db = client.GetDatabase("ats");
            this.col = this.db.GetCollection<ProfileModel>("profile");
        }

        public async Task<IEnumerable<ProfileModel>> All()
        {
            try
            {
                var list = await this.col.Find(new BsonDocument()).ToListAsync();
                return list;
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
                var profile = await this.col.Find(x => x.email.Equals(email)).FirstOrDefaultAsync();
                return profile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}