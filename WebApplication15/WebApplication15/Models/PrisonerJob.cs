using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication15.Models
{
    public class PrisonerJob
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string prisonerId { get; set; }
        public string jobId { get; set; }

    }
}
