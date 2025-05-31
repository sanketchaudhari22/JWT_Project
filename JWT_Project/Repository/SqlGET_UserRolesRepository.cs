using System.Collections.Generic;
using JWT_Project.Data;
using JWT_Project.Model.Domain;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JWT_Project.Repository
{
    public class SqlGET_UserRolesRepository : IGET_UserRolesRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SqlGET_UserRolesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_UserRoles>> getasync(GET_UserRolesDomain input)
        { 
          List<GET_UserRoles> list = new List<GET_UserRoles>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_UserRoles]( '" + input.ID + "' )ORDER BY ID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_UserRoles
                        {
                            ID = reader.GetString(reader.GetOrdinal("ID")),
                            USERID = reader.GetString(reader.GetOrdinal("USERID")),
                            ROLEID = reader.GetString(reader.GetOrdinal("ROLEID")),


                        });
                    }
                }
            }
            return list;
        }
    }
}
