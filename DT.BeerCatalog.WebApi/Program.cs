using DT.BeerCatalog.FileRepository;
using DT.BeerCatalog.Models;

string MyAllowedOrigins = "_myAllowedOrigins";

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowedOrigins,
        builder =>
        {
            builder.WithOrigins("https://localhost:7252").AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddSingleton<IAddressRepository, AddressRepository>();

builder.Services.AddControllers();
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

app.UseCors(MyAllowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
