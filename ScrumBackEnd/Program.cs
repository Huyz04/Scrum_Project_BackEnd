
using Microsoft.EntityFrameworkCore;
using ScrumBackEnd.Model;

namespace ScrumBackEnd
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

            builder.Services.AddDbContext<CampaignContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Connection") ??
                  throw new InvalidOperationException("Connection String is not found"));
            });


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseCors(options => options.WithOrigins("http://127.0.0.1:5501").AllowAnyMethod()
            .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
