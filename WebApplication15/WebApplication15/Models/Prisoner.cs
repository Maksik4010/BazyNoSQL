using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.models
{
    public class Prisoner
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string brithdate { get; set; }
        public string entryDate { get; set; }
        public string leaveDate { get; set; }
        public string prisonLocationId { get; set; }

    }
}
