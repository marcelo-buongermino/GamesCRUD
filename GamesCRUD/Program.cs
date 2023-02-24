using GamesCRUD.Data;
using GamesCRUD.Repositories;
using GamesCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace GamesCRUD;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Conexao do EF, Db Context no pgsql 
        builder.Services.AddEntityFrameworkNpgsql()
            .AddDbContext<GameCrudDBContext>(opt => 
            opt.UseNpgsql(builder.Configuration.GetConnectionString("Game_Crud_DB")));

        // Add services to the container.

        builder.Services.AddScoped<IGameRepository, GameRepository>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddControllers().AddNewtonsoftJson();

        //adicao do AutoMapper
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        // Documentacao Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "GameAPI",
                Version = "v1" 
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });


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