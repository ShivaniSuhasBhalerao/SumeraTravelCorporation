using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Repository_Pattern;
using Sumera_Travel_Corporation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IHolidayPackageCrudService, HolidayPackageCrudService>();
builder.Services.AddScoped<IHolidayBookingCrudService, HolidayBookingCrudService>();
builder.Services.AddScoped<IHotelCrudService, HotelCrudService>();
builder.Services.AddScoped<ICustomerCrudService, CustomerCrudService>();
builder.Services.AddScoped<IAirportCrudService, AirportCrudService>();
builder.Services.AddScoped<ILocationCrudService, LocationCrudService >();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();
