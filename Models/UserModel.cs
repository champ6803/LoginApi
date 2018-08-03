using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoginApi.Models
{
    public class UserModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string email { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
        public string role { get; set; }
        public string app { get; set; }
    }
}
