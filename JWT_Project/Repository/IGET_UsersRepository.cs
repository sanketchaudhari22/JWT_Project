using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface IGET_UsersRepository 
    {
        Task<List<GET_Users>> getAsync(GET_UsersDomain input);
    }
}
