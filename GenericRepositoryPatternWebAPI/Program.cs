using GenericRepositoryPatternWebAPI.DatabaseContext;
using GenericRepositoryPatternWebAPI.IRepository;
using GenericRepositoryPatternWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPatternWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AdventureWorks2019DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
