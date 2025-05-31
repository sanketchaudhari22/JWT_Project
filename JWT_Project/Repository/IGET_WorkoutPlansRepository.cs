using JWT_Project.Model.Domain;

namespace JWT_Project.Repository
{
    public interface IGET_WorkoutPlansRepository
    {
        Task<List<GET_WorkoutPlans>> getasync(GET_WorkoutPlansDomain input);
    }
}
