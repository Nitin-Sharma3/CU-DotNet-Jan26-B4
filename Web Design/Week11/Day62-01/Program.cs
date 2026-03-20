using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Day62_01.Data;

namespace Day62_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Day62_01Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Day62_01Context") ?? throw new InvalidOperationException("Connection string 'Day62_01Context' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
