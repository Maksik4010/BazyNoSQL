using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication15.Models
{
    public class Sensor
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string prisonLocationId { get; set; }
        public string sensorTypeId { get; set; }
        public string name { get; set; }

    }
}
