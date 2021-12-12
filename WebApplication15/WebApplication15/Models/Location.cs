using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication15.Models
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int propertyNumber { get; set; }
        public int apartamentNumber { get; set; }
        public string description { get; set; }

    }
}
