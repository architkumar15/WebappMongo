using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappMongo.Model.Resturant
{
    public class UpdateResturantModel
    {

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("borough")]
        public string Borough { get; set; }

        [BsonElement("cuisine")]
        public string Cuisine { get; set; }

        [BsonElement("grades")]
        public objecttype[] Grades { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

     


    }
 


}

