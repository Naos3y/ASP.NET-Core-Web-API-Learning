using AutoMapper;
using udemy_project.Models.Domain;
using udemy_project.Models.DTO;

namespace udemy_project.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<CreateRegionRequest, Region>().ReverseMap();
            CreateMap<UpdateRegionRequest, Region>().ReverseMap();
        }
    }
}
