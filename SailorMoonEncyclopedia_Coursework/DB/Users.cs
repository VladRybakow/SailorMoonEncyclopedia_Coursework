using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace SailorMoonEncyclopedia_Coursework.DB
{
    class Users
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        protected string Name;
        protected string Email;
        protected string Password;
        protected double Phone;
        protected string Role;

        public Users(string v1, string v2, string v3, double v4, string v5)
        {
            this.Name = v1;
            this.Email = v2;
            this.Password = v3;
            this.Phone = v4;
            this.Role = v5;
        }

        public string _name { get => Name; set => Name = value; }
        [BsonElement]
        public string _email { get => Email; set => Email = value; }
        [BsonElement]
        public string _password { get => Password; set => Password = value; }
        [BsonElement]
        public double _phone { get => Phone; set => Phone = value; }
        [BsonElement]
        public string _role { get => Role; set => Role = value; }

        public void Add(Users us)
        {
            MongoClient client = new MongoClient();
            var abase = client.GetDatabase("RybakovDB");
            var b = abase.GetCollection<Users>("RER");
            b.InsertOne(us);
        }
    }
}
