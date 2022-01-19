using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappMongo.DAL.Collection
{
    public class DeveloperCollection
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
