using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace SailorMoonEncyclopedia_Coursework.DB
{
    public class Character
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        protected string Name;
        protected string ShortDescription;
        protected string Description;
        protected string Capabilities;
        protected byte[] Image;

        public Character(string q1, string q2, string q3, string q4, byte[] q5)
        {
            this.Name = q1;
            this.ShortDescription = q2;
            this.Description = q3;
            this.Capabilities = q4;
            this.Image = q5;
        }

        public Character()
        {  }

        public string _name { get => Name; set => Name = value; }
        [BsonElement]
        public string _shortdescription { get => ShortDescription; set => ShortDescription = value; }
        [BsonElement]
        public string _description { get => Description; set => Description = value; }
        [BsonElement]
        public string _capabilities { get => Capabilities; set => Capabilities = value; }
        [BsonElement]
        public byte[] _image { get => Image; set => Image = value; }

        public void Add(Character characterale)
        {
            MongoClient client = new MongoClient();
            var abase = client.GetDatabase("DB_SailorMoon");
            var b = abase.GetCollection<Character>("Character");
            b.InsertOne(characterale);
        }
    }
}
