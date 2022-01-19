﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebappMongo.Model.Developer
{
    public class DeveloperModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("from")]
        public string From { get; set; }

        [BsonElement("mobileno")]
        public double mobileNo { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }
    }
}
