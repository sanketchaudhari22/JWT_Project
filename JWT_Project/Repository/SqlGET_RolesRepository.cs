using JWT_Project.Data;
using JWT_Project.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace JWT_Project.Repository
{
    public class SqlGET_RolesRepository : IGET_RolesRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SqlGET_RolesRepository(ApplicationDbContext dbContext)
        {
         this.dbContext = dbContext;    
        }
        public async Task<List<GET_Roles>> getasync(GET_RolesDomain input)
        {

            List<GET_Roles> list = new List<GET_Roles>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_Roles]( '" + input.ID + "' )ORDER BY ID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_Roles
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),


                        });
                    }
                }
            }
            return list;
        }
    }
}