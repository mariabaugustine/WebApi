using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ProductApi.DBContext;
using ProductApi.Repository;
using System.Reflection;

namespace ProductApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                              .AddFluentValidation(cofig=>
                              {
                                  cofig.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                              });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            //step 4
            builder.Services.AddDbContext<ProductDBContext>
                (options=>options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnectionString")));
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}