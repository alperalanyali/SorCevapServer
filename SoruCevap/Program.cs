using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoruCevap.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(options => true);
    }
        );
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SinavDB"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors();
app.Run();

