using JWT_Project.Data;
using JWT_Project.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace JWT_Project.Repository
{
    public class SqlSP_AddUpdRolesRepository : ISP_AddUpdRolesRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SqlSP_AddUpdRolesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<ApiResponseMessage>> getasync(SP_AddUpdRoles input)
        {
           List<ApiResponseMessage> list = new List<ApiResponseMessage>();
           using(var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "[SP_AddUpdRoles]";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@ID";
                parameter.Value = input.ID;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@NAME";
                parameter.Value = input.NAME;
                command.Parameters.Add(parameter);

                dbContext.Database.OpenConnection();

                using(var reader = await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
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
