
using MySQLwebAPI.Controllers;
using MySQLwebAPI.Model;
using MySql;
using Microsoft.EntityFrameworkCore;
using MySQLwebAPI.Services;
using MySQLwebAPI.Repositery;
namespace MySQLwebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<WiprodbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IEmployeRepo<Employee>, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeService<Employee>, EmployeeService>();

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
        }
    }
}
