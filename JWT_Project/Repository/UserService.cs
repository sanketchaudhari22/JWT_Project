using JWT_Project.Model.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JWT_Project.Repository;

public class UserService
{
    private readonly IConfiguration _configuration;

    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public GET_Users GetUserByUsername(string username)
    {
        using (var conn = new SqlConnection(_configuration.GetConnectionString("shadimuharathConStr")))
        {
            conn.Open();

            var command = new SqlCommand("SELECT * FROM dbo.GET_Users(@ID)", conn);
            command.Parameters.AddWithValue("@ID", "%");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var dbUser = new GET_Users
                    {
                        ID = reader["ID"].ToString(),
                        USERNAME = reader["USERNAME"].ToString(),
                        PASSWORD = reader["PASSWORD"].ToString(),
                        ROLE = reader["ROLE"].ToString(),
                        CREATEDAT = reader["CREATEDAT"].ToString()
                    };

                    if (dbUser.USERNAME == username)
                        return dbUser;
                }
            }
        }
        return null;
    }
}