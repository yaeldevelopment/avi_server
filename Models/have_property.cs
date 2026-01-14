using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class have_property
    {
        [BsonElement("elevator")]
        public Boolean elevator { get; set; }
        [BsonElement("Access_for_the_disabled")]
        public Boolean Access_for_the_disabled { get; set; }
        [BsonElement("Tornado_air_conditioner")]
        public Boolean Tornado_air_conditioner { get; set; }
        [BsonElement("multi_bolt_doors")]
        public Boolean multi_bolt_doors { get; set; }

        [BsonElement("Merger")]
        public Boolean Merger { get; set; }

        [BsonElement("grid")]
        public Boolean grid { get; set; }
        [BsonElement("warehouse")]
        public Boolean warehouse { get; set; }
        [BsonElement("David_Shemesh")]
        public Boolean David_Shemesh { get; set; }
        [BsonElement("improved")]
        public Boolean improved { get; set; }

        [BsonElement("Protected_space")]
        public Boolean Protected_space { get; set; }
        [BsonElement("porch")]
        public Boolean porch { get; set; }



    }
}
