using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApp.API.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var AllowAnyOrigin = "_allowAnyOrigin";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAnyOrigin,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MainContext>(options =>
{
    var useInMemoryDb = builder.Configuration.GetValue<bool>("Settings:UseInMemoryDb");
    if (useInMemoryDb)
    {
        options.UseInMemoryDatabase("InMemoryDb");
    }
    else
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase"));
    }
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowAnyOrigin);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
