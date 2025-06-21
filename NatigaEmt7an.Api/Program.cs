
using Microsoft.EntityFrameworkCore;
using NatigaEmt7an.Api.Data;
using NatigaEmt7an.Api.Interfaces.IRepositories;
using NatigaEmt7an.Api.Repositories;

namespace NatigaEmt7an.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
            builder.Services.AddScoped<ISchoolAdministrationsRepository, SchoolAdministrationsRepository>();
            builder.Services.AddScoped<IGovernorateRepository, GovernorateRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    policy => policy
                        .WithOrigins("https://localhost:7009") // Allow this origin
                        .AllowAnyMethod()                        // Allow any HTTP methods
                        .AllowAnyHeader()                        // Allow any headers
                        .AllowCredentials());                    // Allow credentials if needed
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }
            app.UseCors("AllowSpecificOrigin");


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
