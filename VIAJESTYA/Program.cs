using Microsoft.AspNetCore.Builder;
using VIAJESTYA.REPOSITORIES;
using VIAJESTYA.SERVICES;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddScoped<IVueloRepository>(
    sp => new VueloRepository(connectionString));

builder.Services.AddScoped<IHotelRepository>(
    sp => new HotelRepository(connectionString));

builder.Services.AddScoped<IReservaRepository>(
    sp => new ReservaRepository(connectionString));


builder.Services.AddScoped<IVueloService, VueloService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IReservaService, ReservaService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();