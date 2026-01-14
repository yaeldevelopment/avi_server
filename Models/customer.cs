using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApplication14.Models
{
    public class customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("title")]
        public string title { get; set; }
        [BsonElement("expert")]
        public string expert { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
    }
}
