using JWT_Project.Model.Domain;
using JWT_Project.Model.Dto;

namespace JWT_Project.Repository
{
    public interface ISP_DeleteUsersRepository 
    {
        Task<List<ApiResponseMessage>> getasync(SP_DeleteUsers input);
    }
}
