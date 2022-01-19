using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappMongo.DAL.DbSettings
{
   

        public class DeveloperDatabaseSettings : IDeveloperDatabaseSettings
        {
            public string DevCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface IDeveloperDatabaseSettings
        {
            public string DevCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
}

