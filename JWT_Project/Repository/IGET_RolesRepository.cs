using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface IGET_RolesRepository
    {
        Task<List<GET_Roles>> getasync(GET_RolesDomain input);
    }
}
