using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface ISP_AddUpdUserRolesRepository
    {
        Task<List<ApiResponseMessage>> getasync(SP_AddUpdUserRoles input);
    }
}
