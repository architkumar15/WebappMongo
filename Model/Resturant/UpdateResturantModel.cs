using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappMongo.Model.Resturant
{
    public class UpdateResturantModel
    {

       

        [BsonElement("name")]
        public string Name { get; set; }

     


    }
 


}

