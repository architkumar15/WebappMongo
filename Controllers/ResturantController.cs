using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebappMongo.Model.Resturant;
using WebappMongo.Model;

using WebappMongo.DAL.Collection;
using WebappMongo.DAL.DbSettings;
using MongoDB.Bson.IO;

namespace WebappMongo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : Controller
    {
        private readonly IMongoCollection<ResturantModel> _restaurants;

        private IConfiguration _configuration;
        public ResturantController(IConfiguration configuration, IRestaurantDatabaseSettings settings)
        {
            _configuration = configuration;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _restaurants = database.GetCollection<ResturantModel>(settings.ResCollectionName);
        }


        [HttpGet]
        [Route("GetResturant")]
        public JsonResult Get()
        {
            try
            {
                var dbList = _restaurants.AsQueryable();
                return new JsonResult(dbList);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }


        [HttpPost]
        public JsonResult Post(PostResturantModel rep)
        {
            try
            {
                ResturantModel NewDocument = new ResturantModel()
                {
                    Address = rep.Address,
                    Borough = rep.Borough,
                    Cuisine = rep.Cuisine,
                    Grades = rep.Grades,
                    Name = rep.Name,
                    ResturantId = rep.ResturantId
                };
                _restaurants.InsertOne(NewDocument);

                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }


        [HttpPut]
        public JsonResult Put(string Name, UpdateResturantModel rep)
        {
            try
            {
                var filter = Builders<ResturantModel>.Filter.Eq("Name", Name);
                var updateName = Builders<ResturantModel>.Update.Set("Name", rep.Name);
                _restaurants.UpdateMany(filter, updateName);
                return new JsonResult("Updated Successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }



        [HttpDelete]
        public JsonResult Delete(string Name)
        {
            try
            {
                var filter = Builders<ResturantModel>.Filter.Eq("Name", Name);
                _restaurants.DeleteOne(filter);
                return new JsonResult("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);

            }
        }
    }
}
