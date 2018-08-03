using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoginApi.Models
{
    public class LoginModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string username { get; set; }
        public string password { get; set; }
    }
}
