using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappMongo.Model.Developer
{
    public class UpdateDeveloperModel
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
