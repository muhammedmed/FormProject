using Microsoft.EntityFrameworkCore;
using WebFormApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name: "UsersOrigin",
    policy =>
    {
        policy.WithOrigins("https://localhost:7082/").AllowAnyMethod().AllowAnyHeader();
    }));
builder.Services.AddDbContext<FullStackDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("UsersOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
