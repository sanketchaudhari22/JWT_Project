using JWT_Project.Data;
using JWT_Project.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace JWT_Project.Repository
{
    public class SqlSP_AddUpdWorkoutPlansRepository : ISP_AddUpdWorkoutPlansRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SqlSP_AddUpdWorkoutPlansRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<ApiResponseMessage>> getasync(SP_AddUpdWorkoutPlans input)
        {
            List<ApiResponseMessage> list = new List<ApiResponseMessage>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "[SP_AddUpdWorkoutPlans]";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameter1 = command.CreateParameter();
                parameter1.ParameterName = "@ID";
                parameter1.Value = input.ID;
                command.Parameters.Add(parameter1);
                parameter1 = command.CreateParameter();

                parameter1.ParameterName = "@PLANNAME";
                parameter1.Value = input.PLANNAME;
                command.Parameters.Add(parameter1);
                parameter1 = command.CreateParameter();

                parameter1.ParameterName = "@DESCRIPTION";
                parameter1.Value = input.DESCRIPTION;
                command.Parameters.Add(parameter1);
                parameter1 = command.CreateParameter();

                parameter1.ParameterName = "@TRAINERID";
                parameter1.Value = input.TRAINERID;
                command.Parameters.Add(parameter1);
                parameter1 = command.CreateParameter();

                parameter1.ParameterName = "@MEMBERID";
                parameter1.Value = input.MEMBERID;
                command.Parameters.Add(parameter1);
                parameter1 = command.CreateParameter();

                parameter1.ParameterName = "@CREATEDAT";
                parameter1.Value = input.CREATEDAT;
                command.Parameters.Add(parameter1);
                parameter1 = command.CreateParameter();

                dbContext.Database.OpenConnection();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new ApiResponseMessage
                        {
                            IsSuccessful = reader.GetInt32("IsSuccessful"),
                            ResponseCode = reader.GetString("ResponseCode"),
                            ResponseMessage = reader.GetString("ResponseMessage"),
                            ResponseValues = reader.GetString("ResponseValues"),
                        });
                    }
                }
            }
            return list;
        }
    }
}
