using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    options => options.SerializerSettings.ContractResolver=new DefaultContractResolver());

builder.Services.AddDbContext<EComContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcomConnectionString"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.CommandTimeout(30); 
        }
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
    );

app.UseRouting();


app.UseAuthorization();

app.MapControllers();

app.Run();
