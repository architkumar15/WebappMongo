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
using AutoMapper;

namespace WebappMongo.Controllers
{
    [ApiController]
    [Route("Developer")]
    public class DeveloperController : Controller
    {
        private readonly IMongoCollection<DeveloperModel> _developer;
        private readonly IMapper _mapper;
        private IConfiguration _configuration;
        public DeveloperController(IConfiguration configuration, IDeveloperDatabaseSettings settings, IMapper mapper)
        {

            _mapper = mapper;
            _configuration = configuration;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _developer = database.GetCollection<DeveloperModel>(settings.DevCollectionName);
        }


        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var dbList = _developer.AsQueryable();
                var userViewModel = _mapper.Map<DeveloperCollection>(dbList);
                return new JsonResult(userViewModel);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }

        [HttpPost]
        public JsonResult Post(PostDeveloperModel dep)
        {
            try
            {
                DeveloperModel newcollection = new DeveloperModel()
                {
                    Name = dep.Name,
                    From = dep.From,
                    mobileNo = dep.mobileNo,
                    IsActive = dep.IsActive,
                };
                _developer.InsertOne(newcollection);
                return new JsonResult("Added Successfully");
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);

            }

        }

        [HttpPut]
        public JsonResult Put(double mobileNo, UpdateDeveloperModel dep)
        {
            try
            {
                var datacount = _developer.AsQueryable().Count();
                if (datacount != 0)
                {
                    var filter = Builders<DeveloperModel>.Filter.Eq("mobileNo", mobileNo);
                    var updateName = Builders<DeveloperModel>.Update.Set("Name", dep.Name);

                    _developer.UpdateMany(filter, updateName);
                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    return new JsonResult("No data found");
                }
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);

            }
        }

        [HttpDelete]
        public JsonResult Delete(double mobileNo)
        {
            try
            {
                var datacount = _developer.AsQueryable().Count();
                if (datacount != 0)
                {
                    var filter = Builders<DeveloperModel>.Filter.Eq("mobileNo", mobileNo);
                    _developer.DeleteOne(filter);

                    return new JsonResult("Deleted Successfully");
                }
                else
                {
                    return new JsonResult("No Data Found");

                }
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);

            }
        }

    }

}
