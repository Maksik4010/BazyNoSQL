using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication15.Models
{
    public class Application
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string description { get; set; }
        public string applicationTypeId { get; set; }
        public string prisonerId { get; set; }
        public string tutorId { get; set; }

    }
}
