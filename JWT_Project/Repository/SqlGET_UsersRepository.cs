using JWT_Project.Data;
using JWT_Project.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace JWT_Project.Repository
{
    public class SqlGET_UsersRepository : IGET_UsersRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SqlGET_UsersRepository (ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_Users>> getAsync(GET_UsersDomain input)
        {
            List<GET_Users> list = new List<GET_Users>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_Users]( '" + input.ID + "' )ORDER BY ID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_Users
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            USERNAME = reader.GetString(reader.GetOrdinal("USERNAME")),
                            PASSWORD = reader.GetString(reader.GetOrdinal("PASSWORD")),
                            ROLE = reader.GetString(reader.GetOrdinal("ROLE")),
                            CREATEDAT = reader.GetString(reader.GetOrdinal("CREATEDAT")),


                        });
                    }
                }
            }
            return list;
        }
    }
}
