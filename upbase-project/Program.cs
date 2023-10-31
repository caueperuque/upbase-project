using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using upbase_project.Context;
using upbase_project.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringMySql = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(option => option.UseMySql(
       connectionStringMySql,
       ServerVersion.Parse("8.0.33-MySQL")
       )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API p/ cadastro de alunos",
        Description = "Uma API simples para cadastro de alunos",
        Contact = new OpenApiContact
        {
            Name = "Cauê Peruque",
            Email = "caue19052003@gmail.com",
            Url = new Uri("https://caue.webmenu.dev")
        }
    });
});
builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API p/ cadastro de alunos");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
