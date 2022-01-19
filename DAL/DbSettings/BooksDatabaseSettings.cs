using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappMongo.DAL.DbSettings
{
    public class BooksDatabaseSettings : IBooksDatabaseSettings
    {
        public string BookCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }


    public interface IBooksDatabaseSettings
    {
        public string BookCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
