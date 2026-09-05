using VIAJESTYA.REPOSITORIES;
using VIAJESTYA.models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IVueloRepository>(sp => new VueloRepository(connectionString));
builder.Services.AddScoped<IHotelRepository>(sp => new HotelRepository(connectionString));
builder.Services.AddScoped<IReservaRepository>(sp => new ReservaRepository(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();