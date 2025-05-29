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
                CreateMap<GET_Roles, GET_RolesDto>().ReverseMap();
                CreateMap<GET_UserRoles, GET_UserRolesDto>().ReverseMap();  
                CreateMap<GET_Users, GET_UsersDto>().ReverseMap();    
                CreateMap<GET_WorkoutPlans, GET_WorkoutPlansDto>().ReverseMap();
            }
        }
    }
}
