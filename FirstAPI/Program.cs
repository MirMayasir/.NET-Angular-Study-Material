
using FirstAPI.Models;
using FirstAPI.Repositery;
using FirstAPI.Service;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI
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
            builder.Services.AddDbContext<WiprongadbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<BankdatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection1")));

            builder.Services.AddScoped<ICourseRepo<Course>, CourseRepo>();
            builder.Services.AddScoped<ICourseService<Course>, CourseService>();

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
