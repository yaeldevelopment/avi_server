using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class apartment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("type")]
        public string type { get; set; }
        [BsonElement("title")]
        public string titlenumber_room { get; set; }


        [BsonElement("city")]
        public string city { get; set; }
        [BsonElement("neighborhood")]
        public string neighborhoodMeter { get; set; }
        [BsonElement("price")]
        public double price { get; set; }
        
        [BsonElement("rooms")]
        public double rooms { get; set; }


        [BsonElement("bathrooms")]
        public int bathrooms { get; set; }
        [BsonElement("size")]
        public int size { get; set; }
        [BsonElement("image")]
        public string image { get; set; }
        [BsonElement("floor")]
        public int floor { get; set; }
        [BsonElement("features")]
        public string[] features { get; set; }
    }


}
