using Microsoft.OpenApi.Models;
using WebAppAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "TEST API REST",
            Version = "v1",
            Description = "The API works with the information from the Country Table",
           
            Contact = new OpenApiContact
            {
                Name = "SEGUNDO VIGO",
                Email = "svigoc@gmail.com",
                Url = new Uri("https://www.linkedin.com/in/svigoc6a1890130")
            }
        });
    }

    );

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API For Country"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
