using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class More_details
    {
        [BsonElement("type_of_transaction")]
        public string type_of_transaction { get; set; }
        [BsonElement("floors_in_the_building")]
        public int floors_in_the_building { get; set; }
        [BsonElement("date_of_entry")]
        public string date_of_entry { get; set; }
        [BsonElement("Property_condition")]
        public string Property_condition { get; set; }
        [BsonElement("parking")]
        public Boolean parking { get; set; }

    }
}
