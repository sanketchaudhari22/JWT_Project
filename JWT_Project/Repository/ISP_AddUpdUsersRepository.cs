using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface ISP_AddUpdUsersRepository
    {
        Task<List<ApiResponseMessage>> getasync(SP_AddUpdUsers input);
    }
}
