using JWT_Project.Model.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
                        ID = reader.GetString("ID"),
                        USERNAME = reader.GetString("USERNAME"),
                        PASSWORD = reader.GetString("PASSWORD"),
                        ROLE = reader.GetString("ROLE"),
                        CREATEDAT = reader.GetString("CREATEDAT"),
                     
                    };

                    if (dbUser.USERNAME == username)
                        return dbUser;
                }
            }
        }
        return null;
    }
}