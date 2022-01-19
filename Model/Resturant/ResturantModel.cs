using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappMongo.Model.Resturant
{
   
        public class ResturantModel
        {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId id { get; set; }

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

        [BsonElement("restaurant_id")]
        public string ResturantId { get; set; }


    }
    public class Address
    {
        [BsonElement("building")]
        public string Building { get; set; }

        [BsonElement("coord")]
        public object[] Coord { get; set; }

        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("zipcode")]
        public string Zipcode { get; set; }
    }


    public class objecttype
    {
        [BsonElement("date")]

        public DateTime Date { get; set; }
        [BsonElement("grade")]

        public string Grade { get; set; }
        [BsonElement("score")]
        public object Score { get; set; }
    }

  
    
}
