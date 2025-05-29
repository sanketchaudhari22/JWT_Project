using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface IGET_UserRolesRepository
    {
        Task<List<GET_UserRoles>> getasync(GET_UserRolesDomain input);
    }
}
