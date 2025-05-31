using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface ISP_DeleteUserRolesRepository
    {
        Task<List<ApiResponseMessage>> getasync(SP_DeleteUserRoles input);
    }
}

