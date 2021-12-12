using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication15.Models
{
    public class Schedule
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string dayOfWeek { get; set; }
        public string quardId { get; set; }
    }
}
