using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication15.Models
{
    public class Guard
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string brithdate { get; set; }
        public string acceptanceDate { get; set; }
        public string dissmisialDate { get; set; }
        public string prisonPositionId { get; set; }
        public string prisonRankId { get; set; }
    }
}
