using JWT_Project.Data;
using JWT_Project.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace JWT_Project.Repository
{
    public class SqlGET_WorkoutPlansRepository : IGET_WorkoutPlansRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SqlGET_WorkoutPlansRepository (ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_WorkoutPlans>> getasync(GET_WorkoutPlansDomain input)
        {
            List<GET_WorkoutPlans> list = new List<GET_WorkoutPlans>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_WorkoutPlans]( '" + input.ID + "' )ORDER BY ID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_WorkoutPlans
                        {
                            ID = reader.GetString(reader.GetOrdinal("ID")),
                            PLANNAME = reader.GetString(reader.GetOrdinal("PLANNAME")),
                            DESCRIPTION = reader.GetString(reader.GetOrdinal("DESCRIPTION")),
                            MEMBERID = reader.GetInt32(reader.GetOrdinal("MEMBERID")),
                            CREATEDAT = reader.GetString(reader.GetOrdinal("CREATEDAT")),


                        });
                    }
                }
            }
            return list;
        }
    }
}
