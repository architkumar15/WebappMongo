using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappMongo.DAL.DbSettings
{
   
        public class RestaurantDatabaseSettings : IRestaurantDatabaseSettings
        {
            public string ResCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface IRestaurantDatabaseSettings
        {
            public string ResCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
}

