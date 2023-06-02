using System.Text;
using API.Extensions;
using API.Interfaces;
using API.Middleware;
using API.Services;
using API.Thing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration;

// Add services to the container.


builder.Services.AddApplicationServices(_config);
builder.Services.AddControllers();
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>{
    build.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddIdentityService(_config);
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

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("MyCors");

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
