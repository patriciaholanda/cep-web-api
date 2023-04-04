using AddressSearch.Application.Services;
using AddressSearch.Domain.Interfaces.Repositories;
using AddressSearch.Domain.Interfaces.Services;
using AddressSearch.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IViaCepService, ViaCepService>();
builder.Services.AddScoped<IApiCepService, ApiCepService>();
builder.Services.AddScoped<IAwesomeApiCepService, AwesomeApiCepService>();
builder.Services.AddScoped<ISearchAddressService, SearchAddressService>();

builder.Services.AddScoped<IViaCepRepository, ViaCepRepository>();
builder.Services.AddScoped<IApiCepRepository, ApiCepRepository>();
builder.Services.AddScoped<IAwesomeApiCepRepository, AwesomeApiCepRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
