using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface ISP_AddUpdRolesRepository
    {
        Task<List<ApiResponseMessage>>getasync(SP_AddUpdRoles input);
    }
}
