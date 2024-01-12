using BLL.Abstracts;
using BLL.Concretes;
using DAL.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//DbContext
builder.Services.AddDbContext<ImdbdataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Services
builder.Services.AddScoped<IMovieService, MovieService>();

//CORS
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("MovieCors", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});




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
app.UseCors("MovieCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
