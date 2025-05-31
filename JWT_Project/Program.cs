using JWT_Project.Data;
using JWT_Project.Model.Domain;
using JWT_Project.Repository;
using Microsoft.EntityFrameworkCore;
using static JWT_Project.Mapping.AutoMappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("shadimuharathConStr")));

builder.Services.AddScoped<ISP_AddUpdRolesRepository, SqlSP_AddUpdRolesRepository>();

builder.Services.AddScoped<ISP_AddUpdUserRolesRepository, SqlSP_AddUpdUserRolesRepository>();

builder.Services.AddScoped<ISP_AddUpdUsersRepository, SqlSP_AddUpdUsersRepository>();

builder.Services.AddScoped<ISP_AddUpdWorkoutPlansRepository, SqlSP_AddUpdWorkoutPlansRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddScoped<IGET_RolesRepository, SqlGET_RolesRepository>();
builder.Services.AddScoped<IGET_UserRolesRepository, SqlGET_UserRolesRepository>();
builder.Services.AddScoped<IGET_UsersRepository, SqlGET_UsersRepository>();
builder.Services.AddScoped<IGET_WorkoutPlansRepository, SqlGET_WorkoutPlansRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
