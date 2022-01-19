
using WebappMongo.DAL.Collection;
using WebappMongo.Model.Developer;
using AutoMapper;
using WebappMongo.Model.Resturant;

namespace WebappMongo.Model.AutoMapper
{
    public class MappingProfile :Profile
    {
       public MappingProfile()
        {
            CreateMap<DeveloperCollection,DeveloperModel>();
            CreateMap< ResturantModel, ResturantCollection>();
        }
    }
}
