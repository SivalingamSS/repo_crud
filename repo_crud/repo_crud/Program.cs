using Bussinesslayer.B_CLASS;
using Bussinesslayer.INTERFACE;
using Datalayer.d_CLASS;
using Datalayer.INTERFACE;
using ENTITIES.DBCONTEXT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace repo_crud
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
            builder.Services.AddDbContext<dbcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MVC6CrudConnectionString")));
            builder.Services.AddTransient<IBusiness, Bussiness_class>();
            builder.Services.AddTransient<IDatalayer, Datalayer_class>();

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