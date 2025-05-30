using AutoMapper;
using JWT_Project.Model.Domain;
using JWT_Project.Model.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JWT_Project.Mapping
{
    public class AutoMappingProfile
    {
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {

                CreateMap<ApiResponseMessage , ApiResponseMessageDto>().ReverseMap();
            }
        }
    }
}
