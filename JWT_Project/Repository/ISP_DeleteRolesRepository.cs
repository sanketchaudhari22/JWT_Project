using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface ISP_DeleteRolesRepository
    {
        Task<List<ApiResponseMessage>> getasync(SP_DeleteRoles input);
    }
}
