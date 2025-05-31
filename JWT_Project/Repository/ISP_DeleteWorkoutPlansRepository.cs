using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface ISP_DeleteWorkoutPlansRepository
    {
        Task<List<ApiResponseMessage>> getasync(SP_DeleteWorkoutPlans input);
    }
}
