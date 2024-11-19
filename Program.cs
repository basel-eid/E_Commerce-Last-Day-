
using E_Commerce_Last_Day_.Data;
using E_Commerce_Last_Day_.Repos.ProductRepos;
using E_Commerce_Last_Day_.Repos.UserRepos;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Last_Day_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(x=> x.UseSqlServer(builder.Configuration.GetConnectionString("Def")));
            builder.Services.AddScoped<IUserRepo,UserRepo>();
            builder.Services.AddScoped<IproductRepo,ProductRepo>();
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
