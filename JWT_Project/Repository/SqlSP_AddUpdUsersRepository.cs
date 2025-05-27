using JWT_Project.Data;
using JWT_Project.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace JWT_Project.Repository
{
    public class SqlSP_AddUpdUsersRepository : ISP_AddUpdUsersRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SqlSP_AddUpdUsersRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<ApiResponseMessage>> getasync(SP_AddUpdUsers input)
        {
            List<ApiResponseMessage> list = new List<ApiResponseMessage>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "[SP_AddUpdUsers]";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@ID";
                parameter.Value = input.ID;
                command.Parameters.Add(parameter);
                parameter = command.CreateParameter();

                parameter.ParameterName = "@USERNAME";
                parameter.Value = input.USERNAME;
                command.Parameters.Add(parameter);
                parameter = command.CreateParameter();

                parameter.ParameterName = "@PASSWORD";
                parameter.Value = input.PASSWORD;
                command.Parameters.Add(parameter);
                parameter = command.CreateParameter();

                parameter.ParameterName = "@ROLE";
                parameter.Value = input.ROLE;
                command.Parameters.Add(parameter);
                parameter = command.CreateParameter();

                parameter.ParameterName = "@CREATEDAT";
                parameter.Value = input.CREATEDAT;
                command.Parameters.Add(parameter);
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
