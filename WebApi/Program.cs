using Service;
using Service.Interface;
using Service.Services;

namespace WebApi
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

            builder.Services.AddScoped<IUserServ, UserSer>();

            builder.Services.AddRepoDependencies();
            builder.Services.AddCors(op => { op.AddPolicy(name: "myOrigin", policy => policy.WithOrigins("*").AllowAnyMethod()); });
                
                


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //app.UseRouting();
            app.UseCors("myOrigion");

            app.MapControllers();

            app.Run();
        }
    }
}