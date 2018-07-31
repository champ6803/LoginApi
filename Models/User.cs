using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenerateUserApi.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string email { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
        public string type_account { get; set; }
    }
}
