using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebappMongo.Model.Developer;
using WebappMongo.DAL.Collection;
using WebappMongo.DAL.DbSettings;

namespace WebappMongo.Controllers
{
    [ApiController]
    [Route("Developer")]
    public class DeveloperController : Controller
    {

        private IConfiguration _configuration;
        public DeveloperController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            
                var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
                var client = new MongoClient(settings);
                var database = client.GetDatabase("DeveloperDb");
                var dbList = database.GetCollection<DeveloperCollection>("Aspdev").AsQueryable();
                return new JsonResult(dbList); 
            
        }

        [HttpPost]
        public JsonResult Post(DeveloperModel dep)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
            var client = new MongoClient(settings);
            var datacount = client.GetDatabase("DeveloperDb").GetCollection<DeveloperCollection>("Aspdev").AsQueryable().Count();
            if (datacount != 0)
            {
                DeveloperCollection newcollection = new DeveloperCollection()
                {
                    Name = dep.Name,
                    From = dep.From,
                    mobileNo = dep.mobileNo,
                    IsActive = dep.IsActive,
                };
                client.GetDatabase("DeveloperDb").GetCollection<DeveloperCollection>("Aspdev").InsertOne(newcollection);
                return new JsonResult("Added Successfully");
            }
            else
            {
                return new JsonResult(" Data not submited");
            }
        }

        [HttpPut]
        public JsonResult Put(double mobileNo, UpdateDeveloperModel dep)
        {

            var filter = Builders<DeveloperCollection>.Filter.Eq("mobileNo", mobileNo);
            var updateName = Builders<DeveloperCollection>.Update.Set("Name", dep.Name);
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DeveloperDb");
            database.GetCollection<DeveloperCollection>("Aspdev").UpdateMany(filter, updateName);
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete]
        public JsonResult Delete(double mobileNo)
        {

            var filter = Builders<DeveloperCollection>.Filter.Eq("mobileNo", mobileNo);
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DeveloperDb");
            database.GetCollection<DeveloperCollection>("Aspdev").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }

    }

}
