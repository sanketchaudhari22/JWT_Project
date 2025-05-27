using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface ISP_AddUpdWorkoutPlansRepository
    {
        Task<List<ApiResponseMessage>> getasync(SP_AddUpdWorkoutPlans input);
    }
}
