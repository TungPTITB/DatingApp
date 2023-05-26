using API.Thing;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration;

// Add services to the container.


builder.Services.AddDbContext<DataContext>(options=>{
    options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>{
    build.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));
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

app.UseRouting();

app.UseCors("MyCors");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
